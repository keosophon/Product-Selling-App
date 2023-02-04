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
        /// <summary>
        /// Automation UI Testing
        /// </summary>
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
        public void TestLogInPageDisplayed()
        {
            //test login page is displayed correctly
            //when app started, find LogInPage title on Login Page
            AppResult[] results = app.WaitForElement(c => c.Marked("LogInPage"));            
            Assert.IsTrue(results.Any());
        }

        [Test]
        public void TestRegistrationPageDisplayed()
        {
            //test registration page is displayed correctly
            //on Login Page, click RegisterNow link to open Registration Page
            app.Tap("txtRegisterNow");
            AppResult[] results = app.WaitForElement(c => c.Marked("RegistrationPage"));
            Assert.IsTrue(results.Any());
        }

        [Test]
        public void TestDashboardDisplayed()
        {
            //test Dashoboard page is displayed correclty after login
            //on login page, enter email address and password, and click button login
            app.WaitForElement(c => c.Id("txtEmailPhoneLog"));
            app.EnterText(c => c.Id("txtEmailPhoneLog"), "keosophon8888@gmail.com");

            app.WaitForElement(c => c.Id("txtPassowrdLog"));
            app.EnterText(c => c.Id("txtPassowrdLog"), "hello123");            

            app.Tap("btnLogin");

            //on Dashboard page, find element btnDetail1 on Dashboard page
            AppResult[] results = app.WaitForElement(c => c.Id("btnDetail1"));
            Assert.IsTrue(results.Any());
        }
        

        [Test]
        public void TestProductPageDisplayed()
        {
            //test product page is displayed correctly
            //on login page, enter email address and password, and click button login
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

        [Test]
        public void TestAddToCartPageDisplayed()
        {
            //test addToCart page is displayed correctly
            //on login page, enter email address and password, and click button login
            app.WaitForElement(c => c.Id("txtEmailPhoneLog"));
            app.EnterText(c => c.Id("txtEmailPhoneLog"), "keosophon8888@gmail.com");

            app.WaitForElement(c => c.Id("txtPassowrdLog"));
            app.EnterText(c => c.Id("txtPassowrdLog"), "hello123");
            app.Tap("btnLogin");

            //on dahboard page, click button Detail1 of Product1
            app.Tap("btnDetail1");

            //on product page view, find button BuyNow and tap it
            app.WaitForElement(c => c.Marked("btnBuyNow"));
            app.Tap("btnBuyNow");

            //after AddToCart page is displayed, find the button btnAddToCart on AddToCart page            
            AppResult[] results = app.WaitForElement(c => c.Marked("btnAddToCart"));
            Assert.IsTrue(results.Any());

        }

        [Test]
        public void TestPaymentPageIsDisplayed()
        {
            //test Payment Page is displayed
            //on login page, enter phone number and password of a customer, and tap button login
            app.WaitForElement(c => c.Id("txtEmailPhoneLog"));
            app.EnterText(c => c.Id("txtEmailPhoneLog"), "0216666666");

            app.WaitForElement(c => c.Id("txtPassowrdLog"));
            app.EnterText(c => c.Id("txtPassowrdLog"), "123456");
            app.Tap("btnLogin");

            //on dahboard page, click button Detail1 of Product1 to see its details
            app.WaitForElement(c => c.Id("btnDetail1"));
            app.Tap("btnDetail1");

            //on product page view, find button BuyNow and tap it
            app.WaitForElement(c => c.Id("btnBuyNow"));
            app.Tap("btnBuyNow");

            //after AddToCart page is displayed, find the button btnAddToCart on AddToCart page and tap it
            app.WaitForElement(c => c.Id("btnAddToCart"));
            app.Tap("btnAddToCart");

            //go back To Dashboard page
            app.Tap("txtDashBoard");

            //on dahboard page, click button Detail2 of Product2 to see details
            app.WaitForElement(c => c.Id("btnDetail2"));
            app.Tap("btnDetail2");

            //on product page view, find button BuyNow and tap it
            app.WaitForElement(c => c.Id("btnBuyNow"));
            app.Tap("btnBuyNow");

            //after AddToCart page is displayed, find the button btnAddToCart on AddToCart page and tap it
            app.WaitForElement(c => c.Id("btnAddToCart"));
            app.Tap("btnAddToCart");

            //find the button btnViewCart1 on AddToCart page and tap it
            app.WaitForElement(c => c.Id("btnViewCart1"));
            app.Tap("btnViewCart1");

            //find the button btnCheckOut on the payment page           
            AppResult[] results = app.WaitForElement(c => c.Id("btnCheckOut"));
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
    }
}
