using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunctionAnalyzer
{
    public partial class Graph : Form
    {
        public Graph(PointF[] points)
        {
            InitializeComponent();
            const int delta = (int)1E+9;
            Bitmap bmp = new Bitmap("axes.bmp");
            Graphics graphic = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Blue);
            List<List<PointF>> dotSeries = new List<List<PointF>>();
            bool notInic = true;
            for(int i = 0; i < points.Length; i++)
            {
                if (!float.IsNaN(points[i].Y))
                {
                    if (notInic)
                    {
                        dotSeries.Add(new List<PointF>());
                        dotSeries[dotSeries.Count - 1].Add(points[i]);
                        notInic = false;
                    }
                    else
                    {
                        dotSeries[dotSeries.Count - 1].Add(points[i]);
                    }
                }
                else
                {
                    notInic = true;
                }
                
            }
            for(int i = 0; i < dotSeries.Count; i++)
            {
                PointF[] oneSeries = dotSeries[i].ToArray();
                for(int j = 0; j < oneSeries.Length-1; j++)
                {
                    if (oneSeries[j].Y > -delta && oneSeries[j].Y < delta && oneSeries[j + 1].Y > -delta && oneSeries[j + 1].Y < delta)
                    {
                        if ((oneSeries[j].Y < 0 && oneSeries[j + 1].Y > 461) || (oneSeries[j].Y > 461 && oneSeries[j + 1].Y < 0))
                        {

                            continue;
                        }
                        else
                        {
                            graphic.DrawLine(pen, oneSeries[j], oneSeries[j + 1]);
                        }
                    }
                }
            }
            GraphBox.Image = bmp;
        }
        private void SaveGraphButton_Click(object sender, EventArgs e)
        {
            string path = @"..\..\..\Resources\graph_" + DateTime.Now.Ticks + ".jpg";
            GraphBox.Image.Save(path);
        }
    }
}
