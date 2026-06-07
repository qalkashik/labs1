using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using labs1;

namespace labs1.Tests
{
    [TestClass]
    public class SimpleTests
    {
        private ReportManager _manager;

        [TestInitialize]
        public void Setup()
        {
            _manager = new ReportManager();
        }

        [TestMethod]
        public void Test_AddReport()
        {
            // Очищаем
            foreach (var r in _manager.Reports.ToArray())
                _manager.RemoveReport(r);

            var report = new Report("Тест", "Содержимое", DateTime.Now);
            _manager.AddReport(report);
            Assert.AreEqual(1, _manager.Reports.Count);
        }

        [TestMethod]
        public void Test_DeleteReport()
        {
            // Очищаем
            foreach (var r in _manager.Reports.ToArray())
                _manager.RemoveReport(r);

            var report = new Report("Для удаления", "Содержимое", DateTime.Now);
            _manager.AddReport(report);
            int countBefore = _manager.Reports.Count;

            _manager.RemoveReport(report);
            int countAfter = _manager.Reports.Count;

            Assert.AreEqual(countBefore - 1, countAfter, "Отчёт не был удалён");
        }

        [TestMethod]
        public void Test_UpdateReport()
        {
            // Очищаем
            foreach (var r in _manager.Reports.ToArray())
                _manager.RemoveReport(r);

            var report = new Report("Старый", "Старое", DateTime.Now);
            _manager.AddReport(report);
            _manager.UpdateReport(report, "Новый", "Новое");
            Assert.AreEqual("Новый", report.Title);
        }

        [TestMethod]
        public void Test_AddCategory()
        {
            _manager.AddCategory("Финансы");
            Assert.IsTrue(_manager.Categories.Contains("Финансы"));
        }
    }
}