using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIMGame
{
    /// <summary>
    /// 玩家基类
    /// </summary>
    public abstract class PlayerBase : IPlayer
    {
        protected PlayerBase(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 取物
        /// </summary>
        /// <returns></returns>
        public abstract TakeRule Take();
    }
}
