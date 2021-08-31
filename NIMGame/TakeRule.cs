using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIMGame
{
    /// <summary>
    /// 取物规则
    /// </summary>
    public sealed class TakeRule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row">行数，1 表示第一行</param>
        /// <param name="counts">数量</param>
        public TakeRule(int row, int counts)
        {
            Row = row;
            Counts = counts;
        }

        /// <summary>
        /// 行数，1 表示第一行
        /// </summary>
        public int Row { get;  private set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Counts { get; private set; }
    }
}
