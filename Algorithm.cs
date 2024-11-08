using Floyd;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm
{
    internal class Floyd
    {
        public static void ShortestPaths(VModel matrix)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            matrix.PathsMatrix = new List<int>[matrix.Size][];
            for (int i = 0; i < matrix.Size; i++)
            {
                matrix.PathsMatrix[i] = new List<int>[matrix.Size];
                for (int j = 0; j < matrix.Size; j++)
                {
                    matrix.PathsMatrix[i][j] = new List<int>();
                }
            }
            matrix.DistanceMatrix = matrix.AdjacencyMatrix.Select(row => row.ToArray()).ToArray();
            for (int k = 0; k < matrix.Size; k++)
            {
                for (int i = 0; i < matrix.Size; i++)
                {
                    for(int j = 0; j < matrix.Size; j++)
                    {
                        var newPath = matrix.DistanceMatrix[i][k] + matrix.DistanceMatrix[k][j];
                        if (newPath < matrix.DistanceMatrix[i][j] && newPath > 0)
                        {
                            matrix.PathsMatrix[i][j].Clear();
                            matrix.PathsMatrix[i][j].Add(k);

                            matrix.DistanceMatrix[i][j] = newPath;
                        }
                        else if (newPath == matrix.DistanceMatrix[i][j]  && (matrix.DistanceMatrix[i][k] != 0) && (matrix.DistanceMatrix[k][j] != 0))
                        {
                            matrix.PathsMatrix[i][j].Add(k);
                        }
                    }
                }
            }
            stopwatch.Stop();
            matrix.RunTime = stopwatch.Elapsed.TotalMilliseconds;

        }

        public static List<string> GetAllPaths(int q, int r, List<int>[][] paths,VModel model)
        {
            var res = PathsFromQtoR(q,r,paths);

            for (int i = 0; i < res.Count; i++)
            {
                res[i] = q + "->" + res[i] + "->" + r;
            }

            if (paths[q][r].Count == 0 && model.DistanceMatrix[q][r] != int.MaxValue)
            {
                return new List<string>() { q + "->" + r };
            };

            return res;
        }

        private static List<string> PathsFromQtoR(int q, int r, List<int>[][] paths)
        {
            List<string> result = new List<string>();

            foreach (var path in paths[q][r])
            {
                var before = PathsFromQtoR(q, path, paths);
                var current = path.ToString();
                var after = PathsFromQtoR(path, r, paths);
                var ways = GetPath(before, current, after);
                foreach (var way in ways)
                {
                    result.Add(way);
                }
            }

            return result;
        }

        private static string[] GetPath(List<string> before,string current,List<string> after)
        {
            int ways = before.Count * after.Count;

            if (ways == 0)
            {
                if(before.Count == 0 && after.Count == 0)
                {
                    return new string[] { current };
                }
                if(before.Count == 0)
                {
                    var res = new string[after.Count];
                    for (int i = 0; i < after.Count; i++)
                    {
                        res[i] = current + "->" + after[i];
                    }
                    return res;
                }
                if(after.Count == 0) 
                {
                    var res = new string[before.Count];
                    for (int i = 0; i < before.Count; i++)
                    {
                        res[i] = before[i] + "->" + current;
                    }
                    return res;
                }
            }

            var result = new string[ways];

            int k = 0;
            for (int i = 0; i < before.Count; i++)
            {
                for (int j = 0; j < after.Count; j++)
                {
                    result[k] = before[i] + "->" + current + "->" + after[j];
                    k++;
                }
            }

            return result;
        }
    }
}
