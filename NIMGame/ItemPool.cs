using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIMGame
{
    /// <summary>
    /// 游戏物品池
    /// </summary>
    public class ItemPool : IReadOnlyList<int>
    {
        private readonly List<int> _pool;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers">依次指定每一行的物品数量</param>
        /// <example>new ItemPool(1,3,4) 表示第1行1个，第2行3个，第3行4个</example>
        public ItemPool(params int[] numbers)
        {
            if (numbers.Length == 0 || numbers.Any(x => x <= 0))
                throw new ArgumentOutOfRangeException(nameof(numbers), "物品数量必须大于 0");

            _pool = new List<int>(numbers);
        }

        /// <summary>
        /// 从指定行数拿走指定数量的物品
        /// </summary>
        /// <param name="rule">取走规则</param>
        public void Take(TakeRule rule)
        {
            if (rule.Row < 1 || rule.Row > _pool.Count)
                throw new GameException($"行数必须在 {1}-{_pool.Count} 之间");

            if (rule.Counts < 1)
                throw new GameException("数量必须大于 0");

            if (_pool[rule.Row - 1] < rule.Counts)
                throw new GameException("指定行的数量不足");

            _pool[rule.Row - 1] -= rule.Counts;
        }

        /// <summary>
        /// 物品池是否已空
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return !_pool.Any(x => x > 0);
            }
        }

        #region 实现 IReadOnlyList<T> 接口

        public IEnumerator<int> GetEnumerator()
        {
            return _pool.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => _pool.Count;

        public int this[int index] => _pool[index];

        #endregion
    }
}
