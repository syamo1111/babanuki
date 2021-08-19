using System;
using System.Collections.Generic;
using System.Text;

namespace Babanuki
{

    /// <summary>
    /// ババ抜きの進行役を表すクラス。
    /// </summary>
    public class Master
    {
        // プレイヤーのリスト
        private List<Player> players = new List<Player>();

        /// <summary>
        /// ゲームの準備をする
        /// </summary>
        /// <param name="cards">トランプを進行役の手札として渡す</param>
        public void PrepareGame(Hand cards)
        {
            Console.WriteLine("【カードを配ります】");

            // トランプをシャッフルする
            cards.Shuffle();

            // トランプの枚数を取得する
            int numberOfCards = cards.GetNumberOfCards();

            // プレイヤーの人数を取得する
            int numberOfPlayers = players.Count;

            for (int index = 0; index < numberOfCards; index++)
            {
                // カードから1枚引く
                Card card = cards.PickCard();

                // 各プレイヤーに順番にカードを配る
                Player player = players[index % numberOfPlayers];
                player.ReceiveCard(card);
            }

        }

        /// <summary>
        /// ゲームを開始する。
        /// </summary>
        public void StartGame()
        {
            Console.WriteLine(Environment.NewLine + "【ババ抜きを開始します】");

            // プレイヤーの人数を取得する
            for (int count = 0; count < players.Count; count++)
            {
                int playerIndex = count % players.Count;
                int nextPlayerIndex = (count + 1) % players.Count;

                // 指名するプレイヤーの取得
                Player player = players[playerIndex];

                // 次のプレイヤーの取得
                Player nextPlayer = players[nextPlayerIndex];

                // プレイヤーを指名する
                Console.WriteLine(Environment.NewLine + player.Name + "さんの番です");
                player.Play(nextPlayer);
            }

            // プレイヤーが上がって残り1名になるとループを抜ける
            Console.WriteLine("【ババ抜きを終了しました】");
        }

        /// <summary>
        /// 上がりを宣言する
        /// </summary>
        /// <param name="winner"></param>
        public void DeclareWin(Player winner)
        {
            // 上がったプレイヤー
            Console.WriteLine(winner.Name + "さんが上がりました！");

            // 上がったプレイヤーをリストから外す
            players.Remove(winner);

            // 残りプレイヤーが1人になったときは敗者を表示する
            if (players.Count == 1)
            {
                Player loser = players[0];
                Console.WriteLine(loser.Name + "さんの負けです!");
            }
        }

        /// <summary>
        /// ゲームに参加するプレイヤーを登録する。
        /// </summary>
        /// <param name="player"></param>
        public void RegisterPlayer(Player player)
        {
            players.Add(player);
        }
    }
}
