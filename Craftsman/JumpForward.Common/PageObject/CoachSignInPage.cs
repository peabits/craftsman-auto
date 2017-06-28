﻿using Craftsman.Core.Factory;
using Craftsman.Core.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.PageObject
{
    public class CoachSignInPage : PageObjectBase
    {
        public CoachSignInPage(IWebDriver driver) : base(driver)
        {
            WaitSelector.WaitingFor_ElementExists(this.Driver, By.Id("ContentPlaceHolder1_txtUsername"));
        }
        #region Page elements
        [FindsBy(How = How.Id, Using = "ContentPlaceHolder1_txtUsername")]
        protected IWebElement txtUserName;

        [FindsBy(How = How.Id, Using = "ContentPlaceHolder1_txtPassword")]
        protected IWebElement txtPassword;

        [FindsBy(How = How.XPath, Using = ".//input[@value='Sign In']")]
        protected IWebElement btnSignIn;

        #endregion Page elements

        #region Action for test case
        /// <summary>
        /// Sign In for Dashboard
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        public DatabaseProspectsPage SignIn(string userName, string password)
        {
            this.txtUserName.Clear();
            this.txtPassword.Clear();

            this.txtUserName.SendKeys(userName);
            this.txtPassword.SendKeys(password);

            this.btnSignIn.Click();
            WaitSelector.WaitingFor_InvisibilityOfElementLocated(this.Driver, By.Id("grid-loader-holder"));
            
            return new DatabaseProspectsPage(this.Driver);
        }

        /// <summary>
        /// Compliance login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ComplianceHomePage ComplianceSignIn(string userName, string password)
        {
            this.txtUserName.Clear();
            this.txtPassword.Clear();

            this.txtUserName.SendKeys(userName);
            this.txtPassword.SendKeys(password);

            this.btnSignIn.Click();
            //WebElementKeeper.WaitingFor_InvisibilityOfElementLocated(this.Driver, By.Id("grid-loader-holder"));
            return new ComplianceHomePage(this.Driver);
        }
        #endregion
    }
}
