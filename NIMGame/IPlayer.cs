using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIMGame
{
    /// <summary>
    /// 定义玩家接口
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// 玩家姓名
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 取物品
        /// </summary>
        /// <returns></returns>
        TakeRule Take();
    }
}
