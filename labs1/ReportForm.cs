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
            LoadReportsToListBox();
            UpdateReportsCount();
        }

        private void LoadReportsToListBox()
        {
            lstReports.Items.Clear();
            foreach (var report in _reportManager.Reports)
            {
                lstReports.Items.Add($"{report.Title} | {report.CreationDate:yyyy-MM-dd HH:mm}");
            }
        }

        private void UpdateReportsCount()
        {
            lblReportsCount.Text = $"Всего отчётов: {_reportManager.Reports.Count}";
        }

        private void ClearInputFields()
        {
            txtTitle.Text = string.Empty;
            txtContent.Text = string.Empty;
            dtpCreationDate.Value = DateTime.Now;
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

            if (lstReports.SelectedIndex >= _reportManager.Reports.Count)
            {
                return null;
            }

            return _reportManager.Reports[lstReports.SelectedIndex];
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                Report newReport = new Report(
                    txtTitle.Text.Trim(),
                    txtContent.Text.Trim(),
                    dtpCreationDate.Value
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

                _reportManager.UpdateReport(
                    selectedReport,
                    txtTitle.Text.Trim(),
                    txtContent.Text.Trim()
                );

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
                lblStatus.Text = $"Выбран отчёт: {selectedReport.Title}";
            }
        }
    }
}