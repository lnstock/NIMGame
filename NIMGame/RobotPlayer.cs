using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIMGame
{
    /// <summary>
    /// 表示机器人玩家
    /// </summary>
    public class RobotPlayer : PlayerBase
    {
        private readonly IReadOnlyList<int> _itemPool;
        private readonly Random _takeRandom = new Random();

        public RobotPlayer(string name, IReadOnlyList<int> itemPool) : base(name)
        {
            _itemPool = itemPool;
        }

        public override TakeRule Take()
        {
            // 随机一个物品不为 0 的行数
            var rows = _itemPool
                .Select((x, i) => new { Row = i, Counts = x })
                .Where(x => x.Counts > 0)
                .Select(x => x.Row)
                .ToArray();

            int row = rows[_takeRandom.Next(rows.Length)];

            // 随机一个当前行的数量
            int counts = _takeRandom.Next(0, _itemPool[row]) + 1;

            Console.WriteLine($"机器人自动取数：{row + 1}-{counts}");
            return new TakeRule(row, counts);
        }
    }
}
