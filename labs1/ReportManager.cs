using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace labs1
{
    public class ReportManager
    {
        private const string FilePath = "reports.txt";
        private const char Separator = '|';

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
                throw new ArgumentNullException(nameof(report), "Отчёт не может быть null");
            }
            Reports.Add(report);
            SaveReports();
        }

        public void RemoveReport(Report report)
        {
            if (report == null)
            {
                throw new ArgumentNullException(nameof(report), "Отчёт не может быть null");
            }
            Reports.Remove(report);
            SaveReports();
        }

        public void UpdateReport(Report report, string newTitle, string newContent)
        {
            if (report == null)
            {
                throw new ArgumentNullException(nameof(report), "Отчёт не может быть null");
            }
            report.Title = newTitle ?? string.Empty;
            report.Content = newContent ?? string.Empty;
            SaveReports();
        }

        private void SaveReports()
        {
            try
            {
                var lines = Reports.Select(r => $"{r.Title}{Separator}{r.Content}{Separator}{r.CreationDate:yyyy-MM-dd HH:mm:ss}");
                File.WriteAllLines(FilePath, lines);
            }
            catch (Exception ex)
            {
                throw new IOException($"Ошибка при сохранении файла: {ex.Message}", ex);
            }
        }

        private void LoadReports()
        {
            if (!File.Exists(FilePath))
            {
                return;
            }

            try
            {
                var lines = File.ReadAllLines(FilePath);
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    var parts = line.Split(Separator);
                    if (parts.Length == 3)
                    {
                        string title = parts[0];
                        string content = parts[1];
                        DateTime creationDate;

                        if (DateTime.TryParse(parts[2], out creationDate))
                        {
                            Reports.Add(new Report(title, content, creationDate));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке файла: {ex.Message}");
            }
        }
    }
}