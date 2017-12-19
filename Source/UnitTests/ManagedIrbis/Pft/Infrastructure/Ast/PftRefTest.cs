﻿using AM.Text;

using JetBrains.Annotations;

using ManagedIrbis;
using ManagedIrbis.Client;
using ManagedIrbis.Pft.Infrastructure;
using ManagedIrbis.Pft.Infrastructure.Ast;
using ManagedIrbis.Pft.Infrastructure.Compiler;
using ManagedIrbis.Pft.Infrastructure.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.ManagedIrbis.Pft.Infrastructure.Ast
{
    [TestClass]
    public class PftRefTest
    {
        private void _Execute
            (
                [NotNull] PftRef node,
                [NotNull] string expected
            )
        {
            PftContext context = new PftContext(null);
            node.Execute(context);
            string actual = context.Text.DosToUnix();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PftRef_Construction_1()
        {
            PftRef node = new PftRef();
            Assert.IsFalse(node.ConstantExpression);
            Assert.IsTrue(node.RequiresConnection);
        }

        [TestMethod]
        public void PftRef_Construction_2()
        {
            PftToken token = new PftToken(PftTokenKind.Ref, 1, 1, "");
            PftRef node = new PftRef(token);
            Assert.IsFalse(node.ConstantExpression);
            Assert.IsTrue(node.RequiresConnection);
            Assert.AreEqual(token.Column, node.Column);
            Assert.AreEqual(token.Line, node.LineNumber);
            Assert.AreEqual(token.Text, node.Text);
        }

        [TestMethod]
        public void PftRef_Execute_1()
        {
            PftRef node = new PftRef();
            _Execute(node, "");
        }

        [TestMethod]
        public void PftRef_ToString_1()
        {
            PftRef node = new PftRef();
            Assert.AreEqual("ref(,)", node.ToString());
        }
    }
}