using System;
using System.Windows.Forms;
using GitHubLogRecord.Injectors;
using GitHubLogRecord.Services;
using GitHubLogRecord.Models;

namespace GitHubLogRecord.Forms
{
    public partial class Form1 : Form
    {
        private Credentials _credential;
        private GitHubMethod _methods;
        public Form1() {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e) => scrapeLogsProcess();

        private void scrapeLogsProcess() {
            initiateCredentials();
            initiateMethods();
            getCredentials();
            if (isSignInSuccess()) {
                scrapeLogsPage();
            }
            else {
                MessageBox.Show("Log in failed. Please check your credentials.");
            }
        }

        private void scrapeLogsPage() {
            _methods.scrape();
        }

        private bool isSignInSuccess() {
            try {
                _methods.signIn(_credential);
                return true;
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        private void initiateCredentials() {
            _credential = new Credentials();
        }

        private void initiateMethods() {
            _methods = new GitHubMethod(new GitHub());
        }

        private void getCredentials() {
            _credential.email = txtEmail.Text;
            _credential.password = txtPassword.Text;
        }
    }
}
