﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* MainForm.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Windows.Forms;

using AM;
using AM.Configuration;
using AM.Logging;
using AM.Net;
using AM.Windows.Forms;

using ManagedIrbis;
using ManagedIrbis.Readers;

using Newtonsoft.Json.Linq;

#endregion

// ReSharper disable StringLiteralTypo
// ReSharper disable LocalizableElement
// ReSharper disable HeapView.BoxingAllocation
// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.ObjectAllocation.Evident
// ReSharper disable SuggestVarOrType_BuiltInTypes
// ReSharper disable SuggestVarOrType_SimpleTypes
// ReSharper disable SuggestVarOrType_Elsewhere

namespace OsmiRegistration
{
    /// <summary>
    ///
    /// </summary>
    public partial class MainForm
        : Form
    {
        #region Construction

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Private members

        private void _Clear()
        {
            _browser.Navigate("about:blank");
        }

        private void MainForm_FormClosing
            (
                object sender,
                FormClosingEventArgs e
            )
        {
            ControlCenter.WriteLine("Shutdown");
        }

        private bool CheckConfiguration()
        {
            while (true)
            {
                if (ControlCenter.CheckConfiguration())
                {
                    break;
                }

                var rc = MessageBox.Show
                        (
                            "Программа не сконфигурирована! Будете конфигурировать?",
                            "Регистрация карт",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Error
                        );
                if (rc == DialogResult.Yes)
                {
                    Program.Configure(this);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private void MainForm_Load
            (
                object sender,
                EventArgs e
            )
        {
            _browser.Navigate("about:blank");
            while (_browser.IsBusy)
            {
                Application.DoEvents();
            }
            Application.DoEvents();

            this.ShowVersionInfoInTitle();
            _logBox.Output.PrintSystemInformation();

            if (!CheckConfiguration())
            {
                Environment.Exit(1);
            }

            try
            {
                ControlCenter.Initialize(_logBox.Output);
            }
            catch (Exception exception)
            {
                Log.TraceException("MainForm::Load", exception);
                ExceptionBox.Show(this, exception);
                Application.Exit();
            }

            try
            {
                ControlCenter.Ping();
            }
            catch (Exception exception)
            {
                Log.TraceException("MainForm::Load", exception);
                //ExceptionBox.Show(this, exception);
                //Application.Exit();

                ControlCenter.WriteLine
                    (
                        "\r\nОШИБКА: {0}: {1}",
                        exception.GetType().Name,
                        exception.Message
                    );
                ControlCenter.WriteLine(string.Empty);
                ControlCenter.WriteLine("\r\nПРОВЕРЬТЕ КОНФИГУРАЦИЮ!");
                ControlCenter.WriteLine(string.Empty);
                return;
            }

            ControlCenter.WriteLine("Ready");
            ControlCenter.WriteLine(string.Empty);
        }

        private ReaderInfo _PrepareReader()
        {
            _Clear();

            string ticket = _ticketBox.Text.Trim();
            if (string.IsNullOrEmpty(ticket))
            {
                MessageBox.Show("Не задан читательский!");
                return null;
            }

            ReaderInfo reader = ControlCenter.GetReader(ticket);
            if (ReferenceEquals(reader, null))
            {
                MessageBox.Show("Не найден читатель с указанным билетом!");
                return null;
            }

            string description = ControlCenter.FormatReader(reader);
            bool chk = ControlCenter.CheckReader(reader);
            bool exist = ControlCenter.CardExists(ticket);

            _browser.DocumentText = "<html>"
                + (exist ?
                    "<p><b><font color='red'>Карта уже существует!</font></b></p>"
                    : string.Empty
                  )
                + description
                + "</html>";

            return !chk
                ? null
                : reader;
        }

        private void _searchButton_Click
            (
                object sender,
                EventArgs e
            )
        {
            try
            {
                _PrepareReader();
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(this, exception);
            }
        }

        private void _createButton_Click
            (
                object sender,
                EventArgs e
            )
        {
            try
            {
                ReaderInfo reader = _PrepareReader();
                if (ReferenceEquals(reader, null))
                {
                    return;
                }

                string ticket = (reader.PassCard ?? reader.Ticket)
                    .ThrowIfNull("ticket");
                if (ControlCenter.CardExists(ticket))
                {
                    MessageBox.Show("Карта уже существует");
                    return;
                }

                JObject card = ControlCenter.BuildCard(reader);
                ControlCenter.CreateCard
                    (
                        ticket,
                        card
                    );
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(this, exception);
            }
        }

        private void _sendEmailButton_Click
            (
                object sender,
                EventArgs e
            )
        {
            try
            {
                ReaderInfo reader = _PrepareReader();
                if (ReferenceEquals(reader, null))
                {
                    return;
                }

                string email = _emailBox.Text.Trim();
                if (!string.IsNullOrEmpty(email))
                {
                    if (!MailUtility.VerifyEmail(email))
                    {
                        MessageBox.Show("Неверный email");
                        return;
                    }

                    MarcRecord record = reader.Record
                        .ThrowIfNull("reader.Record");
                    string[] emails = record.FMA(32);
                    if (!emails.ContainsNoCase(email))
                    {
                        record.AddField(32, email);
                        ControlCenter.UpdateRecord(record);
                        ControlCenter.WriteLine
                            (
                                "Добавлен email: {0}",
                                email
                            );
                    }
                }

                string ticket = (reader.PassCard ?? reader.Ticket)
                    .ThrowIfNull("ticket");
                if (!ControlCenter.CardExists(ticket))
                {
                    MessageBox.Show("Карты не существует");
                    return;
                }

                ControlCenter.SendEmail(reader);
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(this, exception);
            }
        }

        private void _sendSmsButton_Click
            (
                object sender,
                EventArgs e
            )
        {
            try
            {
                ReaderInfo reader = _PrepareReader();
                if (ReferenceEquals(reader, null))
                {
                    return;
                }

                string ticket = (reader.PassCard ?? reader.Ticket)
                    .ThrowIfNull("ticket");
                if (!ControlCenter.CardExists(ticket))
                {
                    MessageBox.Show("Карты не существует");
                    return;
                }

                string phoneNumber = reader.HomePhone;
                if (string.IsNullOrEmpty(phoneNumber))
                {
                    MessageBox.Show("Не задан телефон!");
                    return;
                }

                ControlCenter.SendSms(reader);
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(this, exception);
            }
        }

        private void _deleteButton_Click
            (
                object sender,
                EventArgs e
            )
        {
            try
            {
                ReaderInfo reader = _PrepareReader();
                if (ReferenceEquals(reader, null))
                {
                    return;
                }

                string ticket = (reader.PassCard?? reader.Ticket)
                    .ThrowIfNull("ticket");
                if (!ControlCenter.CardExists(ticket))
                {
                    MessageBox.Show("Карты не существует");
                    return;
                }

                ControlCenter.DeleteCard(reader);
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(this, exception);
            }
        }

        private void _clearButton_Click
            (
                object sender,
                EventArgs e
            )
        {
            _ticketBox.Clear();
            _Clear();
        }

        private void _configButton_Click
            (
                object sender,
                EventArgs e
            )
        {
            string password1 = ConfigurationUtility.GetString
                (
                    "password",
                    string.Empty
                );

            if (!string.IsNullOrEmpty(password1))
            {

                string password2 = string.Empty;
                InputBox.PasswordChar = '*';
                var rc = InputBox.Query
                    (
                        "Конфигурация системы",
                        "Введите пароль",
                        "Для изменения конфигурации необходимо ввести пароль",
                        ref password2
                    );
                if (rc != DialogResult.OK)
                {
                    return;
                }

                if (password1 != password2)
                {
                    MessageBox.Show
                        (
                            "Введен неверный пароль!",
                            "Конфигурация системы",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    return;
                }

                Program.Configure(this);
            }
        }

        #endregion
    }
}
