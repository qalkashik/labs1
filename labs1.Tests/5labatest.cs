using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using labs1;

namespace labs1.Tests
{
    [TestClass]
    public class CategoryTests
    {
        private ReportManager _manager;
        private string _reportsFile = "reports.txt";
        private string _categoriesFile = "categories.txt";

        [TestInitialize]
        public void SetUp()
        {
            if (File.Exists(_reportsFile)) File.Delete(_reportsFile);
            if (File.Exists(_categoriesFile)) File.Delete(_categoriesFile);
            _manager = new ReportManager();
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (File.Exists(_reportsFile)) File.Delete(_reportsFile);
            if (File.Exists(_categoriesFile)) File.Delete(_categoriesFile);
        }

        // TC-CAT-001: Добавление новой категории
        [TestMethod]
        public void AddCategory_ValidName_AddsCategory()
        {
            // Act
            _manager.AddCategory("Тестовая категория");

            // Assert
            Assert.IsTrue(_manager.Categories.Contains("Тестовая категория"));
        }

        // TC-CAT-002: Добавление категории с пустым именем
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddCategory_EmptyName_ThrowsException()
        {
            // Act
            _manager.AddCategory("");
        }

        // TC-CAT-003: Добавление дублирующейся категории
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddCategory_DuplicateName_ThrowsException()
        {
            // Arrange
            _manager.AddCategory("Категория1");

            // Act
            _manager.AddCategory("Категория1");
        }

        // TC-CAT-004: Удаление существующей категории
        [TestMethod]
        public void RemoveCategory_ValidName_RemovesCategory()
        {
            // Arrange
            _manager.AddCategory("Категория для удаления");

            // Act
            _manager.RemoveCategory("Категория для удаления");

            // Assert
            Assert.IsFalse(_manager.Categories.Contains("Категория для удаления"));
        }

        // TC-CAT-005: Удаление категории "Без категории"
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveCategory_DefaultCategory_ThrowsException()
        {
            // Act
            _manager.RemoveCategory("Без категории");
        }

        // TC-CAT-006: Удаление несуществующей категории
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveCategory_NonExistentCategory_ThrowsException()
        {
            // Act
            _manager.RemoveCategory("Несуществующая категория");
        }

        // TC-CAT-007: Назначение категории отчёту
        [TestMethod]
        public void UpdateReportCategory_ValidCategory_UpdatesReportCategory()
        {
            // Arrange
            var report = new Report("Отчёт", "Содержание", DateTime.Now, "Без категории");
            _manager.AddReport(report);
            _manager.AddCategory("Финансы");

            // Act
            _manager.UpdateReportCategory(report, "Финансы");

            // Assert
            Assert.AreEqual("Финансы", report.Category);
        }

        // TC-CAT-008: Назначение несуществующей категории
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UpdateReportCategory_NonExistentCategory_ThrowsException()
        {
            // Arrange
            var report = new Report("Отчёт", "Содержание", DateTime.Now);
            _manager.AddReport(report);

            // Act
            _manager.UpdateReportCategory(report, "Несуществующая категория");
        }

        // TC-CAT-009: Фильтрация отчётов по категории
        [TestMethod]
        public void GetReportsByCategory_ReturnsCorrectReports()
        {
            // Arrange
            _manager.AddCategory("Финансы");
            _manager.AddCategory("Техника");

            var report1 = new Report("Финансовый отчёт", "Содержание", DateTime.Now, "Финансы");
            var report2 = new Report("Технический отчёт", "Содержание", DateTime.Now, "Техника");
            var report3 = new Report("Личный отчёт", "Содержание", DateTime.Now, "Без категории");

            _manager.AddReport(report1);
            _manager.AddReport(report2);
            _manager.AddReport(report3);

            // Act
            var financeReports = _manager.GetReportsByCategory("Финансы");
            var techReports = _manager.GetReportsByCategory("Техника");
            var defaultReports = _manager.GetReportsByCategory("Без категории");

            // Assert
            Assert.AreEqual(1, financeReports.Count);
            Assert.AreEqual(1, techReports.Count);
            Assert.AreEqual(1, defaultReports.Count);
            Assert.AreEqual("Финансовый отчёт", financeReports[0].Title);
        }

        // TC-CAT-010: Сохранение и загрузка категорий
        [TestMethod]
        public void Categories_SaveAndLoad_PersistCorrectly()
        {
            // Arrange
            _manager.AddCategory("Категория1");
            _manager.AddCategory("Категория2");

            // Сохраняем
            var categoriesFile = "categories.txt";
            Assert.IsTrue(File.Exists(categoriesFile));

            // Act - создаём новый менеджер для загрузки
            var newManager = new ReportManager();

            // Assert
            Assert.IsTrue(newManager.Categories.Contains("Категория1"));
            Assert.IsTrue(newManager.Categories.Contains("Категория2"));
        }

        // TC-CAT-011: Сохранение отчёта с категорией
        [TestMethod]
        public void Report_SaveWithCategory_LoadsCorrectly()
        {
            // Arrange
            _manager.AddCategory("Финансы");
            var report = new Report("Отчёт с категорией", "Содержание", DateTime.Now, "Финансы");
            _manager.AddReport(report);

            // Act
            var newManager = new ReportManager();

            // Assert
            Assert.AreEqual(1, newManager.Reports.Count);
            Assert.AreEqual("Финансы", newManager.Reports[0].Category);
        }

        // TC-CAT-012: При удалении категории отчёты перемещаются в "Без категории"
        [TestMethod]
        public void RemoveCategory_MovesReportsToDefaultCategory()
        {
            // Arrange
            _manager.AddCategory("Старая категория");
            var report = new Report("Отчёт", "Содержание", DateTime.Now, "Старая категория");
            _manager.AddReport(report);

            // Act
            _manager.RemoveCategory("Старая категория");

            // Assert
            Assert.AreEqual("Без категории", report.Category);
        }
    }
}