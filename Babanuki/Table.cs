using System;
using System.Collections.Generic;
using System.Text;

namespace Babanuki
{
    /// <summary>
    /// テーブルを表すクラス。
    /// </summary>
    public class Table
    {
        // 捨てられたカードを保持しておくためのリスト
        private List<Card> disposedCards = new List<Card>();

        public void DisposedCard(Card[] cards)
        {
            for (int index = 0; index < cards.Length; index++)
            {
                // 捨てられたカードを表示する
                Console.Write(cards[index] + " ");
            }

            Console.WriteLine("を捨てました");

            // 捨てられたカードはリストに追加しておく
            disposedCards.AddRange(cards);
        }
    }
}
