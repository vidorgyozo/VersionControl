using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using week06.Entities;
using week06.MnbServiceReference;

namespace week06
{
    public partial class Form1 : Form
    {

        BindingList<RateData> Rates = new BindingList<RateData>();

        string xmlResult;

        public Form1()
        {
            InitializeComponent();

            RefreshData();
        }

        private void RefreshData()
        {
            Rates.Clear();

            GetExchangeRates();

            ratesDataGrid.DataSource = Rates;

            ProcessXml();

            ShowChart();
        }

        private void ShowChart()
        {
            ratesChart.DataSource = Rates;
            var series = ratesChart.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";

            var area = ratesChart.ChartAreas[0];
            var legend = ratesChart.Legends[0];

            series.BorderWidth = 2;
            legend.Enabled = false;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            area.AxisY.IsStartedFromZero = false;
        }

        private void ProcessXml()
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlResult);

            foreach (XmlElement element in xml.DocumentElement)
            {
                RateData rateD = new RateData();
                Rates.Add(rateD);
                rateD.Date = DateTime.Parse(element.GetAttribute("date"));
                rateD.Currency = ((XmlElement)(element.ChildNodes[0])).GetAttribute("curr");
                rateD.Value = decimal.Parse(element.ChildNodes[0].InnerText) / decimal.Parse(((XmlElement)(element.ChildNodes[0])).GetAttribute("unit"));


            }
            

        }

        private void GetExchangeRates()
        {
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();
            GetExchangeRatesRequestBody request = new GetExchangeRatesRequestBody();
            request.currencyNames = comboBox1.SelectedItem.ToString();
            request.startDate = startTimePicker.Value.ToString();
            request.endDate = endTimePicker.Value.ToString();

            GetExchangeRatesResponseBody response = mnbService.GetExchangeRates(request);

            xmlResult = response.GetExchangeRatesResult;

            richTextBox1.Text = xmlResult;
        }

        private void startTimePicker_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void endTimePicker_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
