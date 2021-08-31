using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIMGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // 定义物品池
            var itemPool = new ItemPool(3, 5, 7);

            // 游戏服务
            var gameService = new GameService(itemPool);

            // 添加游戏玩家
            gameService.Players.Add(new ConsolePlayer("玩家一"));
            gameService.Players.Add(new RobotPlayer("玩家二", itemPool));

            try
            {
                // 游戏开始
                gameService.Start();

                Console.WriteLine($"游戏结束，输者为：{gameService.Loser.Name}");
            }
            catch (Exception ex)
            {
                // 发生未处理的错误
                Console.WriteLine($"系统错误：{ex.Message}");
            }
            
            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }
    }
}
