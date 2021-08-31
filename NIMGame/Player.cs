using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIMGame
{
    /// <summary>
    /// 玩家
    /// </summary>
    public class Player : IPlayer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">玩家姓名</param>
        /// <param name="controller">控制器</param>
        public Player(string name, IPlayerController controller)
        {
            Name = name;
            Controller = controller;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 控制器
        /// </summary>
        public IPlayerController Controller { get; }

        /// <summary>
        /// 取物
        /// </summary>
        /// <returns></returns>
        public TakeRule Take()
        {
            return Controller.Take(this);
        }
    }
}
