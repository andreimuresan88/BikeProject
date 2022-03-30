using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BikeProject.PageModels
{
    class ProfilePage : BasePage
    {
        const string profilePageLabelSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.account-section.clearfix.col-lg-9.col-md-9.col-sm-12.col-xs-12 > div > h3";
        const string personalDataButtonSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.side-menu.col-lg-3.col-md-3.col-sm-12.col-xs-12 > div.row > ul:nth-child(4) > li:nth-child(2) > a";
        const string emailInputSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.account-section.clearfix.col-lg-9.col-md-9.col-sm-12.col-xs-12 > form > div:nth-child(1) > input";
        const string firstnameInputSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.account-section.clearfix.col-lg-9.col-md-9.col-sm-12.col-xs-12 > form > div:nth-child(3) > input";
        const string lastnameInputSelector =  "#wrapper > div.account-h.container-h.container-bg > div > div.account-section.clearfix.col-lg-9.col-md-9.col-sm-12.col-xs-12 > form > div:nth-child(2) > input";
        const string phoneInputSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.account-section.clearfix.col-lg-9.col-md-9.col-sm-12.col-xs-12 > form > div:nth-child(4) > input";
        const string saveButtonSelector = "#doSave";
        string errorInputMessageSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.account-section.clearfix.col-lg-9.col-md-9.col-sm-12.col-xs-12 > p";
        string confUpdateTextSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.account-section.clearfix.col-lg-9.col-md-9.col-sm-12.col-xs-12 > div.succes.center.mrg-b-20";
        string changePasswordLabelSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.account-section.clearfix.col-lg-9.col-md-9.col-sm-12.col-xs-12 > div > h3";
        const string changePasswordLinkSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.side-menu.col-lg-3.col-md-3.col-sm-12.col-xs-12 > div.row > ul:nth-child(4) > li:nth-child(3) > a";
        const string oldPasswordInputSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.account-section.clearfix.col-lg-9.col-md-9.col-sm-12.col-xs-12 > form > div:nth-child(1) > input";
        const string newPasswordInputSelector = "__newPassword";
        const string confirmPasswordInputSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.account-section.clearfix.col-lg-9.col-md-9.col-sm-12.col-xs-12 > form > div:nth-child(3) > input";
        
        string errorInputChangePasswordMessageSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.account-section.clearfix.col-lg-9.col-md-9.col-sm-12.col-xs-12 > p";
        string labelChangeConfPasswordMessageSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.account-section.clearfix.col-lg-9.col-md-9.col-sm-12.col-xs-12 > form > div:nth-child(3) > label";
        string labelChangeOldPasswordMessageSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.account-section.clearfix.col-lg-9.col-md-9.col-sm-12.col-xs-12 > form > div:nth-child(1) > label";
        string labelChangeNewPasswordMessageSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.account-section.clearfix.col-lg-9.col-md-9.col-sm-12.col-xs-12 > form > div:nth-child(2) > label";
        string emailLabelSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.account-section.clearfix.col-lg-9.col-md-9.col-sm-12.col-xs-12 > form > div:nth-child(1) > label";
        string firstnameLabelSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.account-section.clearfix.col-lg-9.col-md-9.col-sm-12.col-xs-12 > form > div:nth-child(3) > label";
        string lastnameLabelSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.account-section.clearfix.col-lg-9.col-md-9.col-sm-12.col-xs-12 > form > div:nth-child(2) > label";
        string phoneLabelSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.account-section.clearfix.col-lg-9.col-md-9.col-sm-12.col-xs-12 > form > div:nth-child(4) > label";

        public ProfilePage(IWebDriver driver) : base(driver)
        {

        }
        public string ErrorInputChangePasswordMessageSelector { get => errorInputChangePasswordMessageSelector; set => errorInputChangePasswordMessageSelector = value; }
        public string LabelChangeConfPasswordMessageSelector { get => labelChangeConfPasswordMessageSelector; set => labelChangeConfPasswordMessageSelector = value; }
        public string LabelChangeOldPasswordMessageSelector { get => labelChangeOldPasswordMessageSelector; set => labelChangeOldPasswordMessageSelector = value; }
        public string LabelChangeNewPasswordMessageSelector { get => labelChangeNewPasswordMessageSelector; set => labelChangeNewPasswordMessageSelector = value; }
        public string EmailLabelSelector { get => emailLabelSelector; set => emailLabelSelector = value; }
        public string FirstnameLabelSelector { get => firstnameLabelSelector; set => firstnameLabelSelector = value; }
        public string LastnameLabelSelector { get => lastnameLabelSelector; set => lastnameLabelSelector = value; }
        public string PhoneLabelSelector { get => phoneLabelSelector; set => phoneLabelSelector = value; }
        public string ConfUpdateTextSelector { get => confUpdateTextSelector; set => confUpdateTextSelector = value; }
        public string ChangePasswordLabelSelector { get => changePasswordLabelSelector; set => changePasswordLabelSelector = value; }
        public string ErrorInputMessageSelector { get => errorInputMessageSelector; set => errorInputMessageSelector = value; }

        public void UpdateProfile(string email, string firstname, string lastname, string phone)
        {
            var personalDataButtonElement = driver.FindElement(By.CssSelector(personalDataButtonSelector));
            personalDataButtonElement.Click();

            var emailInputElement = driver.FindElement(By.CssSelector(emailInputSelector));
            emailInputElement.Clear();
            emailInputElement.SendKeys(email);

            var firstnameElement = driver.FindElement(By.CssSelector(firstnameInputSelector));
            firstnameElement.Clear();
            firstnameElement.SendKeys(firstname);

            var lastnameInputElement = driver.FindElement(By.CssSelector(lastnameInputSelector));
            lastnameInputElement.Clear();
            lastnameInputElement.SendKeys(lastname);

            var phoneInputElement = driver.FindElement(By.CssSelector(phoneInputSelector));
            phoneInputElement.Clear();
            phoneInputElement.SendKeys(phone);

            var saveButtonElement = driver.FindElement(By.CssSelector(saveButtonSelector));
            saveButtonElement.Submit();
        }

/*        public string UpdateProfileErrorText()
        {
            var errorInputMessageElement = driver.FindElement(By.CssSelector(ErrorInputMessageSelector));
            return errorInputMessageElement.Text;
        }*/

/*        public string UpdateProfileText()
        {
            var confUpdateTextElement = driver.FindElement(By.CssSelector(ConfUpdateTextSelector));
            return confUpdateTextElement.Text;
        }*/

/*        public string GetEmailLabelColor()
        {
            var emailLabelElement = driver.FindElement(By.CssSelector(EmailLabelSelector)).GetCssValue("color");
            return emailLabelElement;
        }*/

/*        public string GetFirstnameLabelColor()
        {
            var firstnameLabelElement = driver.FindElement(By.CssSelector(FirstnameLabelSelector)).GetCssValue("color");
            return firstnameLabelElement;
        }*/

/*        public string GetLastnameLabelColor()
        {
            var lastnameLabelElement = driver.FindElement(By.CssSelector(LastnameLabelSelector)).GetCssValue("color");
            return lastnameLabelElement;
        }*/

/*        public string GetPhoneLabelColor()
        {
            var phoneLabelElement = driver.FindElement(By.CssSelector(PhoneLabelSelector)).GetCssValue("color");
            return phoneLabelElement;
        }*/

/*        public string ChangePasswordLabelText()
        {
            var changePasswordLabelElement = driver.FindElement(By.CssSelector(ChangePasswordLabelSelector));
            return changePasswordLabelElement.Text;
        }*/

/*        public string ChangePasswordErrorText()
        {
            var errorInputChangePasswordMessageElement = driver.FindElement(By.CssSelector(ErrorInputChangePasswordMessageSelector));
            return errorInputChangePasswordMessageElement.Text;
        }*/

/*        public string ChangeConfPasswordErrorColor()
        {
            var errorInputChangeConfPasswordMessageElement = driver.FindElement(By.CssSelector(LabelChangeConfPasswordMessageSelector)).GetCssValue("color");
            return errorInputChangeConfPasswordMessageElement;
        }*/

/*        public string ChangeOldPasswordErrorColor()
        {
            var errorInputChangeOldPasswordMessageElement = driver.FindElement(By.CssSelector(LabelChangeOldPasswordMessageSelector)).GetCssValue("color");
            return errorInputChangeOldPasswordMessageElement;
        }*/

/*        public string ChangeNewPasswordErrorColor()
        {
            var errorInputChangeNewPasswordMessageElement = driver.FindElement(By.CssSelector(LabelChangeNewPasswordMessageSelector)).GetCssValue("color");
            return errorInputChangeNewPasswordMessageElement;
        }*/

        public string GetEmptyField(string email, string firstname, string lastname, string phone)
        {
            if(email == "")
            {
                return EmailLabelSelector;
            } 
            if (firstname == "")
            {
                return FirstnameLabelSelector;
            }
            if(lastname == "")
            {
                return LastnameLabelSelector;
            }
            return PhoneLabelSelector;
        }

        public string GetInvalidField(string newEmail, string newFirstname, string newLastname, string newPhone, string invalidField)
        {
            if (newEmail == invalidField)
            {
                return EmailLabelSelector;
            }
            if (newFirstname == invalidField)
            {
                return FirstnameLabelSelector;
            }
            if (newLastname == invalidField)
            {
                return LastnameLabelSelector;
            }
            return PhoneLabelSelector;
        }

        public void ChangePassword(string oldPassword, string newPassword, string confirmPassword)
        {
            var changePasswordLinkElement = driver.FindElement(By.CssSelector(changePasswordLinkSelector));
            changePasswordLinkElement.Click();

            var oldPasswordInputElement = driver.FindElement(By.CssSelector(oldPasswordInputSelector));
            oldPasswordInputElement.Clear();
            oldPasswordInputElement.SendKeys(oldPassword);

            var newPasswordInputElement = driver.FindElement(By.Id(newPasswordInputSelector));
            newPasswordInputElement.Clear();
            newPasswordInputElement.SendKeys(newPassword);

            var confirmPasswordInputElement = driver.FindElement(By.CssSelector(confirmPasswordInputSelector));
            confirmPasswordInputElement.Clear();
            confirmPasswordInputElement.SendKeys(confirmPassword);

            var saveButtonElement = driver.FindElement(By.CssSelector(saveButtonSelector));
            saveButtonElement.Submit();
        }

        public string GetInvalidFieldChangePassword(string oldPassword, string newPassword, string confirmPassword, string invalidData)
        {
            if(oldPassword == "" || oldPassword == invalidData)
            {
                return labelChangeOldPasswordMessageSelector;
            }
            if(newPassword == "" || newPassword == invalidData)
            {
                return labelChangeNewPasswordMessageSelector;
            }
            return labelChangeConfPasswordMessageSelector;
        }
    }
}
