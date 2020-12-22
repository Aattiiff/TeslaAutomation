using DevExpress.XtraEditors;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TeslaAutomation.Common;
using OpenQA.Selenium.Support.UI;


namespace TeslaAutomation.Forms
{
    public partial class TeslaForm : DevExpress.XtraEditors.XtraForm
    {
        private ChromeDriver driver;

        public TeslaForm(ChromeDriver driver)
        {
            InitializeComponent();
            this.driver = driver;
        }

        private void BwStart_DoWork(object sender, DoWorkEventArgs e)
        {
            if (BwStart.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            driver.Navigate().GoToUrl(TeURL.Text);
            Thread.Sleep(5000);

            js.ExecuteScript("window.scrollBy(0,100)");
            Thread.Sleep(5000);
            var view = driver.FindElementByXPath("//div[starts-with(@class,'desktop-view')]");

            var sizeDropdown = view.FindElements(By.XPath(".//select"));
            if (sizeDropdown.Count > 0)
            {
                var sizeElement = new SelectElement(sizeDropdown[0]);
                Thread.Sleep(1000);
                sizeElement.SelectByIndex(1);
                sizeDropdown[0].Click();
                Thread.Sleep(5000);
            }

            var color = view.FindElements(By.XPath(".//div[@class='product__container__details__color__items']/div/input"));
            if (color.Count > 0)
            {
                color[0].Click();
                Thread.Sleep(5000);
            }

            var size = view.FindElements(By.XPath(".//div[@class='product-form active']//input[@value != 'None']"));
            if (size.Count > 0)
            {
                size[0].Click();
                Thread.Sleep(5000);
            }

            var addToCart = view.FindElements(By.XPath(".//div[@class='product__container__details__buynow active']//input"));
            if (addToCart.Count > 0)
            {
                try
                {
                    addToCart[0].Click();
                    Thread.Sleep(5000);
                }
                catch
                {
                    XtraMessageBox.Show("Product out of stock");
                    e.Result = true;
                    return;
                }
            }

            var checkout = driver.FindElementByXPath("//a[starts-with(@class,'proceed')]");
            checkout.Click();
            Thread.Sleep(10000);
            js.ExecuteScript("window.scrollBy(0,500)");

            var firstName = driver.FindElementById("firstNameShipping");
            js.ExecuteScript("window.scrollBy(0,100)");
            Thread.Sleep(5000);
            firstName.SendKeys("Mark");
            Thread.Sleep(2000);

            var lastName = driver.FindElementById("lastNameShipping");
            js.ExecuteScript("window.scrollBy(0,100)");
            Thread.Sleep(5000);
            lastName.SendKeys("William");
            Thread.Sleep(2000);

            var address = driver.FindElementById("addressShipping");
            js.ExecuteScript("window.scrollBy(0,100)");
            Thread.Sleep(5000);
            address.SendKeys("Street #7, Parkinson Town");
            Thread.Sleep(2000);

            var line2 = driver.FindElementById("line2Shipping");
            js.ExecuteScript("window.scrollBy(0,100)");
            Thread.Sleep(5000);
            line2.SendKeys("Street #45, Bridge Town");
            Thread.Sleep(2000);

            var city = driver.FindElementById("cityShipping");
            js.ExecuteScript("window.scrollBy(0,100)");
            Thread.Sleep(5000);
            city.SendKeys("New York");
            Thread.Sleep(2000);

            var state = driver.FindElementByXPath("//select[@id='stateShipping']");
            var stateElement = new SelectElement(state);
            Thread.Sleep(1000);
            stateElement.SelectByIndex(5);
            state.Click();
            Thread.Sleep(5000);

            var zipCode = driver.FindElementById("zipCodeShipping");
            js.ExecuteScript("window.scrollBy(0,100)");
            Thread.Sleep(5000);
            zipCode.SendKeys("65000");
            Thread.Sleep(2000);

            var phoneNo = driver.FindElementById("phoneNumber");
            js.ExecuteScript("window.scrollBy(0,100)");
            Thread.Sleep(5000);
            phoneNo.SendKeys("7478887753");
            Thread.Sleep(2000);

            //var sameAddress = driver.FindElementByXPath("//label[@for='sameAddress']");
            //js.ExecuteScript("window.scrollBy(0,100)");
            //Thread.Sleep(5000);
            //sameAddress.Click();

            e.Result = true;
        }

        private void BwStart_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                BwStart.RunWorkerAsync();
                return;
            }

            if (e.Error != null)
            {
                PgrsPanel.Hide();
                SbStart.Enabled = true;
                XtraMessageBox.Show(e.Error.Message);
                return;
            }

            if ((bool)e.Result)
            {
                PgrsPanel.Hide();
                SbStart.Enabled = true;
                XtraMessageBox.Show("Automation completed.");
            }
        }

        private void SbStart_Click(object sender, EventArgs e)
        {
            if (!NetConfiguration.PingTest())
            {
                XtraMessageBox.Show("Please connect to internet.");
                SbStart.Focus();
                return;
            }

            if (string.IsNullOrEmpty(TeURL.Text))
            {
                XtraMessageBox.Show("Please enter URL.");
                TeURL.Focus();
                return;
            }

            SbStart.Enabled = false;
            if (BwStart.IsBusy)
                BwStart.CancelAsync();
            else
                BwStart.RunWorkerAsync();
            PgrsPanel.Show();
        }

        private void TeURL_Enter(object sender, EventArgs e)
        {
            TeURL.BackColor = Color.LightYellow;
        }

        private void TeURL_Leave(object sender, EventArgs e)
        {
            TeURL.BackColor = Color.White;
        }

        private void TeslaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (driver != null)
                driver.Quit();
            Application.Exit();
        }
    }
}
