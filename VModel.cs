using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floyd
{
    class VModel
    {
        private static List<VModel> _models;
        public static List<VModel> models
        {
            get
            {
                if (_models == null)
                {
                    _models = new List<VModel>();
                }
                return _models;
            }
        }

        public string FilePath { get; set; }
        public string Name {  get; set; }
        public double RunTime {  get; set; }
        public int[][] AdjacencyMatrix {  get; set; }
        public int[][] DistanceMatrix { get; set; }
        public List<int>[][] PathsMatrix { get; set; }
        public int Size { get { return AdjacencyMatrix[0].Length; } }

    }
}
