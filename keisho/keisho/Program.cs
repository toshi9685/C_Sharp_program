using System;

namespace keisho
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //  Calculatorクラスのインスタンス
            calculater c1 = new calculater();
            c1.Num1 = 10;
            c1.Num2 = 3;
            //  足し算・引き算の結果を表示
            c1.add();
            c1.sub();
            ExCalculator c2 = new ExCalculator();
            c2.Num1 = 10;
            c2.Num2 = 3;
            //  足し算・引き算の結果を表示
            c2.add();
            c2.sub();
            //  掛け算・割り算の結果を表示
            c2.mul();
            c2.div();
        }
    }
}
