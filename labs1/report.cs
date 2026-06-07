using System;

namespace labs1
{
    public class Report
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public string Category { get; set; }

        public Report(string title, string content, DateTime creationDate, string category = "Без категории")
        {
            Title = title ?? string.Empty;
            Content = content ?? string.Empty;
            CreationDate = creationDate;
            Category = category ?? "Без категории";
        }

        public override string ToString()
        {
            return $"[{Category}] {Title} - {CreationDate:yyyy-MM-dd HH:mm}";
        }
    }
}