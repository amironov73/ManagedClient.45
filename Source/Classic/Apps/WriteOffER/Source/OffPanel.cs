﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* OffPanel.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using AM;
using AM.Collections;
using AM.Configuration;
using AM.Data;
using AM.IO;
using AM.Json;
using AM.Logging;
using AM.Reflection;
using AM.Runtime;
using AM.Text;
using AM.Text.Output;
using AM.UI;
using AM.Windows.Forms;

using CodeJam;

using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;

using IrbisUI;
using IrbisUI.Universal;

using JetBrains.Annotations;

using ManagedIrbis;
using ManagedIrbis.Client;
using ManagedIrbis.Fields;
using ManagedIrbis.Readers;

using MoonSharp.Interpreter;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Timer = System.Windows.Forms.Timer;

#endregion

// ReSharper disable StringLiteralTypo

namespace WriteOffER
{
    public partial class OffPanel
        : UniversalCentralControl
    {
        #region Properties

        /// <summary>
        /// Busy state controller.
        /// </summary>
        [NotNull]
        public BusyController Controller =>
            MainForm
                .ThrowIfNull("MainForm")
                .Controller
                .ThrowIfNull("MainForm.Controller");

        public SpreadsheetControl Spreadsheet { get; set; }

        [NotNull]
        public IIrbisConnection Connection => GetConnection();

        private Worksheet _worksheet;
        private int _currentRow;

        public int CurrentRow => _currentRow;

        private ToolStripComboBox _prefixBox;

        #endregion

        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        // ReSharper disable NotNullMemberIsNotInitialized
        protected OffPanel()
            // ReSharper restore NotNullMemberIsNotInitialized
            : base(null)
        {
            // Constructor for WinForms Designer only.
        }

        public OffPanel
            (
                MainForm mainForm
            )
            : base(mainForm)
        {
            InitializeComponent();

            _toolStrip = new ToolStrip
            {
                Dock = DockStyle.Top
            };
            Controls.Add(_toolStrip);
            _prefixBox = new ToolStripComboBox()
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Items =
                {
                    new PrefixInfo{Prefix="NS=", Description = "Карточка комплектования"},
                    new PrefixInfo{Prefix="IN=", Description = "Инвентарный номер"},
                    new PrefixInfo{Prefix="NKSU=", Description = "Номер КСУ"}
                },
                SelectedIndex = 0
            };
            _toolStrip.Items.Add(_prefixBox);
            var clearButton = new ToolStripButton("Очистить");
            clearButton.Click += ClearButtonOnClick;
            _toolStrip.Items.Add(clearButton);
            var goButton = new ToolStripButton("Рассчивать");
            goButton.Click += GoButtonOnClick;
            _toolStrip.Items.Add(goButton);
            var saveButton = new ToolStripButton("Сохранить");
            saveButton.Click += SaveButtonOnClick;
            _toolStrip.Items.Add(saveButton);
            var loadButton = new ToolStripButton("Загрузить");
            loadButton.Click += LoadButtonOnClick;
            _toolStrip.Items.Add(loadButton);

            Spreadsheet = new SpreadsheetControl
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(Spreadsheet);
            ClearTable();
        }

        private void LoadButtonOnClick(object sender, EventArgs e)
        {
            Spreadsheet.LoadDocument(this);
            SetupTable();
        }

        private void SaveButtonOnClick(object sender, EventArgs e)
        {
            Spreadsheet.SaveDocumentAs(this);
        }

        private void GoButtonOnClick(object sender, EventArgs e)
        {
            Run(ProcessTable);
        }

        private void ClearButtonOnClick(object sender, EventArgs e)
        {
            ClearTable();
        }

        #endregion

        #region Private members

        private ToolStrip _toolStrip;

        [NotNull]
        private IIrbisConnection GetConnection()
        {
            UniversalForm mainForm = MainForm.ThrowIfNull("MainForm");
            mainForm.GetIrbisProvider();
            IIrbisConnection result = mainForm.Connection
                .ThrowIfNull("connection");

            return result;
        }

        private void SetupTable()
        {
            _worksheet = Spreadsheet.ActiveWorksheet;
            _currentRow = 6;
        }

        #endregion

        #region Public methods

        public void ClearTable()
        {
            byte[] template = Properties.Resources.Template;
            Spreadsheet.LoadDocument(template, DocumentFormat.Xlsx);
            SetupTable();
        }

        [NotNull]
        public Row CurrentLine()
        {
            return _worksheet.Rows[_currentRow];
        }

        [NotNull]
        public Cell WriteCell(int column, string text)
        {
            Cell result = null;
            Spreadsheet.InvokeIfRequired(() =>
            {
                result = _worksheet.Cells[_currentRow, column];
                result.Value = text;
            });

            return result;
        }

        [NotNull]
        public Cell WriteCell(int column, int value)
        {
            Cell result = null;
            Spreadsheet.InvokeIfRequired(() =>
            {
                result = _worksheet.Cells[_currentRow, column];
                result.Value = value;
            });

            return result;
        }

        [NotNull]
        public Cell WriteCell(int column, double value, string format)
        {
            Cell result = null;
            Spreadsheet.InvokeIfRequired(() =>
            {
                result = _worksheet.Cells[_currentRow, column];
                result.Value = value;
                result.NumberFormat = format;
            });

            return result;
        }

        [NotNull]
        public Cell WriteCell(int column, decimal value, string format)
        {
            Cell result = null;
            Spreadsheet.InvokeIfRequired(() =>
            {
                result = _worksheet.Cells[_currentRow, column];
                result.Value = (double)value;
                result.NumberFormat = format;
            });

            return result;
        }

        [CanBeNull]
        public string ReadCell(int column)
        {
            Cell cell = _worksheet.Cells[_currentRow, column];
            string result = cell.Value.ToString();
            if (!string.IsNullOrEmpty(result))
            {
                result = result.Trim();
            }

            return result;
        }

        [NotNull]
        public string CellReference(int row, int column)
        {
            Cell cell = _worksheet.Cells[row, column];
            string result = Spreadsheet.Document.DocumentSettings.R1C1ReferenceStyle
                ? cell.GetReferenceR1C1(ReferenceElement.ColumnAbsolute|ReferenceElement.RowAbsolute, cell)
                : cell.GetReferenceA1();

            return result;
        }

        [NotNull]
        public string CellReference(int column)
        {
            return CellReference(_currentRow, column);
        }

        [NotNull]
        public Cell SetFormula(int column, string formula)
        {
            Cell result = _worksheet.Cells[_currentRow, column];
            //result.Formula = formula;
            result.FormulaInvariant = formula;

            return result;
        }

        [NotNull]
        public Row WriteTableLine
            (
                string format,
                params object[] args
            )
        {
            WriteCell(0, string.Format(format, args));
            var result = CurrentLine();
            NewLine();

            return result;
        }


        public void SetupBorder(Border border)
        {
            border.Color = Color.Black;
            border.LineStyle = BorderLineStyle.Thin;
        }

        public void SetupBorders(Cell cell)
        {
            SetupBorder(cell.Borders.BottomBorder);
            SetupBorder(cell.Borders.TopBorder);
            SetupBorder(cell.Borders.LeftBorder);
            SetupBorder(cell.Borders.RightBorder);
        }

        public void BeautifyCell(Cell cell)
        {
            Invoke(() =>
            {
                cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                SetupBorders(cell);
            });
        }
        public void BeautifyCell(int column)
        {
            Invoke(() =>
            {
                Cell cell = _worksheet.Cells[_currentRow, column];
                BeautifyCell(cell);
            });
        }

        [NotNull]
        public OffPanel Invoke
            (
                [NotNull] MethodInvoker action
            )
        {
            Spreadsheet.InvokeIfRequired(action);

            return this;
        }

        public void NewLine()
        {
            _currentRow++;
        }

        public Range GetRange(int column, int topRow, int bottomRow)
        {
            return _worksheet.Range.FromLTRB(column, topRow, column, bottomRow);
        }

        public void ProcessTable()
        {
            PrefixInfo prefix = null;
            Invoke(() =>
            {
                prefix = _prefixBox.SelectedItem as PrefixInfo;
            });
            if (ReferenceEquals(prefix, null))
            {
                return;
            }

            SetupTable();
            OffManager manager = new OffManager(Output, Connection, prefix);

            int startRow = CurrentRow;
            int index = 1;
            while (true)
            {
                string number = ReadCell(1);
                if (string.IsNullOrEmpty(number))
                {
                    break;
                }

                int amount = ReadCell(6).SafeToInt32();
                if (amount <= 0)
                {
                    break;
                }

                WriteCell(0, index);
                OffInfo info = manager.GetInfo(number);
                if (!ReferenceEquals(info, null))
                {
                    Cell descriptionCell = WriteCell(2, info.Description);
                    WriteCell(3, info.Year);
                    WriteCell(4, info.Price, "0.00");
                    WriteCell(5, info.Coefficient, "0.00");

                    string formula = CellReference(4) + "*"
                                     + CellReference(5) + "*"
                                     + CellReference(6);
                    Invoke(() =>
                    {
                        descriptionCell.Alignment.WrapText = true;
                        SetupBorders(descriptionCell);
                        SetFormula(7, formula);
                        Row row = descriptionCell.Worksheet.Rows[descriptionCell.RowIndex];
                        row.AutoFit();
                        BeautifyCell(0);
                        BeautifyCell(1);
                        BeautifyCell(3);
                        BeautifyCell(4);
                        BeautifyCell(5);
                        BeautifyCell(6);
                        BeautifyCell(7);
                    });
                }

                NewLine();
                index++;
            }

            int endRow = CurrentRow - 1;
            if (endRow > startRow)
            {
                Invoke(() =>
                {
                    string topCell = CellReference(startRow, 6);
                    string bottomCell = CellReference(endRow, 6);
                    Cell sumCell = _worksheet.Cells[_currentRow, 6];
                    sumCell.FormulaInvariant = "SUM(" + topCell + ":" + bottomCell + ")";
                    sumCell.Font.Bold = true;
                    BeautifyCell(sumCell);
                });

            }

        }

        #endregion
    }
}
