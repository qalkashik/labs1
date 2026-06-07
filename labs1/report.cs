using System;

namespace labs1  // ИСПРАВЛЕНО: унифицировано пространство имён
{
    public class Report
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }

        public Report(string title, string content, DateTime creationDate)
        {
            // Добавлена защита от null
            Title = title ?? string.Empty;
            Content = content ?? string.Empty;
            CreationDate = creationDate;
        }

        public override string ToString()
        {
            return $"{Title} - {CreationDate:yyyy-MM-dd}";
        }
    }
}