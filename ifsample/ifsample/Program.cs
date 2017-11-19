using System;

namespace ifsample
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int a = 0;
            //キーボードから数値を入力
            Console.WriteLine("整数を入力してください");
            while (true)//正しい値が入力されるまでループ
            {
                //try文でエラー処理
                try
                {
                    a = int.Parse(Console.ReadLine());//コンソールからの文字列を数値に変換
                }
                catch (FormatException e)
                {
                    Console.WriteLine("整数を入力してください");
                }
                if(a != 0){
                    break;
                }
            }
            Console.WriteLine(a);
            if(a > 0){
				Console.WriteLine("正の数です");
            }else{
                Console.WriteLine("正の数ではありません");
            }
        }
    }
}
