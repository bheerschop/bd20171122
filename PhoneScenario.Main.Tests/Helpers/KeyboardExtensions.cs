using WindowsInput;
using WindowsInput.Native;

namespace PhoneScenario.Main.Tests.Helpers
{
    static class KeyboardExtensions
    {
        public static IKeyboardSimulator EnterMenuItem(this IKeyboardSimulator keyboard, int item)
        {
            return keyboard
                .KeyPress(VirtualKeyCode.VK_0 + item, VirtualKeyCode.RETURN)
                .Sleep(100);
        }

        public static IKeyboardSimulator EnterExit(this IKeyboardSimulator keyboard)
        {
            return keyboard
                .KeyPress(VirtualKeyCode.VK_X, VirtualKeyCode.RETURN)
                .Sleep(100);
        }
    }
}
