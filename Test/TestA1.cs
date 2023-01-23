using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using A1;

namespace Test
{
    [TestClass]
    class TestA1
    {
        private static readonly DBConnection _dbConnInstance1 = DBConnection.GetDBConnInstance();
        private static readonly DBConnection _dbConnInstance2 = DBConnection.GetDBConnInstance();

        [TestMethod]
        public void TestSingleTonPattern()
        {
            Assert.AreEqual(_dbConnInstance1, _dbConnInstance2);
        }
    }
}