using System;
// Dictionaryを使うために必要な名前空間の宣言
using System.Collections.Generic;

namespace 形態素解析
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            /*文頭:0
             *接尾辞:1
             *連体詞:2
             *名詞:3
             *助詞:4
             *動詞:5
             *文末:6
            */
            //品詞名
            string[] part = { "文頭", "接尾辞", "連体詞", "名詞", "助詞", "動詞", "文末" };
            //品詞のコスト
            Dictionary<int, int> partcost = new Dictionary<int, int>() { { 0, 0 }, { 1, 100 }, { 2, 10 }, { 3, 40 }, { 4, 10 }, { 5, 40 }, { 6, 0 } };
            //setup
            MultiDictionary<string, int> WordDic = new MultiDictionary<string, int>();//単語辞書
            WordDic.Add("こ", 1);
            WordDic.Add("個", 1);
            WordDic.Add("この", 2);
            WordDic.Add("人", 3);
            WordDic.Add("ひと", 3);
            WordDic.Add("ヒト", 3);
            WordDic.Add("一言", 3);
            WordDic.Add("ひとこと", 3);
            WordDic.Add("ひ", 3);
            WordDic.Add("日", 3);
            WordDic.Add("と", 4);
            WordDic.Add("こと", 3);
            WordDic.Add("事", 3);
            WordDic.Add("で", 4);
            WordDic.Add("で", 5);
            WordDic.Add("元気", 3);
            WordDic.Add("になった", 5);
            WordDic.Add("に", 4);
            WordDic.Add("なった", 5);
            WordDic.Add("。", 6);
            WordDic.Add(".", 6);
            WordDic.Add("文頭", 0);

            int[,] RerationDic = {//コスト付き連接可能性辞書
                {0,0,10,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,10,0,0,0},
                {0,0,0,10,10,40,10},
                {0,0,0,10,0,10,0},
                {0,0,0,10,0,0,10},
                {0,0,0,0,0,0,0}
            };
            /*int[,] RerationDic = {//連接可能性辞書
                {0,0,1,1,0,1,0},
                {0,0,0,0,0,0,0},
                {0,0,0,1,0,0,0},
                {0,0,0,1,1,1,1},
                {0,0,0,1,0,1,0},
                {0,0,0,1,0,0,0},
                {0,0,0,0,0,0,0}
            };*/

            //結果
            ResultData pnode = new ResultData();//初期ノード
            ResultData p;
            pnode.Strnum = 0;
            pnode.value = "文頭";
            pnode.rerative = 0;
            pnode.Costnum = partcost[0];
            pnode.parent = null;
            string stTarget = null;//入力された文字列から切り出した文字列
            int min = 0, max = 1;//切り出す範囲
            int stLength = 0;//文字列の長さ


            //形態素解析
            string str = Console.ReadLine();//標準入力
            if (str == "break" || str.Length < 2)
            {//breakが入力された時終了
                Console.Write("終了");
            }

            stLength = str.Length;//文字数を代入
                                  //パターン1
            while (true)
            {
                stTarget = str.Substring(min, max);//切り出す
                if (WordDic.ContainsKey(stTarget))
                {//keyが存在するかどうか
                    foreach (var n in WordDic[stTarget])
                    {
                        p = new ResultData();
                        p.value = stTarget;//単語
                        p.rerative = n;//品詞
                        p.Costnum = partcost[n];

                        ResultData.SearchNode(pnode, p, min, max, RerationDic, partcost);//ツリーに登録
                    }
                }
                else
                {//登録されていない単語
                 //Console.WriteLine(stTarget+" 登録されていません");
                }

                min--;//一文字左にずらす
                if (min == -1 && max == stLength)
                {//minが最後まで行ったら終了
                 //最後に文末を入れる
                    min = max;
                    max = 1;
                    p = new ResultData();
                    p.value = "。";//単語
                    p.rerative = 6;//品詞
                    p.Costnum = partcost[6];
                    ResultData.SearchNode(pnode, p, min, max, RerationDic, partcost);//ツリーに登録

                    Console.WriteLine();
                    ResultData.ShowNode(part);
                    //ResultData.ShowNode(pnode,part);
                    break;
                }
                if (min == -1)
                {//maxが最後まで行ったらminを+1
                 //min = difpoint;
                    min = max;
                    max = 0;
                }
                max++;//一文字増やす
            }

            str = null;
            max = 1;
            min = 0;

        }
    }
    /// <summary>
    /// 結果用クラスツリー
    /// </summary>
    public class ResultData
    {
        /// <summary>
        /// データ　単語
        /// </summary>
        public string value;
        /// <summary>
        /// データ　品詞
        /// </summary>
        public int rerative;
        /// <summary>
        /// 現ノードまでの文字数
        /// </summary>
        public int Strnum;
        /// <summary>
        /// 現ノードまでのコスト
        /// </summary>
        public int Costnum;
        /// <summary>
        /// 親要素
        /// </summary>
        public ResultData parent;
        /// <summary>
        /// 子要素
        /// </summary>
        public List<ResultData> children = new List<ResultData>();
        /// <summary>
        /// 結果出力用配列
        /// </summary>
        private static MultiDictionary<int, string> ResultWord = new MultiDictionary<int, string>();
        /// <summary>
        /// 結果出力用配列の添え字
        /// </summary>
        private static int i = 0;

        //最小コスト求める用
        /// <summary>
        /// 深さまでのコスト
        /// </summary>
        private static Dictionary<int, int> depthcost = new Dictionary<int, int>() { { 0, 0 } };
        /// <summary>
        /// 最小コスト
        /// </summary>
        private static int mincost = 999999;
        /// <summary>
        /// 結果
        /// </summary>
        public static ResultData ma = new ResultData();

        /// <summary>
        /// Searchs and push the node.
        /// </summary>
        /// <returns>The node.</returns>
        /// <param name="hoge">ResultDataのインスタンス</param>
        public static void SearchNode(ResultData hoge, ResultData input, int min, int max, int[,] rerationdic, Dictionary<int, int> partcost)
        {
            if (hoge.children.Count != 0)
            {
                foreach (ResultData n in hoge.children)
                {
                    SearchNode(n, input, min, max, rerationdic, partcost);
                }
                if (rerationdic[hoge.rerative, input.rerative] != 0)
                {
                    if (hoge.Strnum == min)
                    {
                        ResultData q = new ResultData();
                        q.value = input.value;
                        q.rerative = input.rerative;
                        q.Strnum = hoge.Strnum + max;
                        q.parent = hoge;
                        q.Costnum = hoge.Costnum + partcost[q.rerative] + rerationdic[hoge.rerative, input.rerative];
                        hoge.children.Add(q);
                        if (q.rerative == 6)
                        {
                            if (mincost > q.Costnum)
                            {
                                mincost = q.Costnum;
                                ma = q;
                            }

                        }
                        //Console.WriteLine(depthcost[q.Depth]+";"+q.Costnum + ":" + q.Depth+":"+mincost);
                    }

                }
            }
            else
            {
                if (rerationdic[hoge.rerative, input.rerative] != 0)
                {
                    if (hoge.Strnum == min)
                    {

                        ResultData q = new ResultData();
                        q.value = input.value;
                        q.rerative = input.rerative;
                        q.Strnum = hoge.Strnum + max;
                        q.Costnum = hoge.Costnum + partcost[q.rerative] + rerationdic[hoge.rerative, input.rerative];
                        q.parent = hoge;
                        hoge.children.Add(q);
                        if (q.rerative == 6)
                        {
                            if (mincost > q.Costnum)
                            {
                                mincost = q.Costnum;
                                ma = q;
                            }
                        }
                        //Console.WriteLine(depthcost[q.Depth] + ";" + q.Costnum + ":" + q.Depth+ ":" + mincost);
                    }
                }
            }
        }

        /// <summary>
        /// コスト最小表示.Shows the node.
        /// </summary>
        /// <param name="part">連接可能性辞書</param>
        public static void ShowNode(string[] part)
        {
            while (ma.parent != null)
            {
                if (ma.value != "。" && ma.value != "文頭")
                {
                    ResultWord.Add(i, ma.value, part[ma.rerative]);
                    //Console.WriteLine(ma.value + "(" + part[ma.rerative] + ")");
                }
                i++;
                ma = ma.parent;
            }
            i--;
            while (i >= 1)
            {
                int j = 0;
                foreach (var val in ResultWord[i])//表示
                {
                    if (j % 2 == 0)
                    {
                        Console.Write(val);
                        j++;
                    }
                    else
                    {
                        Console.Write("(" + val + ")");
                        j = 0;
                    }
                }
                i--;
            }
            Console.WriteLine("\n");
        }


        /*
        /// <summary>
        /// ノードを全て表示.Shows the node.
        /// </summary>
        /// <param name="node">Node.</param>
        /// <param name="part">連接可能性辞書</param>
        public static void ShowNode(ResultData node,string[] part){
            
            if (node.children.Count != 0)
            {
                if(node.parent != null){
                    ResultWord.Add(i,node.value,part[node.rerative]);//配列に追加
                    i++;
                }
                foreach (ResultData n in node.children)
                {
                    ShowNode(n,part);
                    ResultWord.Remove(i);//一つ下のノードの配列を削除
                }
                i--;
            }
            else
            {
                if (node.parent != null)
                {
                    ResultWord.Add(i, node.value, part[node.rerative]);//配列に追加
                }
                foreach (var pair in ResultWord)//表示
                {
                    int j = 0;
                    foreach (var n in pair.Value)
                    {
                        if(j%2 == 0){
                            Console.Write(n);
                            j++;
                        }else{
                            Console.Write("("+n+")");
                            j = 0;
                        }
                    }
                }
                Console.WriteLine();//改行
            }

        }
        */
    }

    /// <summary>
    /// キーと複数の値のコレクションを表します
    /// </summary>
    public class MultiDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, List<TValue>> mDictionary = new Dictionary<TKey, List<TValue>>();

        /// <summary>
        /// 指定したキーに関連付けられている複数の値を取得または設定します
        /// </summary>
        public List<TValue> this[TKey key]
        {
            get { return mDictionary[key]; }
            set { mDictionary[key] = value; }
        }

        /// <summary>
        /// キーを格納しているコレクションを取得します
        /// </summary>
        public Dictionary<TKey, List<TValue>>.KeyCollection Keys
        {
            get { return mDictionary.Keys; }
        }

        /// <summary>
        /// 複数の値を格納しているコレクションを取得します
        /// </summary>
        public Dictionary<TKey, List<TValue>>.ValueCollection Values
        {
            get { return mDictionary.Values; }
        }

        /// <summary>
        /// 格納されているキーと値のペアの数を取得します
        /// </summary>
        public int Count
        {
            get { return mDictionary.Count; }
        }

        /// <summary>
        /// 指定したキーと値をディクショナリに追加します
        /// </summary>
        public void Add(TKey key, TValue value)
        {
            if (!mDictionary.ContainsKey(key))
            {
                mDictionary.Add(key, new List<TValue>());
            }
            mDictionary[key].Add(value);
        }

        /// <summary>
        /// 指定したキーと複数の値をディクショナリに追加します
        /// </summary>
        public void Add(TKey key, params TValue[] values)
        {
            foreach (var n in values)
            {
                Add(key, n);
            }
        }

        /// <summary>
        /// 指定したキーと複数の値をディクショナリに追加します
        /// </summary>
        public void Add(TKey key, IEnumerable<TValue> values)
        {
            foreach (var n in values)
            {
                Add(key, n);
            }
        }

        /// <summary>
        /// 指定したキーを持つ値を削除します
        /// </summary>
        public bool Remove(TKey key, TValue value)
        {
            return mDictionary[key].Remove(value);
        }

        /// <summary>
        /// 指定したキーを持つ複数の値を削除します
        /// </summary>
        public bool Remove(TKey key)
        {
            return mDictionary.Remove(key);
        }

        /// <summary>
        /// すべてのキーと複数の値を削除します
        /// </summary>
        public void Clear()
        {
            mDictionary.Clear();
        }

        /// <summary>
        /// 指定したキーと値が格納されているかどうかを判断します
        /// </summary>
        public bool Contains(TKey key, TValue value)
        {
            return mDictionary[key].Contains(value);
        }

        /// <summary>
        /// 指定したキーが格納されているかどうかを判断します
        /// </summary>
        public bool ContainsKey(TKey key)
        {
            return mDictionary.ContainsKey(key);
        }

        /// <summary>
        /// 反復処理する列挙子を返します
        /// </summary>
        public IEnumerator<KeyValuePair<TKey, List<TValue>>> GetEnumerator()
        {
            foreach (var n in mDictionary)
            {
                yield return n;
            }
        }
    }

}
