using A1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestA1
{
    [TestClass]
    public class UnitTest1
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
}
