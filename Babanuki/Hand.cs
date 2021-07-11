using System;
using System.Collections.Generic;
using System.Text;

namespace Babanuki
{
    public class Hand
    {
        /// <summary>
        /// 手札を保持するリスト
        /// </summary>
        public List<Card> hand = new List<Card>();

        /// <summary>
        /// カードを加える
        /// </summary>
        /// <param name="card">加えるカード</param>
        public void AddCard(Card card)
        {
            hand.Add(card);
        }

        /// <summary>
        /// カードを引く
        /// </summary>
        /// <returns>引いたカード</returns>
        public Card PickCard()
        {
            Card pickedCard = hand[0];
            hand.RemoveAt(0);
            return pickedCard;
        }

        /// <summary>
        /// シャッフルする。
        /// </summary>
        public void Shuffle()
        {
            // 手札の枚数を取得
            int number = hand.Count;

            // カードを引き出す位置
            int pos;

            // カードをランダムに抜き取って最後に加える動作を繰り返す
            for (int count = 0; count < number * 2; count++)
            {
                // ランダムな位置からカードを１枚抜き取る
                var random = new Random();
                pos = random.Next() * number;
                Card pickedCard = hand[pos];
                hand.RemoveAt(pos);

                // 抜き取ったカードを最後に加える
                hand.Add(pickedCard);
            }
        }

        /// <summary>
        /// 枚数を数える
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfCards()
        {
            return hand.Count;
        }

        /// <summary>
        /// 同じ数のカードを探す。
        /// 同じ数のカードがない場合はnullを返します。
        /// </summary>
        /// <returns></returns>
        public Card[] FindSameNumberCard()
        {
            int numberOfCards = hand.Count;
            Card[] sameCards = null;

            // 手札にカードが1枚もない場合は何もしない
            if (numberOfCards < 1)
            {
                return sameCards;
            }

            // 最後に追加されたカードを取得する
            int lastIndex = numberOfCards - 1;
            Card lastAddedCard = hand[lastIndex];

            // 最後に追加されたカードの数字を取得する
            int lastAddedCardNum = lastAddedCard.Number;

            for (int index = 0; index < lastIndex; index++)
            {
                Card card = hand[index];
                if (card.Number == lastAddedCardNum)
                {
                    // 最後に追加されたカードと同じカードが見つかった場合
                    // 見つかった組み合わせをsameCardsに格納し、ループを抜ける
                    sameCards = new Card[2];
                    sameCards[0] = hand[lastIndex];
                    hand.RemoveAt(lastIndex);
                    sameCards[1] = hand[index];
                    hand.RemoveAt(index);

                    break;
                }

                // 同じ数の組み合わせが見つからなかった場合、
                // sameCardsはnullのままとなる
            }

            return sameCards;
        }

        public string GetHandString()
        {
            string str = string.Empty;

            int size = hand.Count;
            if (size <= 0) return str;

            for (int index = 0; index < size; index++)
            {
                Card card = hand[index];
                str += card.GetStringCard();
            }

            return str;
        }
    }
}
