using Consoleum.PageObjects;
using PhoneScenario.Main.Tests.Helpers;
using System;
using System.Diagnostics;
using System.Threading;
using WindowsInput;

namespace PhoneScenario.Main.Tests.PageObjectModel
{
    public sealed class Main : Page
    {
        public override bool IsOpen => ExistsInOutput("1. Address Book");

        public void Exit()
        {
            Driver
                .Keyboard
                .EnterExit();

            Driver
                .Keyboard
                .EnterExit();
        }

        public Calculator OpenCalculator()
        {
            Driver
                .Keyboard
                .EnterMenuItem(2);

            return NavigateTo<Calculator>();
        }
    }
}
