﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WorkWave.TA.TestEngine.PageFactory;
using WorkWave.TA.TestEngine;
using OpenQA.Selenium.Interactions;
using System.Threading;
using NUnit.Framework;
using System.Reflection;

namespace WorkWave.PestPac.TA.Model
{
    class OpportunityPage : IWebPage
    {
        #region PageFactory

        #region Bulk reopen close opportunities

        [FindsBy(How = How.XPath, Using = "(//p[text()='Opportunities'])[2]")]
        private IWebElement ClickOpportunitiesLink { get { return PageFactory.Load(this); } }

        [FindsBy(How = How.XPath, Using = "//p[text()='Opportunities']")]
        private IWebElement PageHeader { get { return PageFactory.Load(this); } }

        [FindsBy(How = How.XPath, Using = "(//*[local-name()='svg' and @class='MuiSvgIcon-root MuiSvgIcon-fontSizeSmall']/*[local-name()='path'])[2]")]
        private IWebElement ClickListviewButton { get { return PageFactory.Load(this); } }

        [FindsBy(How = How.XPath, Using = "(//input[@type='checkbox'])[2]/..")]
        private IWebElement ClickFirstOpportunitiesCheckbox { get { return PageFactory.Load(this); } }

        [FindsBy(How = How.XPath, Using = "(//input[@type='checkbox'])[3]")]
        private IWebElement ClickSecondOpportunitiesCheckbox { get { return PageFactory.Load(this); } }

        [FindsBy(How = How.XPath, Using = "//span[text()='Re-Open']")]
        private IWebElement ClickBulkReopenButton { get { return PageFactory.Load(this); } }

        [FindsBy(How = How.XPath, Using = "//div[text()='Opportunity Status']")]
        private IWebElement OpportunitiesStatusExpandIcon { get { return PageFactory.Load(this); } }

        [FindsBy(How = How.XPath, Using = "//div[text()='Open']")]
        private IWebElement OpportunitiesStatusOpenField { get { return PageFactory.Load(this); } }

        [FindsBy(How = How.XPath, Using = "//li[text()='Closed']")]
        private IWebElement OpportunitiesStatusName { get { return PageFactory.Load(this); } }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Narrowed to Opportunities')]")]
        private IWebElement ClosedOpportunitiesDisplayed { get { return PageFactory.Load(this); } }

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Reopen')]")]
        private IWebElement ReopenPageIsDisplayed { get { return PageFactory.Load(this); } }

        #endregion  Bulk reopen close opportunities

        #region close lost opportunities

        [FindsBy(How = How.LinkText, Using = "View Detail Page")]
        private IWebElement ClickViewDetailsLink { get { return PageFactory.Load(this); } }

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Opportunity Detail Page')]")]
        private IWebElement OpportunityDetailPageIsDisplayed { get { return PageFactory.Load(this); } }

        [FindsBy(How = How.XPath, Using = "//div[text()='Closed Won / Closed Lost']")]
        private IWebElement ClickCloseLostExpandIcon { get { return PageFactory.Load(this); } }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Closed Lost...')]")]
        private IWebElement ClickCloseLostOption { get { return PageFactory.Load(this); } }

        [FindsBy(How = How.XPath, Using = "//span[text()='Lost to Competitor']")]
        private IWebElement ClickLostCompetitorRadioButton { get { return PageFactory.Load(this); } }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'SAVE')]/..")]
        private IWebElement ClickSaveButtonInCloseLostPopup { get { return PageFactory.Load(this); } }

       
        #endregion Close lost opportunities

        #endregion PageFactory
        private readonly string PageHeaderText = "Opportunities";

      
        public bool IsLoaded()
        {
            if (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(() => PageHeader),TimeSpan.FromSeconds(10)))
            {
                if (PageHeader.Text.TrimStart().StartsWith(PageHeaderText))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public void ClickonOpportunitiesLink()
        {
            try
            {
                if (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(() => ClickOpportunitiesLink)))
                {
                    ClickOpportunitiesLink.Click();
                    Thread.Sleep(5000);
                    SUT.Log.DebugFormat("Opportunities link is clicked");
                }
                else
                {
                    SUT.Log.ErrorFormat("Opportunities link is not clicked {0}", MethodBase.GetCurrentMethod().Name);
                }
            }
            catch (WebDriverTimeoutException)
            {
                SUT.Log.ErrorFormat("Opportunities link is not clicked");
            }
        }

        public void ClickonListViewButton()
        {
            try
            {
                if (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(() => ClickListviewButton)))
                {
                   
                    ClickListviewButton.Click();
                    SUT.Log.DebugFormat("List view button is clicked");
                }
                else
                {
                    SUT.Log.ErrorFormat("List view button is not clicked {0}", MethodBase.GetCurrentMethod().Name);
                }
            }
            catch (WebDriverTimeoutException)
            {
                SUT.Log.ErrorFormat("List view button is not clicked");
            }
        }

        public void IsClosedOpportunitiesDisplayed()
        {
            try
            {
                if (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(() => ClosedOpportunitiesDisplayed)))
                {
                    ClosedOpportunitiesDisplayed.Displayed.ToString();
                    SUT.Log.DebugFormat("Closed opportunities are displayed");
                }
                else
                {
                    SUT.Log.ErrorFormat("Closed opportunities are not displayed {0}", MethodBase.GetCurrentMethod().Name);
                }
            }
            catch (WebDriverTimeoutException)
            {
                SUT.Log.ErrorFormat("Closed opportunities are not displayed");
            }
        }

        public void SelecttheOpportunities()
        {
            try
            {
                if (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(() => ClickFirstOpportunitiesCheckbox)))
                {
                    ClickFirstOpportunitiesCheckbox.Click(); 
                    ClickSecondOpportunitiesCheckbox.Click();
                    SUT.Log.DebugFormat("Opportunities are selected");
                }
                else
                {
                    SUT.Log.ErrorFormat("Opportunities are not selected {0}", MethodBase.GetCurrentMethod().Name);
                }
            }
            catch (WebDriverTimeoutException)
            {
                SUT.Log.ErrorFormat("Opportunities are not selected");
            }
        }

        public void ClickOnBulkReopenButton()
        {
            try
            {
                if (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(() => ClickBulkReopenButton)))
                {
                    ClickBulkReopenButton.Click();
                    SUT.Log.DebugFormat("Bulk reopen button is clicked");
                }
                else
                {
                    SUT.Log.ErrorFormat("Bulk reopen button is not clicked {0}", MethodBase.GetCurrentMethod().Name);
                }
            }
            catch (WebDriverTimeoutException)
            {
                SUT.Log.ErrorFormat("Bulk reopen button is not clicked");
            }
        }

        public void SelectOpportunitiesStatus()
        {
            try
            {
                if (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(() => OpportunitiesStatusExpandIcon)))
                {
                    SalesCenterUtility.ScrollToElement(OpportunitiesStatusExpandIcon);
                    OpportunitiesStatusExpandIcon.Click();
                    Thread.Sleep(1000);
                    OpportunitiesStatusOpenField.Click();
                    OpportunitiesStatusName.Click();
                    SUT.Log.DebugFormat("Opportunties status is selected");
                }
                else
                {
                    SUT.Log.ErrorFormat("Opportunties status is not selected {0}", MethodBase.GetCurrentMethod().Name);
                }
            }
            catch (WebDriverTimeoutException)
            {
                SUT.Log.ErrorFormat("Opportunties status is not selected");
            }
        }

        public void IsReopenSliderDisplayed()
        {
            try
            {
                if (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(() => ReopenPageIsDisplayed), TimeSpan.FromSeconds(5)))
                {
                    ReopenPageIsDisplayed.Displayed.ToString();
                    Thread.Sleep(8000);
                    SUT.Log.DebugFormat("Reopen slider is diplayed");
                }
                else
                {
                    SUT.Log.ErrorFormat("Reopen slider is not diplayed {0}", MethodBase.GetCurrentMethod().Name);
                }
            }
            catch (WebDriverTimeoutException)
            {
                SUT.Log.ErrorFormat("Reopen slider is not diplayed");
            }
        }

        //Close lost opportunities

        public void ClickOnViewDetailsLink()
        {
            try
            {
                if (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(() => ClickViewDetailsLink)))
                {
                    ClickViewDetailsLink.Click();
                    SUT.Log.DebugFormat("View detail link is clicked");
                }
                else
                {
                    SUT.Log.ErrorFormat("View detail link is not clicked {0}", MethodBase.GetCurrentMethod().Name);
                }
            }
            catch (WebDriverTimeoutException)
            {
                SUT.Log.ErrorFormat("View detail link is not clicked");
            }
        }

        public void IsOpportunityDetailPageDisplayed()
        {
            try
            {
                if (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(() =>OpportunityDetailPageIsDisplayed), TimeSpan.FromSeconds(5)))
                {
                    OpportunityDetailPageIsDisplayed.Displayed.ToString();
                    Thread.Sleep(4000);
                    SUT.Log.DebugFormat("Reopen slider is diplayed");
                }
                else
                {
                    SUT.Log.ErrorFormat("Reopen slider is not diplayed {0}", MethodBase.GetCurrentMethod().Name);
                }
            }
            catch (WebDriverTimeoutException)
            {
                SUT.Log.ErrorFormat("Reopen slider is not diplayed");
            }
        }

        public void ClickOnCloseLostExpandIcon()
        {
            try
            {
                if (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(() => ClickCloseLostExpandIcon)))
                {
                    ClickCloseLostExpandIcon.Click();
                    Thread.Sleep(4000);
                    SUT.Log.DebugFormat("Closed Won/Close Lost expand icon is clicked");
                }
                else
                {
                    SUT.Log.ErrorFormat("Closed Won/Close Lost expand icon is clicked {0}", MethodBase.GetCurrentMethod().Name);
                }
            }
            catch (WebDriverTimeoutException)
            {
                SUT.Log.ErrorFormat("Closed Won/Close Lost expand icon is clicked");
            }
        }

        public void ClickOnCloseLostOption()
        {
            try
            {
                if (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsEnabled(() => ClickCloseLostOption)))
                {
                    ClickCloseLostOption.Click();
                    Thread.Sleep(3000);
                    SUT.Log.DebugFormat("Close lost option is clicked");
                }
                else
                {
                    SUT.Log.ErrorFormat("Close lost option is not clicked {0}", MethodBase.GetCurrentMethod().Name);
                }
            }
            catch (WebDriverTimeoutException)
            {
                SUT.Log.ErrorFormat("Close lost option is not clicked");
            }
        }

        public void IsSelectLostCompetitorRadioButton()
        {
            try
            {
                if (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(() => ClickLostCompetitorRadioButton)))
                {
                    ClickLostCompetitorRadioButton.Click();
                    Thread.Sleep(4000);
                    SUT.Log.DebugFormat("Lost competitor radio button is selected");
                }
                else
                {
                    SUT.Log.ErrorFormat("Lost competitor radio button is not selected {0}", MethodBase.GetCurrentMethod().Name);
                }
            }
            catch (WebDriverTimeoutException)
            {
                SUT.Log.ErrorFormat("Lost competitor radio button is not selected");
            }
        }

        public void ClickOnSaveButtonInCloseLostPopup()
        {
            try
            {
                if (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(() => ClickSaveButtonInCloseLostPopup)))
                {
                    ClickSaveButtonInCloseLostPopup.Click();
                    Thread.Sleep(3000);
                    SUT.Log.DebugFormat("Save button is clicked");
                }
                else
                {
                    SUT.Log.ErrorFormat("Save button is not clicked {0}", MethodBase.GetCurrentMethod().Name);
                }
            }
            catch (WebDriverTimeoutException)
            {
                SUT.Log.ErrorFormat("Save button is not clicked");
            }
        }

    }
}
