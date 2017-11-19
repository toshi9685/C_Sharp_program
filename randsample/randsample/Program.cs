using System;

namespace randsample
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("6が出たら終了");
            while(true){
                int dice = rnd.Next(1,7);//1以上7未満の乱数を発生させる
                Console.WriteLine(dice);
                if(dice == 6){
                    break;//ループから抜ける
                }
            }
            Console.WriteLine("終了");
        }
    }
}
