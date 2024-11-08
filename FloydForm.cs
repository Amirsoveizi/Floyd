using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace Floyd
{
    public partial class FloydForm : Form 
    {
        OpenFileDialog openFileDialog;
        string chartName = "myData";

        public FloydForm()
        {
            InitializeComponent();

            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Csv files (*.csv)|*.csv";
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Select Csv files";

            chart.BackColor = Color.LightBlue;
            chart.Series.Add(chartName);
            chart.Series[chartName].Color = Color.DarkSlateGray;
            chart.ChartAreas[0].AxisX.TitleForeColor = Color.Gold;
            chart.Series[chartName].ChartType = SeriesChartType.Bubble;
            chart.Series[chartName].ChartArea = "ChartArea1";
            chart.Series[chartName].SetDefault(true);
            chart.Series[chartName].Enabled = true;
            chart.Visible = true;
            chart.Show();
        }

        private void Button_SelectFile_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = this.openFileDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        if (VModel.models.Any(item => item.FilePath == filePath))
                        {
                            MessageBox.Show("this file is added");
                            continue;
                        }

                        VModel model = new VModel();
                        model.FilePath = filePath;
                        model.Name = filePath.Split('\\').Last();

                        try
                        {
                            Task.Factory.StartNew(() =>
                            {
                                string[] lines = File.ReadAllLines(filePath);
                                model.AdjacencyMatrix = lines
                                    .Select(
                                        line => line.Split(',')
                                        .Select(int.Parse)
                                        .ToArray()
                                    ).ToArray();

                                Algorithm.Floyd.ShortestPaths(model);
                                VModel.models.Add(model);

                                chart.Invoke(new Action(() =>
                                {
                                    comboBox.Items.Add(model.Name);
                                    chart.Series[chartName].Points.AddXY(model.Size, model.RunTime);
                                    chart.Invalidate();
                                }));
                            });
                        }
                        catch (SecurityException ex)
                        {
                            MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                                "Error message: " + ex.Message + "\n\n" +
                                "Details (send to Support):\n\n" + ex.StackTrace
                            );
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Something went wrong !!!\n" + "Error message: " + ex.Message);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_GO_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex == -1)
            {
                MessageBox.Show("select an item first");
                return;
            }

            var item = VModel.models.Find(model => model.Name == comboBox.SelectedItem.ToString());
            string result = string.Empty;
            for (int i = 0; i < item.Size; i++)
            {
                for (int j = 0; j < item.Size; j++) 
                {
                    if (i == j) continue;

                    var list = Algorithm.Floyd.GetAllPaths(i,j,item.PathsMatrix,item);
                    result += string.Join(Environment.NewLine, list.Select((it, index) => $"{i}->{j} : {it}\n"));
                }
            }
            if(item.Size < 16)
            {
                var g = new FloydGraphForm(item.AdjacencyMatrix);
                g.Show();
            }

            var s = new PathsForm(result);
            s.Show();
        }
    }
}
