using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NIMGame
{
    /// <summary>
    /// 控制台玩家控制器
    /// </summary>
    public class ConsolePlayerController : IPlayerController
    {
        public TakeRule Take(IPlayer player)
        {
            Console.Write($"请输入取法（规则为 行数-数量。如 2-3 表示取第 2 行 3 个）：");
            string line = Console.ReadLine();

            return ParseRule(line);
        }

        private static readonly Regex _ruleRegex = new Regex("^(\\d+)-(\\d+)$", RegexOptions.Compiled);
        /// <summary>
        /// 解析规则
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static TakeRule ParseRule(string line)
        {
            var match = _ruleRegex.Match(line);
            if (match.Success)
                return new TakeRule(int.Parse(match.Groups[1].Value) - 1, int.Parse(match.Groups[2].Value));

            throw new GameException("输入条件不符合规则，请重新输入");
        }
    }
}
