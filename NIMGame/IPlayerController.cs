using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIMGame
{
    /// <summary>
    /// 玩家控制器
    /// </summary>
    public interface IPlayerController
    {
        /// <summary>
        /// 取数
        /// </summary>
        /// <param name="player">玩家</param>
        /// <returns></returns>
        TakeRule Take(IPlayer player);
    }
}
