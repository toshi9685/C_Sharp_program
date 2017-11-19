using System;

namespace arrysample
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //double[] d = new double[5];
            double[] d = {1.2,1.4,1.5,4.2,2.421};
            foreach(double i in d){
                Console.WriteLine("{0}",i);
            }

            //二次元配列
			int[,] a = new int[3, 4];
			int m, n;
			//  二次元配列に値を代入
			for (m = 0; m < 3; m++)
			{
				for (n = 0; n < 4; n++)
				{
					a[m, n] = m + n;
				}
			}
			//  二次元配列に値を出力
			for (m = 0; m < 3; m++)
			{
				for (n = 0; n < 4; n++)
				{
					Console.Write("a[{0}][{1}]={2} ", m, n, a[m, n]);
				}
				Console.WriteLine();
			}
        }
    }
}
