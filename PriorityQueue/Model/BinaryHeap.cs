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
        /// <summary>
        /// Список элементов очереди.
        /// </summary>
        private List<int> Items = new List<int>();

        /// <summary>
        /// Добавить элемент в очередь.
        /// </summary>
        /// <param name="item">Приоритет.</param>
        public void Enqueue(int item)
        {
            if (item == 0)
            {
                throw new ArgumentNullException(nameof(item), "Приоритет не может быть равен нулю.");
            }
            if (item.GetType() != typeof(int))
            {
                throw new ArgumentException(nameof(item), "Некорректный приоритет.");
            }

            if (Items.Count == 0)
            {
                Items.Add(item);
                return;
            }
            Items.Add(item);
            var currentIndex = Items.Count - 1;
            var parentIndex = (currentIndex - 1) / 2;

            while (item > GetParent(currentIndex) && Items[0] != item)
            {
                Swap(ref currentIndex, ref parentIndex);
                currentIndex = parentIndex;
                parentIndex = (currentIndex - 1) / 2;
            }
        }

        /// <summary>
        /// Получить очередной элемент.
        /// </summary>
        /// <returns>Очередной элемент.</returns>
        public int Dequeue()
        {
            var result =  Items[0];

            Items[0] = Items[Items.Count - 1];
            Items.RemoveAt(Items.Count - 1);
            Sort();

            return result;
        }

        /// <summary>
        /// Посмотреть очередной элемент.
        /// </summary>
        /// <returns>Очередной элемент.</returns>
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

        /// <summary>
        /// Отсортировать очередь.
        /// </summary>
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

        /// <summary>
        /// Получить предка.
        /// </summary>
        /// <param name="currentIndex">Индекс исходного элемента.</param>
        /// <returns>Предок исходного элемента.</returns>
        private int GetParent(int currentIndex)
        {
            if (currentIndex.GetType() != typeof(int))
            {
                throw new ArgumentException(nameof(currentIndex), "Некорректный Индекс.");
            }

            return Items[(currentIndex - 1) / 2];
        }

        /// <summary>
        /// Поменять местами элементы очереди.
        /// </summary>
        /// <param name="currentIndex">Индекс исходного элемента.</param>
        /// <param name="parentIndex">Индекс элемента предка.</param>
        private void Swap(ref int currentIndex, ref int parentIndex)
        {
            if (currentIndex.GetType() != typeof(int))
            {
                throw new ArgumentException(nameof(currentIndex), "Некорректный Индекс.");
            }

            if (parentIndex.GetType() != typeof(int))
            {
                throw new ArgumentException(nameof(parentIndex), "Некорректный Индекс.");
            }

            var parent = GetParent(currentIndex);
            Items[parentIndex] = Items[currentIndex];
            Items[currentIndex] = parent;          
        }

        public IEnumerator GetEnumerator()
        {
            while (Items.Count > 0)
            {
                yield return Dequeue();
            }
        }
    }
}
