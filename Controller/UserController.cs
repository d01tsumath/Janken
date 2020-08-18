using FastEnumUtility;
using System;
using System.Linq;
using static Janken.CommonEnum;

namespace Janken
{
    /// <summary>
    /// 画面上の操作を担うクラスです。
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UserController()
        {
        }

        /// <summary>
        /// ユーザーの入出力を管理します。
        /// </summary>
        public void UserControl()
        {
            Console.WriteLine("Enter キーを押すと始まります");

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                Console.WriteLine("出す手を選択してください (1 : グー  2 : チョキ  3 : パー)");
                var input = Console.ReadLine();

                // 入力値の検証
                var validation = InputValidation(input);
                if (!validation)
                {
                    Console.WriteLine("1 ～ 3 で入力してください");
                    continue;
                }

                // 検証 OK なら input をキャスト
                var hand = (Hand)Int32.Parse(input);

                var game = new GameController();
                var result = game.MainControl(hand);

                Console.WriteLine($"あなた : {hand.GetLabel()}、コンピュータ : {result.Item1.GetLabel()} で {result.Item2.GetLabel()} ");
                Console.WriteLine("じゃんけんを続けますか？ 中断する場合は Esc、続行する場合はそれ以外のキーを押してください");
            }
        }

        /// <summary>
        /// ユーザーの入力値を検証します。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool InputValidation(string input)
        {
            int n;
            if (!Int32.TryParse(input, out n))
            {
                return false;
            }

            var hand = (Hand)Int32.Parse(input);

            if (FastEnum.GetValues<Hand>().Contains(hand))
                return true;

            return false;
        }
    }
}
