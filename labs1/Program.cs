namespace Laboratorn1
{
    using System;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    public class ReportManager
    {
        public List<Report> Reports { get; private set; }
        public ReportManager()
        {
            Reports = new List<Report>();
            LoadReports();
        }
        public void AddReport(Report report)
        {
            if (report == null)
            {
                throw new ArgumentNullException(nameof(report));
            }
            Reports.Add(report);
            SaveReports();
        }
        public void RemoveReport(Report report)
        {
            if (report == null)
            {
                throw new ArgumentNullException(nameof(report));
            }
            Reports.Remove(report);
            SaveReports();
        }
        public void UpdateReport(Report report, string newTitle, string newContent)
        {
            if (report == null)
            {
                throw new ArgumentNullException(nameof(report));
            }
            report.Title = newTitle;
            report.Content = newContent;
            SaveReports();
        }
        private void SaveReports()
        {
            File.WriteAllLines("reports.txt", Reports.Select(r =>
            $"{r.Title}|{r.Content}|{r.CreationDate.ToString("yyyy-MM-dd HH:mm:ss")}"));
        }
        private void LoadReports()
        {
            if (File.Exists("reports.txt"))
            {
                var lines = File.ReadAllLines("reports.txt");
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        DateTime creationDate;
                        if (DateTime.TryParse(parts[2], out creationDate))
                        {
                            Reports.Add(new Report(parts[0], parts[1], creationDate));
                        }
                    }
                }
            }
        }
    }
    public class ReportForm : Form
    {
        private ReportManager reportManager;
        private TextBox titleTextBox;
        private TextBox contentTextBox;
        private Button addReportButton;
        private Button removeReportButton;
        private Button updateReportButton;
        private ListBox reportsListBox;
        public ReportForm()
        {
            this.Text = "Управление отчётами";
            this.Width = 600;
            this.Height = 500;
            titleTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 10),
                Width = 200,
  
            };
            contentTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 40),
                Width = 200,
                Height = 100,
                Multiline = true,
                ScrollBars = ScrollBars.Both,

            };
            addReportButton = new Button
            {
                Location = new System.Drawing.Point(10, 150),
                Text = "Добавить",
                Width = 100
            };
            addReportButton.Click += AddReportButton_Click;
            removeReportButton = new Button
            {
                Location = new System.Drawing.Point(120, 150),
                Text = "Удалить",
                Width = 100
            };
            removeReportButton.Click += RemoveReportButton_Click;
            updateReportButton = new Button
            {
                Location = new System.Drawing.Point(220, 150),
                Text = "Обновить",
                Width = 100
            };
            updateReportButton.Click += UpdateReportButton_Click;
            reportsListBox = new ListBox
            {
                Location = new System.Drawing.Point(10, 180),
                Width = 560,
                Height = 200
            };
            this.Controls.Add(titleTextBox);
            this.Controls.Add(contentTextBox);
            this.Controls.Add(addReportButton);
            this.Controls.Add(removeReportButton);
            this.Controls.Add(updateReportButton);
            this.Controls.Add(reportsListBox);
            reportManager = new ReportManager();
            UpdateReportsList();
        }
        private void UpdateReportsList()
        {
            reportsListBox.Items.Clear();
            foreach (var report in reportManager.Reports)
            {
                reportsListBox.Items.Add($"{report.Title}({report.CreationDate.ToString("yyyy-MM-dd")})");
            }
        }
        private void AddReportButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(titleTextBox.Text) || string.IsNullOrEmpty(contentTextBox.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            Report newReport = new Report(titleTextBox.Text, contentTextBox.Text,
            DateTime.Now);
            try
            {
                reportManager.AddReport(newReport);
                titleTextBox.Clear();
                contentTextBox.Clear();
                UpdateReportsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void RemoveReportButton_Click(object sender, EventArgs e)
        {
            if (reportsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите отчёт для удаления!");
                return;
            }
            string selectedItem = reportsListBox.SelectedItem.ToString();
            string[] parts = selectedItem.Split(new[] { '-' }, StringSplitOptions.None);
            if (parts.Length >= 2)
            {
                string title = parts[0].Trim();
                DateTime date;
                if (DateTime.TryParse(parts[1].Split(' ')[0], out date))
                {
                    var reportToRemove = reportManager.Reports.Find(r => r.Title == title &&
                    r.CreationDate.Date == date.Date);
                    if (reportToRemove != null)
                    {
                        try
                        {
                            reportManager.RemoveReport(reportToRemove);
                            UpdateReportsList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }
        private void UpdateReportButton_Click(object sender, EventArgs e)
        {
            if (reportsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите отчёт для обновления!");
                return;
            }
            string selectedItem = reportsListBox.SelectedItem.ToString();
            string[] parts = selectedItem.Split(new[] { '-' }, StringSplitOptions.None);
            if (parts.Length >= 2)
            {
                string title = parts[0].Trim();
                DateTime date;
                if (DateTime.TryParse(parts[1].Split(' ')[0], out date))
                {
                    var reportToUpdate = reportManager.Reports.Find(r => r.Title == title &&
                    r.CreationDate.Date == date.Date);
                    if (reportToUpdate != null)
                    {
                        if (string.IsNullOrEmpty(titleTextBox.Text) ||
                        string.IsNullOrEmpty(contentTextBox.Text))
                        {
                            MessageBox.Show("Заполните все поля!");
                            return;
                        }
                        try
                        {
                            reportManager.UpdateReport(reportToUpdate, titleTextBox.Text,
                            contentTextBox.Text);
                            UpdateReportsList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ReportForm());
        }
    }
}