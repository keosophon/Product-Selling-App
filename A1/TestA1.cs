using Microsoft.VisualStudio.TestTools.UnitTesting;
using A1;

namespace A1
{
    [TestClass]
    public class TestA1
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