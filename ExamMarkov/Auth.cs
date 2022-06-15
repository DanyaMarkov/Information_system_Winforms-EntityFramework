using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Train
{
    public partial class Auth : Form
    {

        MyDbContext db;
        public Auth()
        {
            InitializeComponent();
            db = new MyDbContext();
        }

        string userEmail = "";
        string userPassword = "";
        int authcounter = 0;
        bool isFounded = false; 

        private void login_Click(object sender, EventArgs e)
        {
            MyDbContext db = new MyDbContext();
            var users = db.Users;

            userEmail = inputEmail.Text;
            userPassword = inputPassword.Text;
         

            if (userEmail != "" && userPassword != "")
            {
                isFounded = false;
                foreach (var i in users)
                {
                    if (i.Email == userEmail && i.Password == userPassword)
                    {
                        isFounded = true;
                        if (i.RoleID == 1)
                        {
                            if (i.Active == false)
                            {
                                MessageBox.Show("Вы заблокированы в системе!");
                            }
                            else
                            {
                                //MessageBox.Show("Админ вошёл систему!");
                                AdminPage formAdmin = new AdminPage(i.ID);
                                formAdmin.ShowDialog();
                            }
                        }
                        else if (i.RoleID == 2)
                        {
                            if (i.Active == false)
                            {
                                MessageBox.Show("Вы заблокированы в системе!");
                            }
                            else
                            {
                               //MessageBox.Show("Пользователь зашёл!");
                               UserPage formClient = new UserPage(i.ID);
                               formClient.helloLabel.Text = "Здравствуйте, " + i.Firstname + "!";
                              
                               formClient.ShowDialog();
                            }
                        }
                        break;
                    }
                }
                if (isFounded == false)
                {
                    MessageBox.Show("Неверный логин или пароль");
                    authcounter++;
                    if (authcounter > 3)
                    {
                        authcounter = 0;
                        authTimer.Start();
                        labelMessage.Visible = true;
                        labelTick.Visible = true;
                        login.Enabled = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните поля!");
            }
        }

        int authTick = 10;

        private void authTimer_Tick(object sender, EventArgs e)
        {
            if (authTick == 0)
            {
                authTimer.Stop();
                authTick = 10;
                labelMessage.Visible = false;
                labelTick.Visible = false;
                login.Enabled = true;

            }
            else
            {
                authTick--;
                labelTick.Text = authTick.ToString();

            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
