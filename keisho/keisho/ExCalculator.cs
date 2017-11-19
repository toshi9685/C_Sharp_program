using System;
namespace keisho
{
    class ExCalculator : calculater
    {
        public ExCalculator()
        {
        }

        public void mul()
        {
            Console.WriteLine("{0} * {1} = {2}",num1,num2,num1*num2);

        }

        public void div()
        {
            Console.WriteLine("{0} / {1} = {2}",num1,num2,num1/num2);   
        }
    }
}
