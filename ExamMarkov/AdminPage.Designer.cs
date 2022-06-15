
namespace Train
{
    partial class AdminPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.exit = new System.Windows.Forms.Button();
            this.addUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.inputOffice = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.changeRole = new System.Windows.Forms.Button();
            this.block = new System.Windows.Forms.Button();
            this.updateTable = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridAdmins = new System.Windows.Forms.DataGridView();
            this.updateAdmins = new System.Windows.Forms.Button();
            this.notify = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAdmins)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.exit);
            this.panel1.Location = new System.Drawing.Point(0, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 91);
            this.panel1.TabIndex = 0;
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exit.Location = new System.Drawing.Point(827, 23);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(95, 48);
            this.exit.TabIndex = 4;
            this.exit.Text = "Выход";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.button1_Click);
            // 
            // addUser
            // 
            this.addUser.BackColor = System.Drawing.Color.Snow;
            this.addUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addUser.Location = new System.Drawing.Point(17, 26);
            this.addUser.Name = "addUser";
            this.addUser.Size = new System.Drawing.Size(266, 48);
            this.addUser.TabIndex = 3;
            this.addUser.Text = "Добавить пользователя";
            this.addUser.UseVisualStyleBackColor = false;
            this.addUser.Click += new System.EventHandler(this.addUser_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(24, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Офис";
            // 
            // inputOffice
            // 
            this.inputOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputOffice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputOffice.FormattingEnabled = true;
            this.inputOffice.Items.AddRange(new object[] {
            "Все офисы"});
            this.inputOffice.Location = new System.Drawing.Point(114, 110);
            this.inputOffice.Name = "inputOffice";
            this.inputOffice.Size = new System.Drawing.Size(216, 28);
            this.inputOffice.TabIndex = 5;
            this.inputOffice.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 159);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(870, 355);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // changeRole
            // 
            this.changeRole.BackColor = System.Drawing.Color.Snow;
            this.changeRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeRole.Location = new System.Drawing.Point(29, 520);
            this.changeRole.Name = "changeRole";
            this.changeRole.Size = new System.Drawing.Size(220, 48);
            this.changeRole.TabIndex = 5;
            this.changeRole.Text = "Изменить роль";
            this.changeRole.UseVisualStyleBackColor = false;
            this.changeRole.Click += new System.EventHandler(this.changeRole_Click);
            // 
            // block
            // 
            this.block.BackColor = System.Drawing.Color.Snow;
            this.block.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.block.Location = new System.Drawing.Point(525, 520);
            this.block.Name = "block";
            this.block.Size = new System.Drawing.Size(351, 48);
            this.block.TabIndex = 7;
            this.block.Text = "Блокировать/разблокировать";
            this.block.UseVisualStyleBackColor = false;
            this.block.Click += new System.EventHandler(this.block_Click);
            // 
            // updateTable
            // 
            this.updateTable.BackColor = System.Drawing.Color.Snow;
            this.updateTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.updateTable.Location = new System.Drawing.Point(660, 115);
            this.updateTable.Name = "updateTable";
            this.updateTable.Size = new System.Drawing.Size(216, 39);
            this.updateTable.TabIndex = 5;
            this.updateTable.Text = "Обновить таблицу";
            this.updateTable.UseVisualStyleBackColor = false;
            this.updateTable.Click += new System.EventHandler(this.updateTable_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 95);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(910, 614);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.SeaShell;
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.addUser);
            this.tabPage1.Controls.Add(this.block);
            this.tabPage1.Controls.Add(this.updateTable);
            this.tabPage1.Controls.Add(this.changeRole);
            this.tabPage1.Controls.Add(this.inputOffice);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(902, 588);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Все пользователи";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.SeaShell;
            this.tabPage2.Controls.Add(this.notify);
            this.tabPage2.Controls.Add(this.updateAdmins);
            this.tabPage2.Controls.Add(this.dataGridAdmins);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(902, 588);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Активность администраторов";
            // 
            // dataGridAdmins
            // 
            this.dataGridAdmins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAdmins.Location = new System.Drawing.Point(6, 6);
            this.dataGridAdmins.Name = "dataGridAdmins";
            this.dataGridAdmins.Size = new System.Drawing.Size(870, 465);
            this.dataGridAdmins.TabIndex = 7;
            // 
            // updateAdmins
            // 
            this.updateAdmins.BackColor = System.Drawing.Color.WhiteSmoke;
            this.updateAdmins.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.updateAdmins.Location = new System.Drawing.Point(448, 487);
            this.updateAdmins.Name = "updateAdmins";
            this.updateAdmins.Size = new System.Drawing.Size(428, 48);
            this.updateAdmins.TabIndex = 5;
            this.updateAdmins.Text = "Обновить список администраторов";
            this.updateAdmins.UseVisualStyleBackColor = false;
            this.updateAdmins.Click += new System.EventHandler(this.updateAdmins_Click);
            // 
            // notify
            // 
            this.notify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.notify.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.notify.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.notify.Location = new System.Drawing.Point(6, 487);
            this.notify.Name = "notify";
            this.notify.Size = new System.Drawing.Size(379, 48);
            this.notify.TabIndex = 8;
            this.notify.Text = "Отправить напоминание о работе";
            this.notify.UseVisualStyleBackColor = false;
            this.notify.Click += new System.EventHandler(this.notify_Click);
            // 
            // AdminPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(943, 734);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "AdminPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Форма администратора";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminPage_FormClosed);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAdmins)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button addUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox inputOffice;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button changeRole;
        private System.Windows.Forms.Button block;
        private System.Windows.Forms.Button updateTable;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridAdmins;
        private System.Windows.Forms.Button updateAdmins;
        private System.Windows.Forms.Button notify;
    }
}