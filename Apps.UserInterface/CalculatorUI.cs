//CalculatorUI.cs
using Apps.CalculatorNS.BusinessLogic;
using System;

namespace Apps.CalculatorNS.UserInterface
{
    /// <summary>
    /// The User Interface of the Calculator App
    /// </summary>
    internal class CalculatorUI
    {
        private CalculatorBL logic;
        private string name;
        /// <summary>
        /// Initializes the User Interface
        /// </summary>
        internal CalculatorUI(string name, CalculatorBL logic) 
        {
            this.name = name;
            this.logic = logic;
        }

        private delegate double Calculate(double firstOperand, double secondOperand);
        /// <summary>
        /// Main Screen of the Calculator UI
        /// </summary>
        internal void MainScreen()
        {
            Calculate[] calculations = new Calculate[] { logic.Add, logic.Subtract, logic.Multiply, logic.Divide };
            string operation = "";
            while (operation.ToUpper() != "X") {
                Console.Clear();
                Console.WriteLine($"*****{name}*****");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("X. Exit");
                Console.Write("Please Type Your Choice And Press Enter: ");
                operation = Console.ReadLine();
                int index;
                if (int.TryParse(operation, out index) && (index >=1 && index <=4))
                {
                    double n1 = askNumber("Please insert the first operand: ");
                    double n2 = askNumber("Please insert the second operand: ");
                        
                    Calculate method = calculations[index-1];
                    double result = method(n1, n2);
                    
                    Console.WriteLine($"The Result is {result}");
                    Console.ReadLine();
                }
                else if(operation.ToUpper() != "X"){
                    Console.WriteLine("Sorry, I do not understand, please try again");
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Asks the user for a number
        /// </summary>
        /// <param name="message">The message to show to the user</param>
        /// <returns>The number inserted by the user</returns>
        private double askNumber(string message) {
            bool ok = false;
            double number = 0;
            while (!ok)
            {
                Console.Write(message);
                string userInput = Console.ReadLine();
                try
                {
                    number = double.Parse(userInput);
                    ok = true;
                }
                catch
                {
                    Console.WriteLine("Sorry, I do not understand, please try again");
                    Console.ReadLine();
                }
            }
            return number;
        }
    }
}
