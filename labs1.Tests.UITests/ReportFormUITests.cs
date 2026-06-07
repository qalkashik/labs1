using System;
using System.Linq;
using System.Threading;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace labs1.Tests  // <--- ИСПРАВЛЕНО: убрал .UITests
{
    [TestClass]
    public class ReportFormUITests
    {
        // ИЗМЕНИТЕ ПУТЬ НА ВАШ ПОЛНЫЙ ПУТЬ К EXE
        private const string ApplicationPath = @"C:\Users\mozgo\source\repos\labs1\labs1\bin\Debug\labs1.exe";

        private FlaUI.Core.Application _app;
        private UIA3Automation _automation;
        private Window _mainWindow;

        [TestInitialize]
        public void TestInitialize()
        {
            // Запуск приложения
            _app = FlaUI.Core.Application.Launch(ApplicationPath);
            Thread.Sleep(3000);

            _automation = new UIA3Automation();
            _mainWindow = _app.GetMainWindow(_automation);
            Thread.Sleep(1000);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _automation?.Dispose();
            _app?.Close();
        }

        [TestMethod]
        public void TC001_CreateNewReport_ShouldSucceed()
        {
            var txtTitle = _mainWindow.FindFirstDescendant(cf => cf.ByName("txtTitle")).AsTextBox();
            var txtContent = _mainWindow.FindFirstDescendant(cf => cf.ByName("txtContent")).AsTextBox();
            var btnAdd = _mainWindow.FindFirstDescendant(cf => cf.ByName("btnAdd")).AsButton();

            txtTitle.Text = "Тестовый отчёт";
            txtContent.Text = "Содержимое";
            btnAdd.Click();
            Thread.Sleep(500);

            var lstReports = _mainWindow.FindFirstDescendant(cf => cf.ByName("lstReports")).AsListBox();
            Assert.IsTrue(lstReports.Items.Length > 0, "Отчёт не добавлен");
        }
    }
}