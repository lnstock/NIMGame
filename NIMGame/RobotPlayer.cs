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
        private readonly ItemPool _itemPool;
        private readonly Random _takeRandom = new Random();

        public RobotPlayer(string name, ItemPool itemPool) : base(name)
        {
            _itemPool = itemPool;
        }

        public override TakeRule Take()
        {
            // 随机一个物品不为 0 的行数
            int row;

            do
            {
                row = _takeRandom.Next(0, _itemPool.Count) + 1;
            } while (_itemPool[row - 1] == 0);

            // 随机一个当前行的数量
            int counts = _takeRandom.Next(0, _itemPool[row - 1]) + 1;

            Console.WriteLine($"机器人自动取数：{row}-{counts}");
            return new TakeRule(row, counts);
        }
    }
}
