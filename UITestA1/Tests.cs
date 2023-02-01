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
            //when app started, find LogInPage title on Login Page
            AppResult[] results = app.WaitForElement(c => c.Marked("LogInPage"));            
            Assert.IsTrue(results.Any());
        }

        [Test]
        public void TestRegistrationPageDisplayed()
        {
            //on Login Page, click RegisterNow link to open Registration Page
            app.Tap("txtRegisterNow");
            AppResult[] results = app.WaitForElement(c => c.Marked("RegistrationPage"));
            Assert.IsTrue(results.Any());
        }

        [Test]
        public void TestDashboardDisplayed()
        {
            //login page enter email address and password, and click button login
            app.WaitForElement(c => c.Id("txtEmailPhoneLog"));
            app.EnterText(c => c.Id("txtEmailPhoneLog"), "keosophon8888@gmail.com");

            app.WaitForElement(c => c.Id("txtPassowrdLog"));
            app.EnterText(c => c.Id("txtPassowrdLog"), "hello123");            

            app.Tap("btnLogin");

            //on Dashboard page, find Dashboard Text
            AppResult[] results = app.WaitForElement(c => c.Id("txtDashBoard"));
            Assert.IsTrue(results.Any());
        }


        [Test]
        public void TestLogout()
        {
            //login page enter email address and password, and click button login
            app.WaitForElement(c => c.Id("txtEmailPhoneLog"));
            app.EnterText(c => c.Id("txtEmailPhoneLog"), "keosophon8888@gmail.com");

            app.WaitForElement(c => c.Id("txtPassowrdLog"));
            app.EnterText(c => c.Id("txtPassowrdLog"), "hello123");
            app.Tap("btnLogin");

            //on dahboard page, click Log Out to logout and go to login page
            app.Tap("txtLogOut");

            //on login page, find LoginPage Title
            AppResult[] results = app.WaitForElement(c => c.Marked("LogInPage"));
            Assert.IsTrue(results.Any());
        }

        [Test]
        public void TestProductPageDisplayed()
        {
            //login page enter email address and password, and click button login
            app.WaitForElement(c => c.Id("txtEmailPhoneLog"));
            app.EnterText(c => c.Id("txtEmailPhoneLog"), "keosophon8888@gmail.com");

            app.WaitForElement(c => c.Id("txtPassowrdLog"));
            app.EnterText(c => c.Id("txtPassowrdLog"), "hello123");
            app.Tap("btnLogin");

            //on dahboard page, click button Detail1 of Product1
            app.Tap("btnDetail1");

            //on product page view, find button BuyNow
            AppResult[] results = app.WaitForElement(c => c.Marked("btnBuyNow"));
            Assert.IsTrue(results.Any());
        }
    }
}
