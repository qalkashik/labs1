namespace labs1
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Создание панели
            System.Windows.Forms.Panel inputPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpCreationDate = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblReportsList = new System.Windows.Forms.Label();
            this.lstReports = new System.Windows.Forms.ListBox();
            this.lblReportsCount = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();

            // Настройка формы
            this.SuspendLayout();
            this.Text = "Управление отчётами - Лабораторная работа №4";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // inputPanel
            inputPanel.Location = new System.Drawing.Point(10, 10);
            inputPanel.Size = new System.Drawing.Size(380, 240);
            inputPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            inputPanel.BackColor = System.Drawing.Color.White;

            // lblTitle
            this.lblTitle.Text = "Заголовок отчёта:";
            this.lblTitle.Location = new System.Drawing.Point(10, 15);
            this.lblTitle.Size = new System.Drawing.Size(120, 25);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

            // txtTitle
            this.txtTitle.Location = new System.Drawing.Point(130, 12);
            this.txtTitle.Size = new System.Drawing.Size(230, 25);
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 10);

            // lblContent
            this.lblContent.Text = "Содержимое:";
            this.lblContent.Location = new System.Drawing.Point(10, 50);
            this.lblContent.Size = new System.Drawing.Size(120, 25);
            this.lblContent.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

            // txtContent
            this.txtContent.Location = new System.Drawing.Point(10, 80);
            this.txtContent.Size = new System.Drawing.Size(355, 80);
            this.txtContent.Multiline = true;
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Font = new System.Drawing.Font("Segoe UI", 10);

            // lblDate
            this.lblDate.Text = "Дата создания:";
            this.lblDate.Location = new System.Drawing.Point(10, 170);
            this.lblDate.Size = new System.Drawing.Size(120, 25);
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

            // dtpCreationDate
            this.dtpCreationDate.Location = new System.Drawing.Point(130, 167);
            this.dtpCreationDate.Size = new System.Drawing.Size(230, 25);
            this.dtpCreationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCreationDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpCreationDate.ShowUpDown = true;
            this.dtpCreationDate.Value = System.DateTime.Now;

            // btnAdd
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Location = new System.Drawing.Point(10, 200);
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.BackColor = System.Drawing.Color.LightGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

            // btnUpdate
            this.btnUpdate.Text = "Обновить";
            this.btnUpdate.Location = new System.Drawing.Point(100, 200);
            this.btnUpdate.Size = new System.Drawing.Size(80, 30);
            this.btnUpdate.BackColor = System.Drawing.Color.LightBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);

            // btnDelete
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Location = new System.Drawing.Point(190, 200);
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.BackColor = System.Drawing.Color.LightCoral;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            // btnClear
            this.btnClear.Text = "Очистить";
            this.btnClear.Location = new System.Drawing.Point(280, 200);
            this.btnClear.Size = new System.Drawing.Size(85, 30);
            this.btnClear.BackColor = System.Drawing.Color.LightGray;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);

            inputPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.txtTitle, this.lblContent, this.txtContent,
                this.lblDate, this.dtpCreationDate, this.btnAdd, this.btnUpdate,
                this.btnDelete, this.btnClear
            });

            // lblReportsList
            this.lblReportsList.Text = "Список отчётов:";
            this.lblReportsList.Location = new System.Drawing.Point(400, 10);
            this.lblReportsList.Size = new System.Drawing.Size(380, 25);
            this.lblReportsList.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

            // lstReports
            this.lstReports.Location = new System.Drawing.Point(400, 40);
            this.lstReports.Size = new System.Drawing.Size(375, 470);
            this.lstReports.Font = new System.Drawing.Font("Segoe UI", 10);
            this.lstReports.SelectedIndexChanged += new System.EventHandler(this.LstReports_SelectedIndexChanged);

            // lblReportsCount
            this.lblReportsCount.Location = new System.Drawing.Point(400, 515);
            this.lblReportsCount.Size = new System.Drawing.Size(375, 25);
            this.lblReportsCount.Text = "Всего отчётов: 0";
            this.lblReportsCount.Font = new System.Drawing.Font("Segoe UI", 9);

            // statusStrip
            this.statusStrip.Items.Add(this.lblStatus);

            // Добавляем элементы на форму
            this.Controls.Add(inputPanel);
            this.Controls.Add(this.lblReportsList);
            this.Controls.Add(this.lstReports);
            this.Controls.Add(this.lblReportsCount);
            this.Controls.Add(this.statusStrip);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // ОБЪЯВЛЕНИЕ ПОЛЕЙ - ТОЛЬКО ЗДЕСЬ, НЕ В ReportForm.cs!
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpCreationDate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblReportsList;
        private System.Windows.Forms.ListBox lstReports;
        private System.Windows.Forms.Label lblReportsCount;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}