using System;
using System.Collections.Generic;
using System.Text;

namespace Babanuki
{
    /// <summary>
    /// トランプのカードを表すクラス。
    /// </summary>
    public class Card
    {
        /// <summary>
        /// ジョーカーを表す定数
        /// </summary>
        public const int JOKER = 0;

        /// <summary>
        /// スペードを表す定数
        /// </summary>
        public const int SUIT_SPADE = 1;

        /// <summary>
        /// ダイヤを表す定数
        /// </summary>
        public const int SUIT_DIAMOND = 2;

        /// <summary>
        /// クラブを表す定数
        /// </summary>
        public const int SUIT_CLUB = 3;

        /// <summary>
        /// ハートを表す定数
        /// </summary>
        public const int SUIT_HEART = 4;

        /// <summary>
        /// カードの示すスート
        /// </summary>
        private int suit;

        /// <summary>
        /// カードの示す数
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="suit">スート</param>
        /// <param name="number">数</param>
        public Card(int suit, int number)
        {
            this.suit = suit;
            this.Number = number;
        }

        public string GetStringCard()
        {
            var card = string.Empty;

            if (Number > 0)
            {
                // スートの表示
                switch (suit)
                {
                    case SUIT_SPADE:
                        card = "S";
                        break;

                    case SUIT_DIAMOND:
                        card = "D";
                        break;

                    case SUIT_CLUB:
                        card = "C";
                        break;

                    case SUIT_HEART:
                        card = "H";
                        break;

                    default:
                        break;
                }

                switch (Number)
                {
                    case 1:
                        card += "A";
                        break;

                    case 10:
                        card += "T";
                        break;

                    case 11:
                        card += "J";
                        break;

                    case 12:
                        card += "Q";
                        break;

                    case 13:
                        card += "K";
                        break;

                    default:
                        card += Number;
                        break;
                }
            }
            else
            {
                // ジョーカーを表す
                card = "JK";
            }

            return card;
        }
    }
}
