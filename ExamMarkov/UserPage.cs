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
    public partial class UserPage : Form
    {
        public int currentUserID;
        int spentSeconds = 0;
        int numberOfCrashes = 0;

        string loginTime = "";

        int currentLogID = 0;


        MyDbContext db;
        public UserPage(int currUserID)
        {
            db = new MyDbContext();

            InitializeComponent();

            string h;
            if (DateTime.Now.Hour.ToString().Length < 2)
            {
                h = "0" + DateTime.Now.Hour.ToString();
            }       
            else {
                h = DateTime.Now.Hour.ToString();
            }
            string m;
            if (DateTime.Now.Minute.ToString().Length < 2)
            {
                m = "0" + DateTime.Now.Minute.ToString();
            } 
            else {
                m = DateTime.Now.Minute.ToString();
            }

            loginTime = h + ":" + m;
            //var ts = TimeSpan.FromSeconds(21355);
            //var currentRole = db.Logs.(r => r.ID == i.RoleID).Title;

            currentUserID = currUserID;

            FirstSetup();

            CheckIsCrash();

            FillDataGrid();

            CreateLog();

            timeSpent.Start();

        }

        public void CheckIsCrash()
        {
            db = new MyDbContext();

            foreach(var log in db.Logs)
            {
                if (log.IsCrash == true && log.Reason == "")
                {
                    DetectedForm detectedForm = new DetectedForm(log.ID);
                    detectedForm.ShowDialog();

                    detectedForm.detectedDateLabel.Text = "Не обнаружен выход должным образом из системы " + log.Date.ToString("dd/mm/yyyy") + " в " + log.LoginTime;

                }
            }
        }


        public void FirstSetup()
        {
            db = new MyDbContext();

            foreach (var log in db.Logs)
            {
                if (log.UserID == currentUserID)
                {
                    spentSeconds += log.TimeSpent;

                    if (log.IsCrash == true)
                    {
                        numberOfCrashes++;
                        numberCrashesLabel.Text = numberOfCrashes.ToString();
                    }
                }
            }
        }

        public void FillDataGrid()
        {
            db = new MyDbContext();

            DataTable table = new DataTable();

            table.Columns.Add("Дата", typeof(string));
            table.Columns.Add("Login time", typeof(string));
            table.Columns.Add("Logout time", typeof(string));
            table.Columns.Add("Time spent on system", typeof(string));
            table.Columns.Add("Unsuccessful logout reason", typeof(string));

            

            foreach (var log in db.Logs)
            {
                if (currentUserID == log.UserID)
                {
                    string goodDate = log.Date.Day + "/" + log.Date.Month + "/" + log.Date.Year;
                    table.Rows.Add(goodDate, log.LoginTime, log.LogoutTime, log.TimeSpent, log.Reason);
                }
            }

            dataGrid.DataSource = table;


        }

        private void exit_Click(object sender, EventArgs e)
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

        int currentSeconds = 0;
        private void timeSpent_Tick(object sender, EventArgs e)
        {
            var ts = TimeSpan.FromSeconds(spentSeconds + currentSeconds);

            currentSeconds++;

            string hours = ts.Hours.ToString();
            if (hours.Length != 2)
            {
                hours = "0" + hours;
            }    
            string minutes = ts.Minutes.ToString();
            if (minutes.Length != 2)
            {
                minutes = "0" + minutes;
            }    
            string secs = ts.Seconds.ToString();
            if (secs.Length != 2)
            {
                secs = "0" + secs;
            }

            timeSpentLabel.Text = hours + ":" + minutes + ":" +  secs ;
        }

        //Закрытие формы
        private void UserPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MessageBox.Show(e.CloseReason.ToString());
            var db = new MyDbContext();

            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            
            var log = db.Logs.FirstOrDefault(l => l.ID == currentLogID);

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
            log.TimeSpent = currentSeconds;
            log.IsCrash = false;
            
            db.SaveChanges();

        }

        //Первоначальное создание лога
        public void CreateLog()
        {
            var db = new MyDbContext();

            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            var log = new Log()
            {
                UserID = currentUserID,

                Date = date,
                LoginTime = loginTime,
                //LogoutTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute,
                //TimeSpent = currentSeconds,
                Reason = "",
                IsCrash = true

            };

            db.Logs.Add(log);
            db.SaveChanges();

            currentLogID = log.ID;

        }

        public void AddColor()
        {
            using (var db = new MyDbContext())
            {
                for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
                {
                    string strock = dataGrid.Rows[i].Cells[2].Value.ToString();
                    if (strock == "")
                    {
                        dataGrid.Rows[i].DefaultCellStyle.BackColor = Color.Tomato;
                    }

                }
            }
        }


        bool isPainted = false;
        private void dataGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (!isPainted)
            {
                isPainted = true;
                AddColor();
            }
        }
    }
}
