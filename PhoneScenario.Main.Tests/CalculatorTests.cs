using Consoleum;
using Consoleum.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneScenario.Main.Tests.Helpers;
using PhoneScenario.Main.Tests.PageObjectModel;
using Shouldly;
using System;

namespace PhoneScenario.Main.Tests
{
    [DeploymentItem("PhoneScenario.Main.exe")]
    [TestClass]
    public class CalculatorTests
    {
        IConsoleDriver driver;

        [TestInitialize]
        public void Intialize()
        {
            driver = new ConsoleDriver("PhoneScenario.Main.exe");
            driver.Start();
        }

        [TestCleanup]
        public void CleanUp()
        {
            (driver as IDisposable)?.Dispose();
        }

        [TestMethod]
        public void TestAdd()
        {
            var calculator = driver
                .StartWith<PageObjectModel.Main>()
                .OpenCalculator();

            calculator
                .ChooseAdd()
                .EnterInput(5)
                .EnterInput(3)
                .Result().ShouldBe(8);

            calculator
                .CloseResult()
                .Exit()
                .Exit();
        }
    }
}
