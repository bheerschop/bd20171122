using Consoleum.PageObjects;
using PhoneScenario.Main.Tests.Helpers;
using WindowsInput.Native;

namespace PhoneScenario.Main.Tests.PageObjectModel
{
    public class Calculator : Page
    {
        public Main Exit()
        {
            Driver
                .Keyboard
                .EnterExit();

            return NavigateTo<Main>();
        }

        public Calculator EnterInput(int number)
        {
            Driver
                .Keyboard
                .KeyPress(VirtualKeyCode.VK_0 + number, VirtualKeyCode.RETURN)
                .Sleep(100);

            return this;
        }

        public override bool IsOpen => ExistsInOutput(@"\*\*\*Calculator\*\*\*");

        public int Result()
        {
            return int.Parse(FindInOutput(@"(?<=The Result is )\d+"));
        }

        public Calculator ChooseAdd()
        {
            Driver
                .Keyboard
                .EnterMenuItem(1);

            return this;
        }

        public Calculator CloseResult()
        {
            Driver
                .Keyboard
                .KeyPress(VirtualKeyCode.RETURN)
                .Sleep(100);

            return this;
        }
    }
}
