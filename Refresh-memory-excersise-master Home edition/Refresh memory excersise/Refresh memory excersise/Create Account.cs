using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Refresh_memory_excersise
{
    public partial class frmCreateAccount : Form
    {
        string strGUserName;
        string strGPassWord;
        //Global variables;

        public frmCreateAccount(string strLUserName, string strLPassWord)
        {
            this.strGUserName = strLUserName;
            this.strGPassWord = strLPassWord;
            //Linking global variables;

            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string strUserName, strPassword, strFName, strLName, strBirthDate;
            //Creating variables;

            strFName = txtFirstName.Text.ToLower();
            //Converting all letters from txtFirstName to small letters;
            //Filling variable;
            strLName = txtSecondName.Text.ToLower();
            //Converting all letters from txtLastName to small letters;
            //Filling variable;
            strBirthDate = txtBirthDate.Text.Substring(8, 2) + txtBirthDate.Text.Substring(3, 2) + txtBirthDate.Text.Substring(0,2);
            //Taking specific parts of txtBirthDate;
            //filling variable;

            strUserName = strFName + "." + strLName;
            //Creating username;
            strPassword = strLName.Substring(0, 1) + strFName.Substring(0, 1) + strBirthDate + ".";
            //creating password;

            DialogResult dialogResult = MessageBox.Show("Je gebruikersnaam is " + strUserName + " en je wachtwoord is " + strPassword, "Inlog gegevens", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                Form Login = new frmLogin();
                Login.Show();

                Form C_A = new frmCreateAccount(strGUserName, strGPassWord);
                this.Close();
                //Giving the possibility to go to the next form;
            }
            //Showing username and password;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form Login = new frmLogin();
            Login.Show();

            Form C_A = new frmCreateAccount(strGUserName, strGPassWord);
            this.Close();
            //Going back to previous form;
        }

        private void btnShutDown_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bent u zeker dat u wilt afsluiten?", "Afsluiten", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
            //Asking to shut down application;
            //Shutting down application;
        }

        private void frmCreateAccount_Load(object sender, EventArgs e)
        {
            Timer Time = new Timer();

            Time.Interval = 1000;
            Time.Tick += new EventHandler(Time_Tick);
            Time.Start();
            //Creating timed ticks to drive the timer;
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            //showing Date and time;
        }
    }
}