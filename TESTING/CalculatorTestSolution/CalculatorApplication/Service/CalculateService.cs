namespace CalculatorApplication.Service
{
    public class CalculateServie
    {
        public double number1 { get; set; }
        public double number2 { get; set; }

        public double Add()
        {
            return number1 + number2;
        }

        public double subtract()
        {
            return number1 - number2;
        }

        public double Multiply()
        {
            return number1 * number2;
        }

        public double Divide()
        {
            return number1 / number2;
        }

        public double Factorial()
        {
            double f = 1;
            while (number1 > 1)
            {
                f *= number1--;
            }
            return f;

        }
    }
}
