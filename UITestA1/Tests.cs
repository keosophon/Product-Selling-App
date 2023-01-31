using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITestA1
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void LogIngPageDisplayed()
        {
            //app.Repl();
            AppResult[] results = app.WaitForElement(c => c.Marked("LogInPage"));

            //app.Screenshot("Sign In");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void TestRegistrationPageDisplayed()
        {
            //app.Repl();
            app.Tap("txtRegisterNow");
            AppResult[] results = app.WaitForElement(c => c.Marked("RegistrationPage"));
            Assert.IsTrue(results.Any());
        }
    }
}
