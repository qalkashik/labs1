using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using labs1;

namespace labs1.Tests
{
    [TestClass]
    public class ReportManagerTests
    {
        private ReportManager _reportManager;
        private string _testFilePath = "reports.txt";
        private Report _testReport;

        [TestInitialize]
        public void SetUp()
        {
            // Удаляем существующий файл перед каждым тестом для чистоты
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
            _reportManager = new ReportManager();
            _testReport = new Report("Тестовый отчет", "Тестовое содержание", DateTime.Now);
        }

        [TestCleanup]
        public void CleanUp()
        {
            // Очищаем файл после тестов
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }

        [TestMethod]
        public void Constructor_WhenNoFile_InitializesEmptyList()
        {
            // Assert
            Assert.IsNotNull(_reportManager.Reports);
            Assert.AreEqual(0, _reportManager.Reports.Count);
        }

        [TestMethod]
        public void AddReport_WithValidReport_AddsToList()
        {
            // Act
            _reportManager.AddReport(_testReport);

            // Assert
            Assert.AreEqual(1, _reportManager.Reports.Count);
            Assert.AreSame(_testReport, _reportManager.Reports[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddReport_WithNullReport_ThrowsArgumentNullException()
        {
            // Act
            _reportManager.AddReport(null);
        }

        [TestMethod]
        public void AddReport_SavesToFile()
        {
            // Act
            _reportManager.AddReport(_testReport);

            // Assert
            Assert.IsTrue(File.Exists(_testFilePath));
            string fileContent = File.ReadAllText(_testFilePath);
            Assert.IsTrue(fileContent.Contains(_testReport.Title));
        }

        [TestMethod]
        public void RemoveReport_WithExistingReport_RemovesFromList()
        {
            // Arrange
            _reportManager.AddReport(_testReport);
            Assert.AreEqual(1, _reportManager.Reports.Count);

            // Act
            _reportManager.RemoveReport(_testReport);

            // Assert
            Assert.AreEqual(0, _reportManager.Reports.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveReport_WithNullReport_ThrowsArgumentNullException()
        {
            // Act
            _reportManager.RemoveReport(null);
        }

        [TestMethod]
        public void RemoveReport_WithNonExistentReport_DoesNothing()
        {
            // Arrange
            var otherReport = new Report("Другой", "Другое", DateTime.Now);
            _reportManager.AddReport(_testReport);
            int initialCount = _reportManager.Reports.Count;

            // Act
            _reportManager.RemoveReport(otherReport);

            // Assert
            Assert.AreEqual(initialCount, _reportManager.Reports.Count);
        }

        [TestMethod]
        public void UpdateReport_WithValidData_UpdatesReportProperties()
        {
            // Arrange
            _reportManager.AddReport(_testReport);
            string newTitle = "Обновленный заголовок";
            string newContent = "Обновленное содержание";

            // Act
            _reportManager.UpdateReport(_testReport, newTitle, newContent);

            // Assert
            Assert.AreEqual(newTitle, _testReport.Title);
            Assert.AreEqual(newContent, _testReport.Content);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateReport_WithNullReport_ThrowsArgumentNullException()
        {
            // Act
            _reportManager.UpdateReport(null, "Title", "Content");
        }

        [TestMethod]
        public void UpdateReport_SavesChangesToFile()
        {
            // Arrange
            _reportManager.AddReport(_testReport);
            string newTitle = "Сохраненный заголовок";
            string newContent = "Сохраненное содержание";

            // Act
            _reportManager.UpdateReport(_testReport, newTitle, newContent);

            // Assert
            string fileContent = File.ReadAllText(_testFilePath);
            Assert.IsTrue(fileContent.Contains(newTitle));
            Assert.IsTrue(fileContent.Contains(newContent));
        }
    }
}