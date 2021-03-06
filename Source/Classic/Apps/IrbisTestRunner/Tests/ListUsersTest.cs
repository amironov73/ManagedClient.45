﻿/* ListUsersTest.cs --
 * Ars Magna project, http://arsmagna.ru 
 */

#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AM;

using CodeJam;

using JetBrains.Annotations;

using ManagedIrbis;
using ManagedIrbis.Testing;

using Newtonsoft.Json;

#endregion

namespace IrbisTestRunner.Tests
{
    [TestClass]
    class ListUsersTest
        : AbstractTest
    {
        #region Properties

        #endregion

        #region Construction

        #endregion

        #region Private members

        #endregion

        #region Public methods

        [TestMethod]
        public void ListUsers_Test1()
        {
            UserInfo[] users = Connection.ListUsers();

            Write
                (
                    string.Join
                    (
                        ", ",
                        users.Select(u => u.Name).ToArray()
                    )
                );
        }

        #endregion
    }
}
