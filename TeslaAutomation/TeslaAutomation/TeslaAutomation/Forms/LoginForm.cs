using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OpenQA.Selenium.Chrome;
using System.Threading;
using TeslaAutomation.Common;

namespace TeslaAutomation.Forms
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        private ChromeDriver driver;
        private ChromeOptions options;
        private ChromeDriverService driverService;

        public LoginForm()
        {
            InitializeComponent();

            driverService = ChromeDriverService.CreateDefaultService(Application.StartupPath);
            options = new ChromeOptions();
            //options.AddArguments("disable-infobars");
            options.AddArguments("--start-maximized");
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalCapability("useAutomationExtension", false);
            //options.AddExtensions(@"\path\to\extension.crx");
            //options.AddArgument("--headless");
            driverService.HideCommandPromptWindow = true;
        }

        private bool IsFormValidated(SimpleButton clickedButton)
        {
            if (String.IsNullOrEmpty(TeUsername.Text))
            {
                XtraMessageBox.Show("Please Enter Username");
                TeUsername.Focus();
                clickedButton.Enabled = true;
                return false;
            }

            if (String.IsNullOrEmpty(TePassword.Text))
            {
                XtraMessageBox.Show("Please Enter Password");
                TePassword.Focus();
                clickedButton.Enabled = true;
                return false;
            }
            return true;
        }

        private void SbLogin_Click(object sender, EventArgs e)
        {
            if (!NetConfiguration.PingTest())
            {
                XtraMessageBox.Show("Please connect to internet.");
                SbLogin.Focus();
                return;
            }

            SbLogin.Enabled = false;
            if (IsFormValidated(SbLogin))
            {
                if (BwLogin.IsBusy)
                    BwLogin.CancelAsync();
                else
                    BwLogin.RunWorkerAsync();
                PpWait.Show();
            }
        }

        private void TeUsername_Enter(object sender, EventArgs e)
        {
            TeUsername.BackColor = Color.LightYellow;
        }

        private void TeUsername_Leave(object sender, EventArgs e)
        {
            TeUsername.BackColor = Color.White;
        }

        private void TePassword_Enter(object sender, EventArgs e)
        {
            TePassword.BackColor = Color.LightYellow;
        }

        private void TePassword_Leave(object sender, EventArgs e)
        {
            TePassword.BackColor = Color.White;
        }

        private void CbShowHide_CheckedChanged(object sender, EventArgs e)
        {
            if (CbShowHide.Checked)
            {
                CbShowHide.ImageOptions.Image = Properties.Resources.icons8_eye_16;
                TePassword.Properties.PasswordChar = '\0';
            }
            else
            {
                CbShowHide.ImageOptions.Image = Properties.Resources.icons8_hide_16;
                TePassword.Properties.PasswordChar = '*';
            }
        }

        private void BwLogin_DoWork(object sender, DoWorkEventArgs e)
        {
            if (BwLogin.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            if (driver == null)
                driver = new ChromeDriver(driverService, options);
            driver.Navigate().GoToUrl("https://shop.tesla.com/");
            //driver.Navigate().GoToUrl("https://shop.tesla.com/login?checkoutFlow=false");
            //driver.Navigate().GoToUrl("https://auth.tesla.com/oauth2/v1/authorize?response_type=code&client_id=shop&redirect_uri=https%3A%2F%2Fshop.tesla.com%2Foauth-response.json%3Freferrer%3Dhttps%253A%252F%252Fshop.tesla.com%252F%253Ftesla_logged_in%253DY%26cortexscope%3DTESLA_US&scope=openid+email+employee&state=befb83d5d221d446bbc86c84fb2cdac4aa36b0049b59a5773fe60048cc2a990a&audience=https%3A%2F%2Fshop.tesla.com%2F&prompt=yes&locale=en-US");
            Thread.Sleep(5000);

            var signIn = driver.FindElementByXPath("//a[@href='?signIn=true']");
            signIn.Click();
            Thread.Sleep(5000);

            var email = driver.FindElementById("email");
            email.SendKeys(TeUsername.Text);
            Thread.Sleep(5000);

            var continueButton = driver.FindElementByXPath("//button[@type='submit']");
            if (BwLogin.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            continueButton.Click();
            Thread.Sleep(5000);

            var password = driver.FindElementByXPath("//input[@type='password']");
            password.SendKeys(TePassword.Text);
            Thread.Sleep(5000);

            var signInButton = driver.FindElementByXPath("//button[@type='submit']");
            if (BwLogin.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            signInButton.Click();
            Thread.Sleep(10000);

            e.Result = true;
        }

        private void BwLogin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                BwLogin.RunWorkerAsync();
                return;
            }

            if (e.Error != null)
            {
                PpWait.Hide();
                SbLogin.Enabled = true;
                XtraMessageBox.Show(e.Error.Message);
                return;
            }

            if ((bool)e.Result)
            {
                TeslaForm teslaForm = new TeslaForm(driver);
                teslaForm.Show();
                this.Hide();
                PpWait.Hide();
                SbLogin.Enabled = true;
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (driver != null)
                driver.Quit();
            Application.Exit();
        }
    }
}