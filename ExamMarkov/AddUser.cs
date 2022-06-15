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
    public partial class AddUser : Form
    {

        MyDbContext db;
        public AddUser()
        {
            InitializeComponent();

            db = new MyDbContext();

            var context = new MyDbContext();

            FillComboBox();
        }

        public void FillComboBox()
        {
            db = new MyDbContext();

            var offices = db.Offices;

            foreach (var i in offices)
            {
                inputOffice.Items.Add(i.Title);
            }
        }

        private void saveNewUser_Click(object sender, EventArgs e)
        {
            MyDbContext db = new MyDbContext();

            //string email = inputEmail.Text;
            //string name = inputName.Text;
            //string surname = inputSurname.Text;
            //string office = inputOffice.Text;
            //DateTime date = inputDate.Value;
            //string password = inputEmail.Text;

            int checkAdd = 0;

            var users = db.Users;
            var offices = db.Offices;
            var officeID = 0;

            if (inputEmail.Text != "" && inputName.Text != "" && inputSurname.Text != "" && inputOffice.Text != "" && inputEmail.Text != "")
            {
                //Проверка на наличие такого же Email в БД
                foreach (var i in users)
                {
                    if (i.Email == inputEmail.Text)
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

                if (checkAdd == 0)
                {
                    MessageBox.Show("Новый пользователь успешно добавлен!");

                    //Добавляем нового пользователя в БД
                    var context = new MyDbContext();

                    var user = new User()
                    {
                        RoleID = 2,
                        Email = inputEmail.Text,
                        Password = inputPassword.Text,
                        Firstname = inputName.Text,
                        Lastname = inputSurname.Text,
                        OfficeID = officeID,
                        //OfficeID = inputOffice.Text,
                        Birthdate = inputDate.Value,
                        Active = true
                    };

                    context.Users.Add(user);
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
