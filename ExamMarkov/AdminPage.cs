using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Train
{
    public partial class AdminPage : Form
    {

        int currentUserID;

        string loginTime = "";

        int currentLogID;

        MyDbContext db;
        public AdminPage(int adminID)
        {
            InitializeComponent();
            db = new MyDbContext();

            var context = new MyDbContext();


            string h;
            if (DateTime.Now.Hour.ToString().Length < 2)
            {
                h = "0" + DateTime.Now.Hour.ToString();
            }
            else
            {
                h = DateTime.Now.Hour.ToString();
            }
            string m;
            if (DateTime.Now.Minute.ToString().Length < 2)
            {
                m = "0" + DateTime.Now.Minute.ToString();
            }
            else
            {
                m = DateTime.Now.Minute.ToString();
            }
            loginTime = h + ":" + m;


            currentUserID = adminID;
            //MessageBox.Show(currentUserID.ToString());

            inputOffice.SelectedIndex = 0;

            db.Users.Load();

            context.SaveChanges();

            FillComboBox();

            FillTable();

            CheckAdminActivity();

            FillAdminsTable();

            //AddColor();
        }

        bool existAdmin = false;
        public void CheckAdminActivity()
        {
            db = new MyDbContext();

            foreach (var log in db.Logs)
            {
                if ( currentUserID == log.UserID)
                {
                    existAdmin = true;
                    DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                    //////////////
                    var curLogWork = db.Logs.FirstOrDefault(l => l.UserID == currentUserID).ID;
                    currentLogID = curLogWork;
                    ///////////////

                    string h;
                    if (DateTime.Now.Hour.ToString().Length < 2)
                    {
                        h = "0" + DateTime.Now.Hour.ToString();
                    }
                    else
                    {
                        h = DateTime.Now.Hour.ToString();
                    }
                    string m;
                    if (DateTime.Now.Minute.ToString().Length < 2)
                    {
                        m = "0" + DateTime.Now.Minute.ToString();
                    }
                    else
                    {
                        m = DateTime.Now.Minute.ToString();
                    }

                    log.Date = DateTime.Now;
                    log.LoginTime = loginTime;
                    log.LogoutTime = h + ":" + m;
                    log.TimeSpent = 0;
                    log.IsCrash = true;

                    break;
                    //db.SaveChanges();
                } 

            }

            if (existAdmin == false)
            {
                DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                var curLogWork = db.Logs.FirstOrDefault(l => l.UserID == currentUserID);
                currentLogID = curLogWork.ID;

                var newLog = new Log()
                {
                    UserID = currentUserID,

                    Date = date,
                    LoginTime = loginTime,
                    //LogoutTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute,
                    //TimeSpent = currentSeconds,
                    Reason = "",
                    IsCrash = true

                };

                db.Logs.Add(newLog);
                //db.SaveChanges();

                currentLogID = curLogWork.ID;
            }
            db.SaveChanges();

        }

        //Заполняем список офисов
        public void FillComboBox()
        {
            db = new MyDbContext();

            var offices = db.Offices;

            foreach (var i in offices)
            {
                inputOffice.Items.Add(i.Title);
            }
        }

        //Заполняем таблицу пользователей
        public void FillTable()
        {

            while (dataGridView1.Rows.Count > 1)
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    dataGridView1.Rows.Remove(dataGridView1.Rows[i]);

            db = new MyDbContext();

            DataTable table = new DataTable();

            table.Columns.Add("Имя", typeof(string));
            table.Columns.Add("Фамилия", typeof(string));
            table.Columns.Add("Возраст", typeof(string));
            table.Columns.Add("Роль", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Офис", typeof(string));

            foreach (var i in db.Users)
            {
                //Вычисляю возраст, название роли, название офиса
                var age = DateTime.Now.Year - i.Birthdate.Year;
                var currentRole = db.Roles.FirstOrDefault(r => r.ID == i.RoleID).Title;
                var officeName = db.Offices.FirstOrDefault(o => o.ID == i.OfficeID).Title;

                if (inputOffice.Text == "Все офисы")
                {
                    table.Rows.Add(i.Firstname, i.Lastname, age, currentRole, i.Email, officeName);
                }
                else
                {
                    foreach (var office in db.Offices)
                    {
                        if (office.Title == inputOffice.Text)
                        {
                            if (office.ID == i.OfficeID)
                            {
                                table.Rows.Add(i.Firstname, i.Lastname, age, currentRole, i.Email, officeName);
                                
                                break;
                            }
                        }
                    }
                }

            }

            dataGridView1.DataSource = table;

            AddColor();
        }

        //Заполняем таблицу администраторов и их активности
        public void FillAdminsTable()
        {

            while (dataGridAdmins.Rows.Count > 1)
                for (int i = 0; i < dataGridAdmins.Rows.Count - 1; i++)
                    dataGridAdmins.Rows.Remove(dataGridAdmins.Rows[i]);

            db = new MyDbContext();

            DataTable table = new DataTable();

            table.Columns.Add("Имя", typeof(string));
            table.Columns.Add("Фамилия", typeof(string));
            table.Columns.Add("Возраст", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Офис", typeof(string));

            table.Columns.Add("Активность", typeof(string));

            //var curLog = db.Logs.FirstOrDefault(l => l.ID == currentLogID);

            foreach (var i in db.Users)
            {

                int CurId = i.ID;

                bool isOnline = false;

                foreach (var log in db.Logs)
                {
                    if (log.UserID == i.ID)
                    {
                        isOnline = log.IsCrash;
                    }
                }

                
                var age = DateTime.Now.Year - i.Birthdate.Year;
                var currentRole = db.Roles.FirstOrDefault(r => r.ID == i.RoleID).Title;
                var officeName = db.Offices.FirstOrDefault(o => o.ID == i.OfficeID).Title;

                if (i.RoleID == 1)
                {
                    if (isOnline)
                    {
                        table.Rows.Add(i.Firstname, i.Lastname, age, i.Email, officeName, "Онлайн");

                    }
                    else
                    {
                        var logoutTime = db.Logs.FirstOrDefault(l => l.UserID == currentUserID).Date;

                        //var lastActive = DateTime.Now - logoutTime;
                        var lastActive = "Менее 5 минут назад";
                        table.Rows.Add(i.Firstname, i.Lastname, age, i.Email, officeName, lastActive);
                    }
                }
                

            }

            dataGridAdmins.DataSource = table;

           
        }


        //Выделить красным ячейки "Заблокировано"
        public void AddColor()
        {
            using (var db = new MyDbContext())
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    string strock = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    if (strock == "Administrator")
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }

                    string curUser = dataGridView1.Rows[i].Cells[4].Value.ToString();

                    var isActive = db.Users.FirstOrDefault(u => u.Email == curUser).Active;

                    if (isActive == false)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Tomato;        
                    }
                }
            }
        }


        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FillTable();
            //AddColor();
        }

        //Переменные для Редактирования выбранной строки
        String colVal = String.Empty;

        //Блокировка выбранного пользователя
        private void block_Click(object sender, EventArgs e)
        {
            var context = new MyDbContext();

            DataGridViewRow dgv = dataGridView1.CurrentRow;
            if (dgv.Cells["Email"].Value != null )
            {
                colVal = dgv.Cells["Email"].Value.ToString();
            }

            var currentUser = context.Users.FirstOrDefault(user => user.Email == colVal);
            if (currentUser.Active == true)
            {
                currentUser.Active = false;
            } else
            {
                currentUser.Active = true;
            }
            context.SaveChanges();

            //AddColor();
            FillTable();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillTable();
        }

        private void addUser_Click(object sender, EventArgs e)
        {
            AddUser formAddUser = new AddUser();
            formAddUser.ShowDialog();
        }

        private void changeRole_Click(object sender, EventArgs e)
        {
            var context = new MyDbContext();

            EditUser formEditUser = new EditUser();

            DataGridViewRow dgv = dataGridView1.CurrentRow;
            if (dgv.Cells["Email"].Value != null)
            {
                colVal = dgv.Cells["Email"].Value.ToString();
            }

            var currentUser = context.Users.FirstOrDefault(user => user.Email == colVal);

            formEditUser.inputEmail.Text = currentUser.Email;
            formEditUser.inputName.Text = currentUser.Firstname;
            formEditUser.inputSurname.Text = currentUser.Lastname;

            var officeName = db.Offices.FirstOrDefault(o => o.ID == currentUser.OfficeID).Title;
            // MessageBox.Show(officeName);

            formEditUser.userEmail = currentUser.Email;

            foreach (var i in db.Offices)
            {
                formEditUser.inputOffice.Items.Add(i.Title);
            }
            formEditUser.inputOffice.Text = officeName;

            var currentRole = db.Roles.FirstOrDefault(r => r.ID == currentUser.RoleID).Title;
            if (currentRole == "User")
            {
                formEditUser.radioButton1.Checked = true;
            } else
            {
                formEditUser.radioButton2.Checked = true;
            }

            formEditUser.ShowDialog();
        }

        bool isPainted = false;
        //Закрашиваем при изменении строчек DataGridView
        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (!isPainted)
            {
                isPainted = true;
                AddColor();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход из системы", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //AddColor();
        }

        private void updateTable_Click(object sender, EventArgs e)
        {
            FillTable();
        }

        private void AdminPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            var db = new MyDbContext();

            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            var log = db.Logs.FirstOrDefault(l => l.UserID == currentUserID);

            string h;
            if (DateTime.Now.Hour.ToString().Length < 2)
            {
                h = "0" + DateTime.Now.Hour.ToString();
            }
            else
            {
                h = DateTime.Now.Hour.ToString();
            }
            string m;
            if (DateTime.Now.Minute.ToString().Length < 2)
            {
                m = "0" + DateTime.Now.Minute.ToString();
            }
            else
            {
                m = DateTime.Now.Minute.ToString();
            }

            log.LogoutTime = h + ":" + m;
            log.TimeSpent = 0;
            log.IsCrash = false;

            //MessageBox.Show(currentLogID.ToString());
            db.SaveChanges();
        }

        private void updateAdmins_Click(object sender, EventArgs e)
        {
            FillAdminsTable();
        }

        private void notify_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Напоминание отправлено!");
        }
    }
}
