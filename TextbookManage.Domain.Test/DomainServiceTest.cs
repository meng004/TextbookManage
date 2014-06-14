using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookManage.Domain;
using TextbookManage.Domain.Models;

namespace TextbookManage.Domain.Test
{
    [TestClass]
    public class DomainServiceTest
    {
        [TestMethod]
        public void SchoolYearTerm_YearGreater()
        {
            var right = new SchoolYearTerm("2013-2014-1");
            var left = new SchoolYearTerm("2014-2015-2");
            Assert.AreEqual(1, left.CompareTo(right));
        }

        [TestMethod]
        public void SchoolYearTerm_YearSmaller()
        {
            var left = new SchoolYearTerm("2013-2014-1");
            var right = new SchoolYearTerm("2012-2013-2");
            Assert.AreEqual(-1, left.CompareTo(right));
        }

        [TestMethod]
        public void SchoolYearTerm_TermGreater()
        {
            var left = new SchoolYearTerm("2013-2014-1");
            var right = new SchoolYearTerm("2013-2014-2");
            Assert.AreEqual(1, left.CompareTo(right));
        }

        [TestMethod]
        public void SchoolYearTerm_TermSmaller()
        {
            var left = new SchoolYearTerm("2013-2014-2");
            var right = new SchoolYearTerm("2013-2014-1");
            Assert.AreEqual(-1, left.CompareTo(right));
        }

        [TestMethod]
        public void SchoolYearTerm_Equal()
        {
            var left = new SchoolYearTerm("2013-2014-1");
            var right = new SchoolYearTerm("2013-2014-1");
            Assert.AreEqual(0, left.CompareTo(right));
        }

        [TestMethod]
        public void SchoolYearTerm_OperatorEqual()
        {
            var left = new SchoolYearTerm("2013-2014-1");
            var right = new SchoolYearTerm("2013-2014-1");
            Assert.IsTrue(left == right);
        }

        [TestMethod]
        public void SchoolYearTerm_OperatorNotEqual()
        {
            var left = new SchoolYearTerm("2013-2014-1");
            var right = new SchoolYearTerm("2013-2014-2");
            Assert.IsTrue(left != right);
        }

        [TestMethod]
        public void SchoolYearTerm_OperatorGreater()
        {
            var left = new SchoolYearTerm("2013-2014-1");
            var right = new SchoolYearTerm("2013-2014-2");
            Assert.IsTrue(left < right);
        }

        [TestMethod]
        public void SchoolYearTerm_OperatorSmaller()
        {
            var left = new SchoolYearTerm("2013-2014-1");
            var right = new SchoolYearTerm("2013-2014-2");
            Assert.IsFalse(left > right);
        }
    }
}
