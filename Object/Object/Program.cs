using System;

namespace Object
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			Person p1, p2;
			p1 = new Person();  //  一つ目のPersonクラスのメソッドのインスタンスを生成
			p2 = new Person();  //  二つ目のPersonクラスのメソッドのインスタンスを生成
			p1.name = "山田太郎";   //  フィールドnameに値を代入
			p1.age = 19;            //  フィールドageに値を代入
			p2.SetAgeAndName("佐藤花子", 23);   //  setAgeAndName()メソッドで、nameとageを設定
											//  showAgeAndName()メソッドで、それぞれのインスタンスのnameとageを表示
			p1.ShowAgeAndName();
			p2.ShowAgeAndName();
			Calc calc = new Calc();
			int a = 1, b = 2, c = 3;
			int ans1 = calc.Add(a, b);
			int ans2 = calc.Add(a, b, c);
			Console.WriteLine("{0} + {1} = {2}", a, b, ans1);
			Console.WriteLine("{0} + {1} + {2} = {3}", a, b, c, ans2);
        }
    }
	class Person
	{
		//  名前（フィールド）
		public string name = "";
		//  年齢（フィールド）
		public int age = 0;
		//  情報の表示（メソッド）
		public void ShowAgeAndName()
		{
			Console.WriteLine("名前：{0} 年齢：{1}", name, age);
		}
		//  情報の設定
		public void SetAgeAndName(string name, int age)
		{
			this.name = name;
			this.age = age;
		}
	}
	class Calc
	{
        //引数の違う同名のメソッドが存在できる(オーバーロード)
		//  二つの整数の引数の和を求める
		public int Add(int a, int b)
		{
			return a + b;
		}
		//  三つの整数の引数の和を求める
		public int Add(int a, int b, int c)
		{
			return a + b + c;
		}
	}
}
