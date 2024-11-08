using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Msagl.Core.Layout;
using Microsoft.Msagl.Core.Routing;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using Microsoft.Msagl.Layout.MDS;


namespace Floyd
{
    public partial class FloydGraphForm : Form // not good for a big graph
    {
        private GViewer viewer;
        private Graph graph;
        public FloydGraphForm(int[][] adjacencyMatrix)
        {
            InitializeComponent();
            InitializeGraph(adjacencyMatrix);
        }
        private void InitializeGraph(int[][] adjacencyMatrix)
        {
            var setting = new MdsLayoutSettings
            {
                EdgeRoutingSettings = { KeepOriginalSpline = true, EdgeRoutingMode = EdgeRoutingMode.Spline },
                RemoveOverlaps = false,
            };

            viewer = new GViewer();
            viewer.Dock = DockStyle.Fill;
            viewer.mdsLayoutSettings = setting;
            viewer.ToolBarIsVisible = false;
            this.Controls.Add(viewer);

            graph = new Graph();
            graph.LayoutAlgorithmSettings = setting;

            for (int i = 0; i < adjacencyMatrix.Length; i++)
            {
                for(int j = 0; j < adjacencyMatrix.Length; j++)
                {
                    if (adjacencyMatrix[i][j] == 0 || adjacencyMatrix[i][j] == int.MaxValue) continue;
                    var edge = graph.AddEdge((i).ToString(),(j).ToString());
                    edge.LabelText = adjacencyMatrix[i][j].ToString();
                }
            }

            viewer.Graph = graph;

            //// Add nodes and edges to the graph
            //var e1 = graph.AddEdge("Node1", "Node2");
            //e1.LabelText = "5";
            //var e2 = graph.AddEdge("Node2", "Node1");
            //e2.LabelText = "3";

            //// Customize node styles (optional)
            //var node1 = graph.FindNode("Node1");
            //node1.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Cyan;


            //var node2 = graph.FindNode("Node2");
            //node2.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Yellow;
            //node2.Attr.Shape = Shape.Circle;
        }

    }
}
