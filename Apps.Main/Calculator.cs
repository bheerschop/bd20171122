//Calculator.cs
using Apps.CalculatorNS.BusinessLogic;
using Apps.CalculatorNS.UserInterface;
using Apps.Core;

namespace Apps.CalculatorNS
{
    /// <summary>
    /// Calculator App with 4 operations
    /// </summary>
    public class Calculator : App
    {
        private CalculatorBL logic;
        private CalculatorUI ui;
        /// <summary>
        /// Initializes a Calculator App with the name of "Calculator"
        /// </summary>
        public Calculator() : base("Calculator")
        {
            logic = new CalculatorBL();
            ui = new CalculatorUI(Name, logic);
        }

        /// <summary>
        /// It starts the Calculator
        /// </summary>
        public override void Start()
        {
            ui.MainScreen();
        }

        /// <summary>
        /// Adds two numbers
        /// </summary>
        /// <param name="num1">The first number to add</param>
        /// <param name="num2">The second number to add</param>
        /// <returns>The sum of the two numbers</returns>
        public double Add(double num1, double num2) => logic.Add(num1, num2);

        /// <summary>
        /// Subtract the second number from the first
        /// </summary>
        /// <param name="num1">The number from which to subtract</param>
        /// <param name="num2">The number to subtract from the first</param>
        /// <returns>The subtraction of the two numbers</returns>
        public double Subtract(double num1, double num2) => logic.Subtract(num1, num2);

        /// <summary>
        /// Multiply two numbers
        /// </summary>
        /// <param name="num1">The first number to multiply</param>
        /// <param name="num2">The second number to multiply</param>
        /// <returns>The multiplication of the two numbers</returns>
        public double Multiply(double num1, double num2) => logic.Multiply(num1, num2);

        /// <summary>
        /// Divide two numbers
        /// </summary>
        /// <param name="num1">The first operand of the division</param>
        /// <param name="num2">The secon operand of the division</param>
        /// <returns>The division of the two operands</returns>
        public double Divide(double num1, double num2) => logic.Divide(num1, num2);
    }
}
