using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqForArray
{
    static class XX
    {
        /// <summary>
        /// Кільікість колонок
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int CountCol<R>(this R[,] array)
        {
            return array.GetLength(1);
        }
        /// <summary>
        /// Кількість рядків
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int CountRow<R>(this R[,] array)
        {
            return array.GetLength(0);
        }

        public static IEnumerable<IEnumerable<R>> Select<T,R>(this T[,] array,
                                Func<IEnumerable<T>, IEnumerable<R>> func)
        {
            int countRow = array.CountRow();
            int count = 0;
            if (countRow == 0) yield break;
            while (countRow > count)
            {
                yield return func(GetCol(array, count));
                count++;
            }
            IEnumerable<T> GetCol(T[,] arr, int index)
            {
                int countCol = arr.CountCol();
                for (int i = 0; i < countCol; i++)
                {
                    yield return arr[index, i];
                }
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           var array =  new[,] { { 1, 2, 3 }, { 1, 2, 3 } };
            var result = array.Select(a => a.Select(x=>x+3232));
            foreach (var va in result)
            {
                Console.WriteLine("Begin");
                foreach (var item in va)
                {
                    Console.WriteLine(item);
                }
            }
            Console.ReadKey();
        }
    }
}
