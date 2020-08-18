using System;
using static Janken.CommonEnum;

namespace Janken
{
    /// <summary>
    /// ゲームのメイン動作を担うクラスです。
    /// </summary>
    public class GameController
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GameController()
        {
        }

        /// <summary>
        /// じゃんけんの流れを制御します。
        /// </summary>
        public ValueTuple<Hand, Result> MainControl(Hand challenger)
        {
            // コンピュータ側の手を決める
            var computer = DecideComputersHand();

            // 判定する
            return (computer, Judge(challenger, computer));
        }

        /// <summary>
        /// コンピュータのじゃんけんの手を決めます。
        /// </summary>
        /// <returns></returns>
        private Hand DecideComputersHand()
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);

            var hands = Enum.GetValues(typeof(Hand));
            return (Hand)hands.GetValue(random.Next(hands.Length));
        }

        /// <summary>
        /// じゃんけんの勝敗を判定します。
        /// </summary>
        /// <param name="challenger"></param>
        /// <param name="computer"></param>
        /// <returns></returns>
        private Result Judge(Hand challenger, Hand computer)
        {
            // 剰余が
            // 0 : 引き分け
            // 1 : 勝ち
            // 2 : 負け
            
            var result = (challenger - computer + 3) % 3;

            if (result == 0)
            {
                return Result.Draw;
            }
            else if (result == 1)
            {
                return Result.Lose;
            }

            return Result.Win;
            
        }
    }
}
