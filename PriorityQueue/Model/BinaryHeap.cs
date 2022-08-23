using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue.Model
{
    class BinaryHeap : IEnumerable
    {
        private List<int> Items = new List<int>();

        public void Add(int current)
        {           
            if (Items.Count == 0)
            {
                Items.Add(current);
                return;
            }
            Items.Add(current);
            var currentIndex = Items.Count - 1;
            var parentIndex = (currentIndex - 1) / 2;

            while (current > GetParent(currentIndex) && Items[0] != current)
            {
                Swap(ref currentIndex, ref parentIndex);
                currentIndex = parentIndex;
                parentIndex = (currentIndex - 1) / 2;
            }
        }

        public int GetHead()
        {
            var result =  Items[0];

            Items[0] = Items[Items.Count - 1];
            Items.RemoveAt(Items.Count - 1);
            Sort();

            return result;
        }

        public int? Peek()
        {
            if (Items.Count - 1 > 0)
            {
                return Items[0];
            }
            else
            {
                return null;
            }
        }

        private void Sort()
        {
            var maxItemIndex = 0;
            int rightItemIndex;
            int leftItemIndex;
            var currentIndex = 0;

            while(currentIndex < Items.Count - 1)
            {
                rightItemIndex = 2 * currentIndex + 2;
                leftItemIndex = 2 * currentIndex + 1;

                if (rightItemIndex > Items.Count - 1 || rightItemIndex > Items.Count - 1)
                {
                    break;
                }

                if (Items[leftItemIndex] > Items[maxItemIndex])
                {
                    maxItemIndex = leftItemIndex;
                }

                if (Items[rightItemIndex] > Items[maxItemIndex])
                {
                    maxItemIndex = rightItemIndex;
                }

                if (maxItemIndex == currentIndex)
                {
                    break;
                }

                Swap(ref maxItemIndex, ref currentIndex);

                currentIndex = maxItemIndex;

            }

        }

        private int GetParent(int currentIndex)
        {
            return Items[(currentIndex - 1) / 2];
        }

        private void Swap(ref int currentIndex, ref int parentIndex)
        {
            var parent = GetParent(currentIndex);
            Items[parentIndex] = Items[currentIndex];
            Items[currentIndex] = parent;          
        }

        public IEnumerator GetEnumerator()
        {
            while (Items.Count > 0)
            {
                yield return GetHead();
            }
        }
    }
}
