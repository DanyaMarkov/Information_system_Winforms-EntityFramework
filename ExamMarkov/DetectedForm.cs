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
    public partial class DetectedForm : Form
    {

        MyDbContext db;

        int currLogID;
        public DetectedForm(int LogID)
        {
            db = new MyDbContext();

            InitializeComponent();

            currLogID = LogID;

            var log = db.Logs.FirstOrDefault(l => l.ID == currLogID);

            detectedDateLabel.Text = "Не зафиксирован корректный выход " + log.Date.ToString("dd/MM/yyyy") + " в " + log.LoginTime;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            db = new MyDbContext();

            var log = db.Logs.FirstOrDefault(l => l.ID == currLogID);


            if (radioButton1.Checked)
            {
                log.Reason = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                log.Reason = radioButton2.Text;
            }
            else if (reasonText.Text != "")
            {
                log.Reason = reasonText.Text;
            }
            else
            {
                MessageBox.Show("Выберите причину сбоя");
                return;
            }

            db.SaveChanges();

            this.Close();
        }
    }
}
