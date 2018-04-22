using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace Stegano.Analisys
{
    public abstract class AnalisysHistogram : GUI, ICloneable
    {
        private Dictionary<string, List<Int32>> histogramData = new Dictionary<string, List<Int32>>();
        private List<string> series = new List<string>();
        private Chart chart;
        private Bitmap bitmap;

        public void Clear()
        {
            histogramData.Clear();
            series.Clear();
        }

        public void SetBitmap(Bitmap bitmap)
        {
            this.bitmap = bitmap;
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public void SetChart(Chart chart)
        {
            this.chart = chart;
        }

        public void AddColumn(string name, List<Int32> values)
        {
            histogramData.Add(name, values);
        }

        public void AddSeries(string name)
        {
            series.Add(name);
        }

        public Dictionary<string, List<Int32>> GetData()
        {            
            return histogramData;
        }

        public bool NextElement()
        {
            return histogramData.GetEnumerator().MoveNext();
        }

        public string GetCurrentName()
        {
            return histogramData.GetEnumerator().Current.Key;
        }

        public List<Int32> GetCurrentArray()
        {
            return histogramData.GetEnumerator().Current.Value;
        }

        public void SetHistogrammProperties()
        {
            SetSeries();
            SetData();
            chart.Series.Clear();
            foreach (string str in series)
            {
                chart.Series.Add(str);
            }
            foreach (KeyValuePair<string, List <Int32>> entry in histogramData)
            {
                int num = 0;
                foreach (string str in series)
                {
                    chart.Series[str].Points.AddXY(entry.Key, entry.Value.ToArray()[num]);
                    num++;
                }
            }
        }

        public void DisplayValue(bool show)
        {
            foreach(Series series in chart.Series)
            {
                series.IsValueShownAsLabel = show;
            }
        }

        abstract public void SetData();

        abstract public void SetSeries();

        public virtual string HintString()
        {
            return "This does not requare any parameters";
        }

        public virtual bool HasParameters()
        {
            return false;
        }

        public abstract string[] AllParameters();

        public abstract void ParametersReader(string parameters);

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
