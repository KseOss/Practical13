using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical13
{
    public static class MatrixHelper
    {
        public static int FindRowWithMaxDuplicates(int[,] matrix)
        {
            int maxDuplicates = 0;
            int lastRowIndex = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var counts = new Dictionary<int, int>();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (counts.ContainsKey(matrix[i, j]))
                        counts[matrix[i, j]]++;
                    else
                        counts[matrix[i, j]] = 1;
                }

                int duplicates = counts.Values.Max();
                if (duplicates > maxDuplicates)
                {
                    maxDuplicates = duplicates;
                    lastRowIndex = i;
                }
            }

            return lastRowIndex;
        }
    }
}
