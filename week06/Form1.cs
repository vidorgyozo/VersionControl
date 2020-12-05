using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            GetExchangeRates();

            ratesDataGrid.DataSource = Rates;

            ProcessXml();


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
            request.currencyNames = "EUR";
            request.startDate = "2020-01-01";
            request.endDate = "2020-06-30";

            GetExchangeRatesResponseBody response = mnbService.GetExchangeRates(request);

            xmlResult = response.GetExchangeRatesResult;

            richTextBox1.Text = xmlResult;
        }
    }
}
