using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIMGame
{
    /// <summary>
    /// 游戏服务
    /// </summary>
    public class GameService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemPool">取物池</param>
        public GameService(ItemPool itemPool)
        {
            ItemPool = itemPool;
        }

        /// <summary>
        /// 玩家列表
        /// </summary>
        public ICollection<IPlayer> Players { get; } = new HashSet<IPlayer>();

        /// <summary>
        /// 物品池
        /// </summary>
        public ItemPool ItemPool { get;}

        /// <summary>
        /// 输家
        /// </summary>
        public IPlayer Loser { get; private set; }

        public void Start()
        {
            if (Players.Count < 2)
                throw new GameException($"{nameof(Players)} 数量不能少于 2");

            // round 表示当前第几轮
            for (int round = 0; ; round++)
            {
                Console.WriteLine(new string('*', 50));
                Console.WriteLine($"第 {round + 1} 轮开始");
                Console.WriteLine(new string('*', 50));

                // 依次由所有玩家进行取物
                foreach (var player in Players)
                {
                    Console.WriteLine($"现在由玩家【{player.Name}】开始取物，物品池如下");
                    for (int row = 0; row < ItemPool.Count; row++)
                    {
                        Console.WriteLine($"第 {row + 1} 行：{ItemPool[row]}");
                    }

                    // 判断物品池只剩下最后一行的最后一个，则可直接判定当前玩家为输
                    if (ItemPool.Sum() == 1)
                    {
                        Loser = player;
                        return;
                    }

                    // 这个 while 的作用在与确保玩家取走的物品在正确取值范围内
                    while (true)
                    {
                        try
                        {
                            // 玩家取物
                            var rule = player.Take();
                            // 从物品池取走物件
                            ItemPool.Take(rule);

                            // 运行到这里，表示取物没有错误，跳出当前循环
                            break;
                        }
                        catch (GameException ex)
                        {
                            // 取物出错，打印错误信息后由玩家重新取物
                            Console.WriteLine(ex.Message);
                        }
                    }

                    Console.WriteLine();
                    
                    // 如果物品池空了，则判断当前玩家为输
                    if (ItemPool.IsEmpty)
                    {
                        Loser = player;

                        // 游戏结束
                        return;
                    }
                }
            }
        }
    }
}
