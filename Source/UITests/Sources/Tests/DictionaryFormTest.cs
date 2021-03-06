﻿/* DictionaryFormTest.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System.Windows.Forms;

using IrbisUI;

using ManagedIrbis;

#endregion

// ReSharper disable LocalizableElement

namespace UITests
{
    public sealed class DictionaryFormTest
        : IUITest
    {
        #region IUITest members

        public void Run
            (
                IWin32Window ownerWindow
            )
        {
            using (IrbisConnection connection = new IrbisConnection())
            {
                connection.ParseConnectionString
                    (
                        "host=127.0.0.1;port=6666;"
                        + "user=1;password=1;db=IBIS;"
                    );
                connection.Connect();

                TermAdapter adapter = new TermAdapter(connection, "K=");
                adapter.Fill();

                using (DictionaryForm form = new DictionaryForm(adapter))
                {
                    if (form.ShowDialog(ownerWindow) == DialogResult.OK)
                    {
                        string chosenTerm = form.ChosenTerm;
                        MessageBox.Show("Chosen: " + chosenTerm);
                    }
                }
            }
        }

        #endregion
    }
}
