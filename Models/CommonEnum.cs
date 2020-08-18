using FastEnumUtility;

namespace Janken
{
    public class CommonEnum
    {
        /// <summary>
        /// じゃんけん結果を表します。
        /// </summary>
        public enum Result
        {
            [Label("勝ち(((o(*ﾟ▽ﾟ*)o)))")]
            Win,
            [Label("負け...(´・ω・`)")]
            Lose,
            [Label("引き分け")]
            Draw
        }

        /// <summary>
        /// じゃんけんの手の種類を表します。
        /// </summary>
        public enum Hand
        {
            [Label("グー")]
            Rock = 1,
            [Label("チョキ")]
            Scissors = 2,
            [Label("パー")]
            Paper = 3
        }
    }
}
