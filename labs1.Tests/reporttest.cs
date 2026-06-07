using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using labs1;

namespace labs1.Tests
{
    [TestClass]
    public class ReportTests
    {
        [TestMethod]
        public void Constructor_WithValidParameters_CreatesReport()
        {
            // Arrange
            string title = "Отчет по продажам";
            string content = "Продажи за январь...";
            DateTime date = new DateTime(2024, 1, 15);

            // Act
            var report = new Report(title, content, date);

            // Assert
            Assert.AreEqual(title, report.Title);
            Assert.AreEqual(content, report.Content);
            Assert.AreEqual(date, report.CreationDate);
        }

        [TestMethod]
        public void Title_WhenSet_UpdatesValue()
        {
            // Arrange
            var report = new Report("Старый заголовок", "Содержание", DateTime.Now);
            string newTitle = "Новый заголовок";

            // Act
            report.Title = newTitle;

            // Assert
            Assert.AreEqual(newTitle, report.Title);
        }

        [TestMethod]
        public void Content_WhenSet_UpdatesValue()
        {
            // Arrange
            var report = new Report("Заголовок", "Старое содержание", DateTime.Now);
            string newContent = "Новое содержание";

            // Act
            report.Content = newContent;

            // Assert
            Assert.AreEqual(newContent, report.Content);
        }
    }
}