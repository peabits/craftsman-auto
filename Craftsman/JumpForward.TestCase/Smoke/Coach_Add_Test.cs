﻿using Craftsman.Core.Factory;
using Craftsman.Core.Fixture;
using JumpForward.Common;
using JumpForward.Common.Fixture;
using JumpForward.Common.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Linq;
using Xunit;

namespace JumpForward.TestCase.Smoke
{
    [Trait("Coach", "AddTest")]
    public class Coach_Add_Test : JumpForwardTestBase
    {
        public Coach_Add_Test(TestContextFixture context, JumpForwardServiceFixture service) : base(context, service) { }

        private const string cst_DisplayName = "BaseCheck.Add";

        [Fact(DisplayName = cst_DisplayName + ".Success")]
        public void Add_Success()
        {
            //Create manager & Navigate page to Login. 
            var signInPage = Router.GoTo<CoachSignInPage>();
            var comHomePage = signInPage.ComplianceSignIn("demicompliance@activenetwork.com", "active");

            var rosterHomePage = comHomePage.NavMenu.Select<RosterPage>("Roster", "Football", 18);
            var rosterCoachesPage = rosterHomePage.RedirectToCocahes();

            string firstName = "Clark";
            string lastName = "Peng";

            string guid = Guid.NewGuid().ToString().Substring(0, 5);
            string random = Convert.ToString(new Random().Next(1, 100));
            string emial = firstName + "." + lastName + guid + random + "@activetest.com";

            //var rosterHomePage = CraftsmanFactory.CreatePageObject<RosterPage>(manager.Driver);
            var rosterPage = rosterCoachesPage.AddNewCoach(firstName, lastName, emial);
            var rosterCoachesResultPage = rosterHomePage.RedirectToCocahes();
            rosterCoachesResultPage.FindCoachbyEmail(emial);

            rosterPage.Driver.Close();
        }
    }
}
