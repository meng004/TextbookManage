using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookManage.Domain;
using TextbookManage.Domain.Models;

namespace TextbookManage.Domain.Test
{
    [TestClass]
    public class SchoolYearTermTest
    {
        [TestMethod]
        public void CompartTo_YearGreater()
        {
            var right = new SchoolYearTerm("2013-2014-1");
            var left = new SchoolYearTerm("2014-2015-2");
            Assert.AreEqual(1, left.CompareTo(right));
        }

        [TestMethod]
        public void CompareTo_YearSmaller()
        {
            var right = new SchoolYearTerm("2013-2014-1");
            var left = new SchoolYearTerm("2012-2013-2");
            Assert.AreEqual(-1, left.CompareTo(right));
        }

        [TestMethod]
        public void CompareTo_TermGreater()
        {
            var right = new SchoolYearTerm("2013-2014-1");
            var left = new SchoolYearTerm("2013-2014-2");
            Assert.AreEqual(1, left.CompareTo(right));
        }

        [TestMethod]
        public void CompareTo_TermSmaller()
        {
            var right = new SchoolYearTerm("2013-2014-2");
            var left = new SchoolYearTerm("2013-2014-1");
            Assert.AreEqual(-1, left.CompareTo(right));
        }

        [TestMethod]
        public void CompareTo_Equal()
        {
            var left = new SchoolYearTerm("2013-2014-1");
            var right = new SchoolYearTerm("2013-2014-1");
            Assert.AreEqual(0, left.CompareTo(right));
        }

        [TestMethod]
        public void Operator_Equal()
        {
            var left = new SchoolYearTerm("2013-2014-1");
            var right = new SchoolYearTerm("2013-2014-1");
            Assert.IsTrue(left == right);
        }

        [TestMethod]
        public void Operator_NotEqual()
        {
            var left = new SchoolYearTerm("2013-2014-1");
            var right = new SchoolYearTerm("2013-2014-2");
            Assert.IsTrue(left != right);
        }

        [TestMethod]
        public void Operator_Greater()
        {
            var left = new SchoolYearTerm("2013-2014-1");
            var right = new SchoolYearTerm("2013-2014-2");
            Assert.IsTrue(left < right);
        }

        [TestMethod]
        public void Operator_Smaller()
        {
            var left = new SchoolYearTerm("2013-2014-1");
            var right = new SchoolYearTerm("2013-2014-2");
            Assert.IsFalse(left > right);
        }

        [TestMethod]
        public void ObjectCompartTo_YearGreater()
        {
            var right = new SchoolYearTerm("2013-2014-1");
            var left = new SchoolYearTerm("2014-2015-2");
            Assert.AreEqual(1, left.CompareTo(right as object));
        }

        [TestMethod]
        public void ObjectCompareTo_YearSmaller()
        {
            var right = new SchoolYearTerm("2013-2014-1");
            var left = new SchoolYearTerm("2012-2013-2");
            Assert.AreEqual(-1, left.CompareTo(right as object));
        }

        [TestMethod]
        public void ObjectCompareTo_TermGreater()
        {
            var right = new SchoolYearTerm("2013-2014-1");
            var left = new SchoolYearTerm("2013-2014-2");
            Assert.AreEqual(1, left.CompareTo(right as object));
        }

        [TestMethod]
        public void ObjectCompareTo_TermSmaller()
        {
            var right = new SchoolYearTerm("2013-2014-2");
            var left = new SchoolYearTerm("2013-2014-1");
            Assert.AreEqual(-1, left.CompareTo(right as object));
        }

        [TestMethod]
        public void ObjectCompareTo_Equal()
        {
            var left = new SchoolYearTerm("2013-2014-1");
            var right = new SchoolYearTerm("2013-2014-1");
            Assert.AreEqual(0, left.CompareTo(right as object));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "YearTerm等于null，使用前应初始化")]
        public void ObjectCompareTo_RightNotInitialized()
        {
            var left = new SchoolYearTerm("2013-2014-2");
            SchoolYearTerm right = new SchoolYearTerm();
            left.CompareTo(right as object);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "对象等于Null，应初始化")]
        public void ObjectCompareTo_RightIsNull()
        {
            var left = new SchoolYearTerm("2013-2014-2");
            SchoolYearTerm right = null;
            left.CompareTo(right as object);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "对象等于Null，应初始化")]
        public void ObjectCompareTo_LeftIsNull()
        {
            var right = new SchoolYearTerm("2013-2014-2");
            SchoolYearTerm left = null;
            left.CompareTo(right as object);
        }
    }
}
