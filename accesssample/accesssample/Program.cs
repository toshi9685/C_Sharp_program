using System;

namespace accesssample
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			Person p1, p2;
			p1 = new Person();       //  一つ目のPersonクラスのメソッドのインスタンスを生成
			p2 = new Person();       //  二つ目のPersonクラスのメソッドのインスタンスを生成
			p1.Name = "山田太郎";    //  フィールドnameに値を代入
			p1.Age = 19;             //  フィールドageに値を代入
			p2.SetAgeAndName("佐藤花子", 23);   //  setAgeAndName()メソッドで、nameとageを設定
			p1.ShowAgeAndName();     //  メソッドから、名前と年齢を表示
									 //  プロパティから名前と年齢を表示
			Console.WriteLine("名前：{0} 年齢：{1}", p2.Name, p2.Age);
			Access a = new Access();
			//a.Data1 = 1;
			a.Data2 = 2;
			a.ShowDatas();
			Console.WriteLine("a.data1 = {0}", a.Data1);
			//Console.WriteLine("a.data2 = {0}", a.Data2);
		}
    }
	class Person
	{
		//  名前（フィールド）
		private string name = "";
		//  年齢（フィールド）
		private int age = 0;
		//  情報の設定
		public void SetAgeAndName(string name, int age)
		{
			this.name = name;
			this.age = age;
		}
		//  情報の表示（メソッド）
		public void ShowAgeAndName()
		{
			Console.WriteLine("名前：{0} 年齢：{1}", name, age);
		}
		//  情報の設定
		public string Name
		{
			set { name = value; }
			get { return name; }
		}
		//  情報の設定
		public int Age
		{
			set { age = value; }
			get { return age; }
		}
	}
	class Access
	{
		//  読み込みオンリーのデータ
		private int data1 = 5;
		//  書き込みオンリーのデータ
		private int data2 = 0;
		//  値の表示
		public void ShowDatas()
		{
			Console.WriteLine("data1={0} data2={1}", data1, data2);
		}
		//  data1のプロパティ（読み込みオンリー）
		public int Data1
		{
			get { return data1; }
		}
		//  data2のプロパティ（書き込みオンリー）
		public int Data2
		{
			set { data2 = value; }
		}
	}
}
