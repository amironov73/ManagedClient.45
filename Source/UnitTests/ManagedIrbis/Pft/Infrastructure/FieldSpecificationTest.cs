﻿using ManagedIrbis.Pft;
using ManagedIrbis.Pft.Infrastructure;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.ManagedIrbis.Pft.Infrastructure
{
    [TestClass]
    public class FieldSpecificationTest
    {
        [TestMethod]
        public void FieldSpecification_Construction_1()
        {
            FieldSpecification specification = new FieldSpecification();

            Assert.AreEqual('\0', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.None, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('\0', specification.SubField);
            Assert.AreEqual(0, specification.Tag);
            Assert.AreEqual(null, specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_1()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v200^a"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.None, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200^a", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_1a()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v200 \r\n^a"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.None, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200 \r\n^a", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_2()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v200"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.None, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('\0', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_2a()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v200\r\n"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.None, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('\0', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200\r\n", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_3()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(false, specification.Parse("200^a"));
        }

        [TestMethod]
        public void FieldSpecification_Parse_3a()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(false, specification.Parse("va^a"));
        }

        [TestMethod]
        [ExpectedException(typeof(PftSyntaxException))]
        public void FieldSpecification_Parse_3b()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(false, specification.Parse("v200@^a"));
        }

        [TestMethod]
        [ExpectedException(typeof(PftSyntaxException))]
        public void FieldSpecification_Parse_3c()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(false, specification.Parse("v200^я"));
        }


        [TestMethod]
        public void FieldSpecification_Parse_4()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v461@200"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual("200", specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.None, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('\0', specification.SubField);
            Assert.AreEqual(461, specification.Tag);
            Assert.AreEqual("v461@200", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_4a()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v461 @ 200"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual("200", specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.None, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('\0', specification.SubField);
            Assert.AreEqual(461, specification.Tag);
            Assert.AreEqual("v461 @ 200", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_5()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v200[2]^a[3]"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.Literal, specification.FieldRepeat.Kind);
            Assert.AreEqual(2, specification.FieldRepeat.Literal);
            Assert.AreEqual(IndexKind.Literal, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(3, specification.SubFieldRepeat.Literal);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200[2]^a[3]", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_5a()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v200 [ 2 ] ^a [ 3 ]"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.Literal, specification.FieldRepeat.Kind);
            Assert.AreEqual(2, specification.FieldRepeat.Literal);
            Assert.AreEqual(IndexKind.Literal, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(3, specification.SubFieldRepeat.Literal);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200 [ 2 ] ^a [ 3 ]", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_5b()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v200[2]^a[3] "));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.Literal, specification.FieldRepeat.Kind);
            Assert.AreEqual(2, specification.FieldRepeat.Literal);
            Assert.AreEqual(IndexKind.Literal, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(3, specification.SubFieldRepeat.Literal);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200[2]^a[3] ", specification.RawText);
        }

        [TestMethod]
        [ExpectedException(typeof(PftSyntaxException))]
        public void FieldSpecification_Parse_5c()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(false, specification.Parse("v200[2"));
        }

        [TestMethod]
        [ExpectedException(typeof(PftSyntaxException))]
        public void FieldSpecification_Parse_5d()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(false, specification.Parse("v200^a[2"));
        }

        [TestMethod]
        public void FieldSpecification_Parse_6()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v200^a[2]"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.Literal, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(2, specification.SubFieldRepeat.Literal);
            Assert.AreEqual(0, specification.FieldRepeat.Literal);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200^a[2]", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_6a()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("d200^a[2]"));
            Assert.AreEqual('d', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.Literal, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(2, specification.SubFieldRepeat.Literal);
            Assert.AreEqual(0, specification.FieldRepeat.Literal);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("d200^a[2]", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_6b()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("n200^a[2]"));
            Assert.AreEqual('n', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.Literal, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(2, specification.SubFieldRepeat.Literal);
            Assert.AreEqual(0, specification.FieldRepeat.Literal);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("n200^a[2]", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_6c()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("g200^a[2]"));
            Assert.AreEqual('g', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.Literal, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(2, specification.SubFieldRepeat.Literal);
            Assert.AreEqual(0, specification.FieldRepeat.Literal);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("g200^a[2]", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_7()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v200^a[*]"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.LastRepeat, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200^a[*]", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_8()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v200^a[+]"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.NewRepeat, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200^a[+]", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_9()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v200^a*5"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.None, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(5, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200^a*5", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_9a()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v200^a * 5"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.None, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(5, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200^a * 5", specification.RawText);
        }

        [TestMethod]
        [ExpectedException(typeof(PftSyntaxException))]
        public void FieldSpecification_Parse_9b()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(false, specification.Parse("v200^a*"));
        }

        [TestMethod]
        public void FieldSpecification_Parse_10()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v200^a.5"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.None, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(5, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200^a.5", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_10a()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v200^a . 5"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.None, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(5, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200^a . 5", specification.RawText);
        }

        [TestMethod]
        [ExpectedException(typeof(PftSyntaxException))]
        public void FieldSpecification_Parse_10b()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(false, specification.Parse("v200^a.c"));
        }

        [TestMethod]
        public void FieldSpecification_Parse_11()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v200^a*5.5"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.None, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(5, specification.Offset);
            Assert.AreEqual(5, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200^a*5.5", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_11a()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v200^a * 5 . 5"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.None, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(5, specification.Offset);
            Assert.AreEqual(5, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200^a * 5 . 5", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_12()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v200^a(10)"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(10, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.None, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200^a(10)", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_12a()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v200^a ( 10)"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(10, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.None, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200^a ( 10)", specification.RawText);
        }

        [TestMethod]
        [ExpectedException(typeof(PftSyntaxException))]
        public void FieldSpecification_Parse_12b()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(false, specification.Parse("v200^a()"));
        }

        [TestMethod]
        [ExpectedException(typeof(PftSyntaxException))]
        public void FieldSpecification_Parse_12c()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(false, specification.Parse("v200^a(x)"));
        }

        [TestMethod]
        public void FieldSpecification_Parse_13()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v200[$x+1]^a"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.Expression, specification.FieldRepeat.Kind);
            Assert.AreEqual("$x+1", specification.FieldRepeat.Expression);
            Assert.AreEqual(IndexKind.None, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200[$x+1]^a", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_14()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v461@200[2]^a[3]*4.5(6)"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual("200", specification.Embedded);
            Assert.AreEqual(6, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.Literal, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.Literal, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(2, specification.FieldRepeat.Literal);
            Assert.AreEqual(3, specification.SubFieldRepeat.Literal);
            Assert.AreEqual(4, specification.Offset);
            Assert.AreEqual(5, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(461, specification.Tag);
            Assert.AreEqual("v461@200[2]^a[3]*4.5(6)", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_Parse_14a()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.Parse("v461 @ 200 [ 2 ] ^a [ 3 ] * 4 . 5 ( 6)"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual("200", specification.Embedded);
            Assert.AreEqual(6, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.Literal, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.Literal, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(2, specification.FieldRepeat.Literal);
            Assert.AreEqual(3, specification.SubFieldRepeat.Literal);
            Assert.AreEqual(4, specification.Offset);
            Assert.AreEqual(5, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(461, specification.Tag);
            Assert.AreEqual("v461 @ 200 [ 2 ] ^a [ 3 ] * 4 . 5 ( 6)", specification.RawText);
        }

        [TestMethod]
        [ExpectedException(typeof(PftSyntaxException))]
        public void FieldSpecification_Parse_15()
        {
            FieldSpecification specification = new FieldSpecification();
            specification.Parse("v200^");
        }

        [TestMethod]
        [ExpectedException(typeof(PftSyntaxException))]
        public void FieldSpecification_Parse_16()
        {
            FieldSpecification specification = new FieldSpecification();
            specification.Parse("v200^a[]");
        }

        [TestMethod]
        [ExpectedException(typeof(PftSyntaxException))]
        public void FieldSpecification_Parse_17()
        {
            FieldSpecification specification = new FieldSpecification();
            specification.Parse("v200^a*");
        }

        [TestMethod]
        [ExpectedException(typeof(PftSyntaxException))]
        public void FieldSpecification_Parse_18()
        {
            FieldSpecification specification = new FieldSpecification();
            specification.Parse("v200^a.5*5");
        }

        [TestMethod]
        public void FieldSpecification_ParseShort_1()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.ParseShort("v200^a"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.None, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200^a", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_ParseShort_1a()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.ParseShort("g200^a"));
            Assert.AreEqual('g', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.None, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('a', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("g200^a", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_ParseShort_1b()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(false, specification.ParseShort("d200^a"));
        }

        [TestMethod]
        public void FieldSpecification_ParseShort_1c()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(false, specification.ParseShort("n200^a"));
        }

        [TestMethod]
        public void FieldSpecification_ParseShort_2()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(true, specification.ParseShort("v200"));
            Assert.AreEqual('v', specification.Command);
            Assert.AreEqual(null, specification.Embedded);
            Assert.AreEqual(0, specification.ParagraphIndent);
            Assert.AreEqual(IndexKind.None, specification.FieldRepeat.Kind);
            Assert.AreEqual(IndexKind.None, specification.SubFieldRepeat.Kind);
            Assert.AreEqual(0, specification.Offset);
            Assert.AreEqual(0, specification.Length);
            Assert.AreEqual('\0', specification.SubField);
            Assert.AreEqual(200, specification.Tag);
            Assert.AreEqual("v200", specification.RawText);
        }

        [TestMethod]
        public void FieldSpecification_ParseShort_3()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(false, specification.ParseShort("200^a"));
        }

        [TestMethod]
        public void FieldSpecification_ParseShort_4()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(false, specification.ParseShort("va^a"));
        }

        [TestMethod]
        [ExpectedException(typeof(PftSyntaxException))]
        public void FieldSpecification_ParseShort_5()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(false, specification.ParseShort("v200^"));
        }

        [TestMethod]
        [ExpectedException(typeof(PftSyntaxException))]
        public void FieldSpecification_ParseShort_5a()
        {
            FieldSpecification specification = new FieldSpecification();
            Assert.AreEqual(false, specification.ParseShort("v200^я"));
        }
    }
}
