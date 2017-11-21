//CalculatorBL.cs

namespace Apps.CalculatorNS.BusinessLogic
{
    /// <summary>
    /// The logic behind the App with 4 operations
    /// </summary>
    internal class CalculatorBL 
    {

        /// <summary>
        /// Adds two numbers
        /// </summary>
        /// <param name="num1">The first number to add</param>
        /// <param name="num2">The second number to add</param>
        /// <returns>The sum of the two numbers</returns>
        internal double Add(double num1, double num2) {
            return num1 + num2;
        }

        /// <summary>
        /// Subtract the second number from the first
        /// </summary>
        /// <param name="num1">The number from which to subtract</param>
        /// <param name="num2">The number to subtract from the first</param>
        /// <returns>The subtraction of the two numbers</returns>
        internal double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        /// <summary>
        /// Multiply two numbers
        /// </summary>
        /// <param name="num1">The first number to multiply</param>
        /// <param name="num2">The second number to multiply</param>
        /// <returns>The multiplication of the two numbers</returns>
        internal double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        /// <summary>
        /// Divide two numbers
        /// </summary>
        /// <param name="num1">The first operand of the division</param>
        /// <param name="num2">The secon operand of the division</param>
        /// <returns>The division of the two operands</returns>
        internal double Divide(double num1, double num2)
        {
            return num1 / num2;
        }
    }
}