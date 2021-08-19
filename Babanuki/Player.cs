using System;
using System.Collections.Generic;
using System.Text;

namespace Babanuki
{
    public class Player
    {
        /// <summary>
        /// 進行役
        /// </summary>
        private Master master;

        /// <summary>
        /// テーブル
        /// </summary>
        private Table table;

        /// <summary>
        /// 自分の手札
        /// </summary>
        private Hand myHand = new Hand();

        /// <summary>
        /// 名前
        /// </summary>
        private string name;

        public Player(string name, Master master, Table table)
        {
            this.name = name;
            this.master = master;
            this.table = table;
        }

        public void Play(Player nextPrayer)
        {
            // 次のプレイヤーに手札を出してもらう
            Hand nextHand = nextPrayer.ShowHand();

            // 相手の手札からカードを1枚引く
            Card pickedCard = nextHand.PickCard();

            // 引いた結果を表示
            Console.WriteLine(name + ":" + nextPrayer + "さんから" + pickedCard + "を引きました");

            // 引いたカードを自分の手札に加え、同じ数のカードがあったら捨てる
            DealCard(pickedCard);

            // 手札がゼロになったかどうか調べる
            if (myHand.GetNumberOfCards() == 0)
            {
                // 進行役に上がりを宣言する
                master.declareWin(name);
            }
            else
            {
                // 現在の手札を表示する
                Console.WriteLine(name + ":残りの手札は" + myHand + "です");
            }
        }

        /// <summary>
        /// 手札を見せる。
        /// </summary>
        /// <returns>自分の手札</returns>
        public Hand ShowHand()
        {
            if (myHand.GetNumberOfCards() == 1)
            {
                master.DeclareWin(name);
            }

            // 見せる前にシャッフルする
            myHand.Shuffle();

            return myHand;
        }

        /// <summary>
        /// カードを受け取る。
        /// </summary>
        /// <param name="card"></param>
        public void ReceiveCard(Card card)
        {
            // 引いたカードを自分の手札に加え、同じ数のカードがあったら捨てる
            DealCard(card);
        }

        /// <summary>
        /// カードを自分の手札に加え、同じ数のカードがあったら捨てる。
        /// </summary>
        /// <param name="card"></param>
        private void DealCard(Card card)
        {
            // カードを自分の手札に加える
            myHand.AddCard(card);

            // 今加えたカードと同じカードを探す
            Card[] sameCards = myHand.FindSameNumberCard();

            // 同じカードの組み合わせが存在した場合
            if (sameCards != null)
            {
                // テーブルへカードを捨てる
                Console.WriteLine(name + "：");
                table.DisposedCard(sameCards);
            }
        }
    }
}
