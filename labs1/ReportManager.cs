using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace labs1
{
    public class ReportManager
    {
        private const string ReportsFilePath = "reports.txt";
        private const string CategoriesFilePath = "categories.txt";
        private const char Separator = '|';

        public List<Report> Reports { get; private set; }
        public List<string> Categories { get; private set; }

        public ReportManager()
        {
            Reports = new List<Report>();
            Categories = new List<string>();
            LoadCategories();
            LoadReports();

            if (Categories.Count == 0)
            {
                Categories.AddRange(new[] { "Без категории", "Финансовые", "Технические", "Маркетинговые", "Личные" });
                SaveCategories();
            }
        }

        public void AddCategory(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                throw new ArgumentException("Название категории не может быть пустым", nameof(categoryName));

            if (Categories.Contains(categoryName))
                throw new InvalidOperationException($"Категория '{categoryName}' уже существует");

            Categories.Add(categoryName);
            SaveCategories();
        }

        public void RemoveCategory(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                throw new ArgumentException("Название категории не может быть пустым", nameof(categoryName));

            if (categoryName == "Без категории")
                throw new InvalidOperationException("Нельзя удалить категорию 'Без категории'");

            if (!Categories.Contains(categoryName))
                throw new InvalidOperationException($"Категория '{categoryName}' не существует");

            Categories.Remove(categoryName);

            foreach (var report in Reports.Where(r => r.Category == categoryName))
            {
                report.Category = "Без категории";
            }

            SaveCategories();
            SaveReports();
        }

        public List<Report> GetReportsByCategory(string categoryName)
        {
            return Reports.Where(r => r.Category == categoryName).ToList();
        }

        public void UpdateReportCategory(Report report, string newCategory)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report));

            if (!Categories.Contains(newCategory))
                throw new InvalidOperationException($"Категория '{newCategory}' не существует");

            report.Category = newCategory;
            SaveReports();
        }

        private void SaveCategories()
        {
            try
            {
                File.WriteAllLines(CategoriesFilePath, Categories);
            }
            catch (Exception ex)
            {
                throw new IOException($"Ошибка при сохранении категорий: {ex.Message}", ex);
            }
        }

        private void LoadCategories()
        {
            if (!File.Exists(CategoriesFilePath))
                return;

            try
            {
                var lines = File.ReadAllLines(CategoriesFilePath);
                Categories = lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
            }
            catch
            {
                Categories = new List<string>();
            }
        }

        public void AddReport(Report report)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report), "Отчёт не может быть null");

            if (!Categories.Contains(report.Category))
                report.Category = "Без категории";

            Reports.Add(report);
            SaveReports();
        }

        public void RemoveReport(Report report)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report), "Отчёт не может быть null");

            Reports.Remove(report);
            SaveReports();
        }

        public void UpdateReport(Report report, string newTitle, string newContent)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report), "Отчёт не может быть null");

            report.Title = newTitle ?? string.Empty;
            report.Content = newContent ?? string.Empty;
            SaveReports();
        }

        private void SaveReports()
        {
            try
            {
                var lines = Reports.Select(r => $"{r.Title}{Separator}{r.Content}{Separator}{r.CreationDate:yyyy-MM-dd HH:mm:ss}{Separator}{r.Category}");
                File.WriteAllLines(ReportsFilePath, lines);
            }
            catch (Exception ex)
            {
                throw new IOException($"Ошибка при сохранении файла: {ex.Message}", ex);
            }
        }

        private void LoadReports()
        {
            if (!File.Exists(ReportsFilePath))
                return;

            try
            {
                var lines = File.ReadAllLines(ReportsFilePath);
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    var parts = line.Split(Separator);
                    if (parts.Length >= 3)
                    {
                        string title = parts[0];
                        string content = parts[1];
                        DateTime creationDate;
                        string category = parts.Length >= 4 ? parts[3] : "Без категории";

                        if (DateTime.TryParse(parts[2], out creationDate))
                        {
                            Reports.Add(new Report(title, content, creationDate, category));
                        }
                    }
                }
            }
            catch
            {
                // Ошибка при загрузке - продолжаем с пустым списком
            }
        }

        public int GetReportsCount()
        {
            return Reports.Count;
        }
    }
}