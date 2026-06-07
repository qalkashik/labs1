using System;
using System.Linq;
using labs1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace labs1.Tests
{
    [TestClass]
    public class AutoTests
    {
        private ReportManager _manager;

        [TestInitialize]
        public void Setup()
        {
            // Создаём НОВЫЙ менеджер перед каждым тестом
            _manager = new ReportManager();
        }

        // ========== ТЕСТЫ ИЗ ЛАБОРАТОРНОЙ №3 ==========

        [TestMethod]
        public void TC001_CreateReport_ShouldSucceed()
        {
            // Очищаем отчёты перед тестом
            foreach (var r in _manager.Reports.ToArray())
                _manager.RemoveReport(r);

            var report = new Report("Отчёт по продажам", "Продажи за январь", DateTime.Now);
            _manager.AddReport(report);
            Assert.AreEqual(1, _manager.Reports.Count);
            Assert.AreEqual("Отчёт по продажам", _manager.Reports[0].Title);
        }

        [TestMethod]
        public void TC002_AddNullReport_ShouldThrowException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _manager.AddReport(null));
        }

        [TestMethod]
        public void TC003_DeleteReport_ShouldRemove()
        {
            // Очищаем отчёты перед тестом
            foreach (var r in _manager.Reports.ToArray())
                _manager.RemoveReport(r);

            var report = new Report("Для удаления", "Содержимое", DateTime.Now);
            _manager.AddReport(report);
            Assert.AreEqual(1, _manager.Reports.Count);

            _manager.RemoveReport(report);
            Assert.AreEqual(0, _manager.Reports.Count);
        }

        [TestMethod]
        public void TC004_DeleteNullReport_ShouldThrowException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _manager.RemoveReport(null));
        }

        [TestMethod]
        public void TC005_UpdateReport_ShouldChangeData()
        {
            // Очищаем отчёты перед тестом
            foreach (var r in _manager.Reports.ToArray())
                _manager.RemoveReport(r);

            var report = new Report("Старый", "Старое", DateTime.Now);
            _manager.AddReport(report);

            _manager.UpdateReport(report, "Новый заголовок", "Новое содержание");

            Assert.AreEqual("Новый заголовок", report.Title);
            Assert.AreEqual("Новое содержание", report.Content);
        }

        [TestMethod]
        public void TC006_UpdateNullReport_ShouldThrowException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _manager.UpdateReport(null, "Title", "Content"));
        }

        // ========== ТЕСТЫ ИЗ ЛАБОРАТОРНОЙ №5 (КАТЕГОРИЗАЦИЯ) ==========

        [TestMethod]
        public void TC007_AddCategory_ShouldAdd()
        {
            _manager.AddCategory("Финансовые отчёты");
            Assert.IsTrue(_manager.Categories.Contains("Финансовые отчёты"));
        }

        [TestMethod]
        public void TC008_AddEmptyCategory_ShouldThrowException()
        {
            Assert.ThrowsException<ArgumentException>(() => _manager.AddCategory(""));
        }

        [TestMethod]
        public void TC009_AddDuplicateCategory_ShouldThrowException()
        {
            // Очищаем категории перед тестом
            var categoriesToRemove = _manager.Categories.Except(new[] { "Без категории" }).ToList();
            foreach (var cat in categoriesToRemove)
            {
                try { _manager.RemoveCategory(cat); } catch { }
            }

            _manager.AddCategory("Личные");

            // Должно выбросить исключение
            Assert.ThrowsException<InvalidOperationException>(() => _manager.AddCategory("Личные"));
        }

        [TestMethod]
        public void TC010_RemoveCategory_ShouldRemove()
        {
            _manager.AddCategory("Удаляемая");
            Assert.IsTrue(_manager.Categories.Contains("Удаляемая"));

            _manager.RemoveCategory("Удаляемая");
            Assert.IsFalse(_manager.Categories.Contains("Удаляемая"));
        }

        [TestMethod]
        public void TC011_RemoveDefaultCategory_ShouldThrowException()
        {
            Assert.ThrowsException<InvalidOperationException>(() => _manager.RemoveCategory("Без категории"));
        }

        [TestMethod]
        public void TC012_CreateReportWithCategory_ShouldHaveCategory()
        {
            _manager.AddCategory("Маркетинг");
            var report = new Report("Маркетинговый отчёт", "Содержимое", DateTime.Now, "Маркетинг");
            _manager.AddReport(report);

            Assert.AreEqual("Маркетинг", report.Category);
        }

        [TestMethod]
        public void TC013_FilterByCategory_ShouldWork()
        {
            // Очищаем отчёты
            foreach (var r in _manager.Reports.ToArray())
                _manager.RemoveReport(r);

            // Очищаем категории (кроме "Без категории")
            var categoriesToRemove = _manager.Categories.Except(new[] { "Без категории" }).ToList();
            foreach (var cat in categoriesToRemove)
            {
                try { _manager.RemoveCategory(cat); } catch { }
            }

            // Добавляем нужные категории
            _manager.AddCategory("Финансы");
            _manager.AddCategory("Личные");

            // Добавляем отчёты
            var report1 = new Report("Финансовый", "Содержимое", DateTime.Now, "Финансы");
            var report2 = new Report("Личный", "Содержимое", DateTime.Now, "Личные");

            _manager.AddReport(report1);
            _manager.AddReport(report2);

            // Проверяем фильтрацию
            var financeReports = _manager.GetReportsByCategory("Финансы");

            Assert.AreEqual(1, financeReports.Count, "Должен быть 1 отчёт в категории Финансы");
            Assert.AreEqual("Финансовый", financeReports[0].Title);
        }
    }
}