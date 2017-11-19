using System;

namespace test
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Output op = new Output();
            int a;//変数の宣言
            int b = 3;//初期化と代入を同時に行う
            int add, sub;//複数の変数を同時に宣言
            double avg;
            a = 6;
            add = a + b;
            sub = a - b;
            avg = (a + b) / 2.0;
            Console.WriteLine("{0} + {1} = {2}",a,b,add);
            Console.WriteLine("{0} - {1} = {2}",a,b,sub);
            Console.WriteLine("{0} と {1} の平均値 {2}",a,b,avg);

            double c = 1.23;
            a = (int)c;//キャスト
            Console.WriteLine("キャスト前 {0} キャスト後 {1}",c,a);

            string str1, str2;
            str1 = Console.ReadLine();
            str2 = Console.ReadLine();
            Console.WriteLine("{0}",str1+str2);
        }
    }
    /*出力用クラス*/
    class Output
    {
        public void anystr(string str){
            Console.Write(str);
            Console.WriteLine(str);
        }
    }
}
