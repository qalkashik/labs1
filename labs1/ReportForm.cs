using System;
using System.Windows.Forms;

namespace labs1
{
    public partial class ReportForm : Form
    {
        private ReportManager _reportManager;

        public ReportForm()
        {
            InitializeComponent();
            _reportManager = new ReportManager();
            LoadCategoriesToComboBox();
            LoadFilterCategoriesToComboBox();
            LoadReportsToListBox();
            UpdateReportsCount();
        }

        private void LoadCategoriesToComboBox()
        {
            cmbCategory.Items.Clear();
            foreach (var category in _reportManager.Categories)
            {
                cmbCategory.Items.Add(category);
            }
            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;
        }

        private void LoadFilterCategoriesToComboBox()
        {
            cmbFilterCategory.Items.Clear();
            cmbFilterCategory.Items.Add("Все категории");
            foreach (var category in _reportManager.Categories)
            {
                cmbFilterCategory.Items.Add(category);
            }
            cmbFilterCategory.SelectedIndex = 0;
        }

        private void LoadReportsToListBox()
        {
            lstReports.Items.Clear();

            string selectedFilter = cmbFilterCategory.SelectedItem?.ToString() ?? "Все категории";

            var reportsToShow = selectedFilter == "Все категории"
                ? _reportManager.Reports
                : _reportManager.GetReportsByCategory(selectedFilter);

            foreach (var report in reportsToShow)
            {
                lstReports.Items.Add(report.ToString());
            }
        }

        private void UpdateReportsCount()
        {
            string selectedFilter = cmbFilterCategory.SelectedItem?.ToString() ?? "Все категории";
            int count = selectedFilter == "Все категории"
                ? _reportManager.Reports.Count
                : _reportManager.GetReportsByCategory(selectedFilter).Count;
            lblReportsCount.Text = $"Всего отчётов: {count}";
        }

        private void ClearInputFields()
        {
            txtTitle.Text = string.Empty;
            txtContent.Text = string.Empty;
            dtpCreationDate.Value = DateTime.Now;
            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;
            txtTitle.Focus();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Пожалуйста, введите заголовок отчёта.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContent.Text))
            {
                MessageBox.Show("Пожалуйста, введите содержимое отчёта.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContent.Focus();
                return false;
            }

            return true;
        }

        private Report GetSelectedReport()
        {
            if (lstReports.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите отчёт из списка.", "Ошибка выбора",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            string selectedFilter = cmbFilterCategory.SelectedItem?.ToString() ?? "Все категории";
            var reportsList = selectedFilter == "Все категории"
                ? _reportManager.Reports
                : _reportManager.GetReportsByCategory(selectedFilter);

            if (lstReports.SelectedIndex >= reportsList.Count)
                return null;

            return reportsList[lstReports.SelectedIndex];
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                string category = cmbCategory.SelectedItem?.ToString() ?? "Без категории";

                Report newReport = new Report(
                    txtTitle.Text.Trim(),
                    txtContent.Text.Trim(),
                    dtpCreationDate.Value,
                    category
                );

                _reportManager.AddReport(newReport);
                LoadReportsToListBox();
                UpdateReportsCount();
                ClearInputFields();

                lblStatus.Text = $"Отчёт \"{newReport.Title}\" успешно добавлен!";
                MessageBox.Show("Отчёт успешно добавлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении отчёта: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Ошибка при добавлении отчёта";
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Report selectedReport = GetSelectedReport();
                if (selectedReport == null)
                    return;

                if (!ValidateInput())
                    return;

                string newCategory = cmbCategory.SelectedItem?.ToString() ?? "Без категории";

                _reportManager.UpdateReport(selectedReport, txtTitle.Text.Trim(), txtContent.Text.Trim());
                _reportManager.UpdateReportCategory(selectedReport, newCategory);

                LoadReportsToListBox();
                UpdateReportsCount();

                lblStatus.Text = $"Отчёт \"{selectedReport.Title}\" успешно обновлён!";
                MessageBox.Show("Отчёт успешно обновлён!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении отчёта: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Ошибка при обновлении отчёта";
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Report selectedReport = GetSelectedReport();
                if (selectedReport == null)
                    return;

                DialogResult result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить отчёт \"{selectedReport.Title}\"?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    _reportManager.RemoveReport(selectedReport);
                    LoadReportsToListBox();
                    UpdateReportsCount();
                    ClearInputFields();

                    lblStatus.Text = $"Отчёт \"{selectedReport.Title}\" успешно удалён!";
                    MessageBox.Show("Отчёт успешно удалён!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении отчёта: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Ошибка при удалении отчёта";
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            lblStatus.Text = "Поля очищены";
        }

        private void LstReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            Report selectedReport = GetSelectedReport();
            if (selectedReport != null)
            {
                txtTitle.Text = selectedReport.Title;
                txtContent.Text = selectedReport.Content;
                dtpCreationDate.Value = selectedReport.CreationDate;

                int index = cmbCategory.Items.IndexOf(selectedReport.Category);
                if (index >= 0)
                    cmbCategory.SelectedIndex = index;

                lblStatus.Text = $"Выбран отчёт: {selectedReport.Title}";
            }
        }

        private void CmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReportsToListBox();
            UpdateReportsCount();
        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            string newCategory = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите название новой категории:",
                "Добавление категории",
                "");

            if (!string.IsNullOrWhiteSpace(newCategory))
            {
                try
                {
                    _reportManager.AddCategory(newCategory);
                    LoadCategoriesToComboBox();
                    LoadFilterCategoriesToComboBox();
                    lblStatus.Text = $"Категория \"{newCategory}\" добавлена!";
                    MessageBox.Show("Категория успешно добавлена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnRemoveCategory_Click(object sender, EventArgs e)
        {
            string selectedCategory = cmbCategory.SelectedItem?.ToString();
            if (selectedCategory == null || selectedCategory == "Без категории")
            {
                MessageBox.Show("Нельзя удалить категорию 'Без категории' или когда не выбрана категория.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Вы уверены, что хотите удалить категорию \"{selectedCategory}\"?\n\nОтчёты с этой категорией будут перемещены в 'Без категории'.",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    _reportManager.RemoveCategory(selectedCategory);
                    LoadCategoriesToComboBox();
                    LoadFilterCategoriesToComboBox();
                    LoadReportsToListBox();
                    UpdateReportsCount();
                    lblStatus.Text = $"Категория \"{selectedCategory}\" удалена!";
                    MessageBox.Show("Категория успешно удалена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}