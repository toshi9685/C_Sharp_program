using System;

namespace 静的メンバ
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			//  Dataクラスを3つ作る
			Data[] d = new Data[2];
			//  Dataのインスタンスの数を表示
			Data.ShowNumber();
			//  一つ目のインスタンスを生成
			for (int i = 0; i < d.Length; i++)
			{
				d[i] = new Data(i * 100);
				//  Dataのインスタンスを生成
				Data.ShowNumber();
			}
        }
    }
    class Data{
        //Dataオブジェクトの数
        private static int num = 0;
        //データの値
        private int id;
        //コンストラクタの（引数付き）
        public Data(int id){
            this.id = id;
            num++;
            Console.WriteLine("値:{0}数:{1}",this.id,num);
        }
        //オブジェクトの数を取得
        public static void ShowNumber(){
            Console.WriteLine("Dataオブジェクトの数:{0}",num);
        }
    }
}
