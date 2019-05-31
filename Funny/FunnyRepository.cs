using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funny
{
    public class FunnyRepository
    {
        public Post GetSmallestOne()
        {
            var items = PostCache.Instance.GetAll();
            int minIndex = -1;
            int minValue = int.MaxValue;
            for (int i = 0; i < items.Count; i++)
            {
                var size = items[i].Title.Length + items[i].Body.Length;
                if (size < minValue)
                {
                    minValue = size;
                    minIndex = i;
                }
            }

            return minIndex >= 0 ? items[minIndex] : null;
        }
    }
}
