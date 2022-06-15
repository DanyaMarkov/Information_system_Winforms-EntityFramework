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
    public partial class EditUser : Form
    {


        public string userEmail;

        MyDbContext db;
        public EditUser()
        {
            InitializeComponent();
        }

        private void saveNewInfo_Click(object sender, EventArgs e)
        {
            MyDbContext db = new MyDbContext();

            string email = inputEmail.Text;
            string name = inputName.Text;
            string surname = inputSurname.Text;
            string office = inputOffice.Text;
            string password = inputEmail.Text;


            int checkAdd = 0;

            var users = db.Users;
            var offices = db.Offices;
            var officeID = 0;

            string inputRole = "";

            if (inputEmail.Text != "" && inputName.Text != "" && inputSurname.Text != "" && inputOffice.Text != "" && inputEmail.Text != "")
            {
                //Проверка на наличие такого же Email в БД
                foreach (var i in users)
                {
                    if (i.Email == inputEmail.Text && i.Email != userEmail)
                    {
                        checkAdd = 1;
                    }
                }
                //Узнаем ID выбранного офиса
                foreach (var i in offices)
                {
                    if (i.Title == inputOffice.Text)
                    {
                        officeID = i.ID;
                    }
                }

                if (radioButton1.Checked == true)
                {
                    inputRole = radioButton1.Text;
                } else
                {
                    inputRole = radioButton2.Text;
                }
                var roleID = db.Roles.FirstOrDefault(u => u.Title == inputRole).ID;

                if (checkAdd == 0)
                {
                    MessageBox.Show("Информация о пользователе обновлена!");

                    var context = new MyDbContext();

                    var currentUser = context.Users.FirstOrDefault(user => user.Email == userEmail);

                    currentUser.RoleID = roleID;
                    currentUser.Email = inputEmail.Text;
                    currentUser.Firstname = inputName.Text;
                    currentUser.Lastname = inputSurname.Text;
                    currentUser.OfficeID = officeID;

                    context.SaveChanges();

                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже зарегистрирован!");
                }
            }
            else
            {
                MessageBox.Show("Заполните поля!");
            }

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
