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
            // Панель для ввода данных
            System.Windows.Forms.Panel inputPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpCreationDate = new System.Windows.Forms.DateTimePicker();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnRemoveCategory = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblReportsList = new System.Windows.Forms.Label();
            this.lstReports = new System.Windows.Forms.ListBox();
            this.lblFilterCategory = new System.Windows.Forms.Label();
            this.cmbFilterCategory = new System.Windows.Forms.ComboBox();
            this.lblReportsCount = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();

            // Настройка формы
            this.SuspendLayout();
            this.Text = "Управление отчётами - Лабораторная работа №5";
            this.Size = new System.Drawing.Size(850, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // inputPanel
            inputPanel.Location = new System.Drawing.Point(10, 10);
            inputPanel.Size = new System.Drawing.Size(400, 280);
            inputPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            inputPanel.BackColor = System.Drawing.Color.White;

            // lblTitle
            this.lblTitle.Text = "Заголовок отчёта:";
            this.lblTitle.Location = new System.Drawing.Point(10, 15);
            this.lblTitle.Size = new System.Drawing.Size(120, 25);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

            // txtTitle
            this.txtTitle.Location = new System.Drawing.Point(130, 12);
            this.txtTitle.Size = new System.Drawing.Size(250, 25);
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 10);

            // lblContent
            this.lblContent.Text = "Содержимое:";
            this.lblContent.Location = new System.Drawing.Point(10, 50);
            this.lblContent.Size = new System.Drawing.Size(120, 25);
            this.lblContent.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

            // txtContent
            this.txtContent.Location = new System.Drawing.Point(10, 80);
            this.txtContent.Size = new System.Drawing.Size(375, 80);
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
            this.dtpCreationDate.Size = new System.Drawing.Size(250, 25);
            this.dtpCreationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCreationDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpCreationDate.ShowUpDown = true;
            this.dtpCreationDate.Value = System.DateTime.Now;

            // lblCategory
            this.lblCategory.Text = "Категория:";
            this.lblCategory.Location = new System.Drawing.Point(10, 200);
            this.lblCategory.Size = new System.Drawing.Size(80, 25);
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

            // cmbCategory
            this.cmbCategory.Location = new System.Drawing.Point(90, 197);
            this.cmbCategory.Size = new System.Drawing.Size(150, 25);
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // btnAddCategory
            this.btnAddCategory.Text = "+";
            this.btnAddCategory.Location = new System.Drawing.Point(250, 195);
            this.btnAddCategory.Size = new System.Drawing.Size(35, 27);
            this.btnAddCategory.BackColor = System.Drawing.Color.LightGreen;
            this.btnAddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCategory.Click += new System.EventHandler(this.BtnAddCategory_Click);

            // btnRemoveCategory
            this.btnRemoveCategory.Text = "-";
            this.btnRemoveCategory.Location = new System.Drawing.Point(290, 195);
            this.btnRemoveCategory.Size = new System.Drawing.Size(35, 27);
            this.btnRemoveCategory.BackColor = System.Drawing.Color.LightCoral;
            this.btnRemoveCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveCategory.Click += new System.EventHandler(this.BtnRemoveCategory_Click);

            // btnAdd
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Location = new System.Drawing.Point(10, 235);
            this.btnAdd.Size = new System.Drawing.Size(85, 30);
            this.btnAdd.BackColor = System.Drawing.Color.LightGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

            // btnUpdate
            this.btnUpdate.Text = "Обновить";
            this.btnUpdate.Location = new System.Drawing.Point(105, 235);
            this.btnUpdate.Size = new System.Drawing.Size(85, 30);
            this.btnUpdate.BackColor = System.Drawing.Color.LightBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);

            // btnDelete
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Location = new System.Drawing.Point(200, 235);
            this.btnDelete.Size = new System.Drawing.Size(85, 30);
            this.btnDelete.BackColor = System.Drawing.Color.LightCoral;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            // btnClear
            this.btnClear.Text = "Очистить";
            this.btnClear.Location = new System.Drawing.Point(295, 235);
            this.btnClear.Size = new System.Drawing.Size(85, 30);
            this.btnClear.BackColor = System.Drawing.Color.LightGray;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);

            // Добавляем контролы на inputPanel
            inputPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.txtTitle, this.lblContent, this.txtContent,
                this.lblDate, this.dtpCreationDate, this.lblCategory, this.cmbCategory,
                this.btnAddCategory, this.btnRemoveCategory, this.btnAdd, this.btnUpdate,
                this.btnDelete, this.btnClear
            });

            // lblReportsList
            this.lblReportsList = new System.Windows.Forms.Label();
            this.lblReportsList.Text = "Список отчётов:";
            this.lblReportsList.Location = new System.Drawing.Point(420, 10);
            this.lblReportsList.Size = new System.Drawing.Size(400, 25);
            this.lblReportsList.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

            // lstReports
            this.lstReports.Location = new System.Drawing.Point(420, 40);
            this.lstReports.Size = new System.Drawing.Size(400, 500);
            this.lstReports.Font = new System.Drawing.Font("Segoe UI", 10);
            this.lstReports.SelectedIndexChanged += new System.EventHandler(this.LstReports_SelectedIndexChanged);

            // lblFilterCategory
            this.lblFilterCategory = new System.Windows.Forms.Label();
            this.lblFilterCategory.Text = "Фильтр по категории:";
            this.lblFilterCategory.Location = new System.Drawing.Point(420, 545);
            this.lblFilterCategory.Size = new System.Drawing.Size(130, 25);
            this.lblFilterCategory.Font = new System.Drawing.Font("Segoe UI", 9);

            // cmbFilterCategory
            this.cmbFilterCategory.Location = new System.Drawing.Point(560, 542);
            this.cmbFilterCategory.Size = new System.Drawing.Size(150, 25);
            this.cmbFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterCategory.SelectedIndexChanged += new System.EventHandler(this.CmbFilterCategory_SelectedIndexChanged);

            // lblReportsCount
            this.lblReportsCount.Location = new System.Drawing.Point(720, 545);
            this.lblReportsCount.Size = new System.Drawing.Size(100, 25);
            this.lblReportsCount.Text = "Всего отчётов: 0";
            this.lblReportsCount.Font = new System.Drawing.Font("Segoe UI", 9);

            // statusStrip
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel("Готов к работе");
            this.statusStrip.Items.Add(this.lblStatus);

            // Добавляем элементы на форму
            this.Controls.Add(inputPanel);
            this.Controls.Add(this.lblReportsList);
            this.Controls.Add(this.lstReports);
            this.Controls.Add(this.lblFilterCategory);
            this.Controls.Add(this.cmbFilterCategory);
            this.Controls.Add(this.lblReportsCount);
            this.Controls.Add(this.statusStrip);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Объявление полей формы
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpCreationDate;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnRemoveCategory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblReportsList;
        private System.Windows.Forms.ListBox lstReports;
        private System.Windows.Forms.Label lblFilterCategory;
        private System.Windows.Forms.ComboBox cmbFilterCategory;
        private System.Windows.Forms.Label lblReportsCount;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}