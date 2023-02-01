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
            AppResult[] results = app.WaitForElement(c => c.Marked("LogInPage"));
            //app.Screenshot("Sign In");
            Assert.IsTrue(results.Any());
        }

        [Test]
        public void TestRegistrationPageDisplayed()
        {
            app.Tap("txtRegisterNow");
            AppResult[] results = app.WaitForElement(c => c.Marked("RegistrationPage"));
            Assert.IsTrue(results.Any());
        }

        [Test]
        public void TestDashboardDisplayed()
        {
            app.WaitForElement(c => c.Id("txtEmailPhoneLog"));
            app.EnterText(c => c.Id("txtEmailPhoneLog"), "keosophon8888@gmail.com");

            app.WaitForElement(c => c.Id("txtPassowrdLog"));
            app.EnterText(c => c.Id("txtPassowrdLog"), "hello123");            

            app.Tap("btnLogin");
            AppResult[] results = app.WaitForElement(c => c.Id("txtDashBoard"));
            Assert.IsTrue(results.Any());
        }


        [Test]
        public void TestLogout()
        {
            app.WaitForElement(c => c.Id("txtEmailPhoneLog"));
            app.EnterText(c => c.Id("txtEmailPhoneLog"), "keosophon8888@gmail.com");

            app.WaitForElement(c => c.Id("txtPassowrdLog"));
            app.EnterText(c => c.Id("txtPassowrdLog"), "hello123");

            app.Tap("btnLogin");
            app.Tap("txtLogOut");
            AppResult[] results = app.WaitForElement(c => c.Marked("LogInPage"));
            Assert.IsTrue(results.Any());
        }

        [Test]
        public void TestProductPageDisplayed()
        {
            app.WaitForElement(c => c.Id("txtEmailPhoneLog"));
            app.EnterText(c => c.Id("txtEmailPhoneLog"), "keosophon8888@gmail.com");

            app.WaitForElement(c => c.Id("txtPassowrdLog"));
            app.EnterText(c => c.Id("txtPassowrdLog"), "hello123");

            app.Tap("btnLogin");
            app.Tap("btnDetail1");
            AppResult[] results = app.WaitForElement(c => c.Marked("btnBuyNow"));
            Assert.IsTrue(results.Any());
        }
    }
}
