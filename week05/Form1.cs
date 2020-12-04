﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week05.Entities;

namespace week05
{
    public partial class Form1 : Form
    {
        PortfolioEntities context = new PortfolioEntities();
        List<Tick> Ticks;

        List<PortfolioItem> Portfolio = new List<PortfolioItem>();


        public Form1()
        {
            InitializeComponent();
            Ticks = context.Ticks.ToList();
            dataGridView1.DataSource = Ticks;

            CreatePortfolio();

            exportProfitsButton.Text = Resource1.ExportProfits;

            List<decimal> Nyereségek = new List<decimal>();
            int intervalum = 30;
            DateTime kezdőDátum = (from x in Ticks select x.TradingDay).Min();
            DateTime záróDátum = new DateTime(2016, 12, 30);
            TimeSpan z = záróDátum - kezdőDátum;
            for (int i = 0; i < z.Days - intervalum; i++)
            {
                decimal ny = GetPortfolioValue(kezdőDátum.AddDays(i + intervalum))
                           - GetPortfolioValue(kezdőDátum.AddDays(i));
                Nyereségek.Add(ny);
                Console.WriteLine(i + " " + ny);
            }

            var nyereségekRendezve = (from x in Nyereségek
                                      orderby x
                                      select x)
                                        .ToList();
            MessageBox.Show(nyereségekRendezve[nyereségekRendezve.Count() / 5].ToString());

            exportProfitsButton.Click += ExportProfitsButton_Click;
        }

        private void ExportProfitsButton_Click(object sender, EventArgs e)
        {
            //Azért nem szervezem ezt ki, mert egy feladat része volt, hogy pontosan így ott legyen a konstruktor végén a kód,
            //ezért nem írom át azt a részt, hogy ugyanazt a funkciót töltse be, de jobb legyen az overall szempontból
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text File (*.txt) | *.txt";
            dialog.DefaultExt = ".txt";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Időszak;Nyereség");

                List<decimal> Nyereségek = new List<decimal>();
                int intervalum = 30;
                DateTime kezdőDátum = (from x in Ticks select x.TradingDay).Min();
                DateTime záróDátum = new DateTime(2016, 12, 30);
                TimeSpan z = záróDátum - kezdőDátum;
                for (int i = 0; i < z.Days - intervalum; i++)
                {
                    decimal ny = GetPortfolioValue(kezdőDátum.AddDays(i + intervalum))
                               - GetPortfolioValue(kezdőDátum.AddDays(i));
                    Nyereségek.Add(ny);
                    sb.AppendLine(i + ";" + ny);
                }

                byte[] textInByte = new UTF8Encoding(true).GetBytes(sb.ToString());
                Stream stream = dialog.OpenFile();
                stream.Write(textInByte, 0, textInByte.Length);
                stream.Flush();
                stream.Close();
            }
        }

        private void CreatePortfolio()
        {
            Portfolio.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = Portfolio;
        }

        private decimal GetPortfolioValue(DateTime date)
        {
            decimal value = 0;
            foreach (var item in Portfolio)
            {
                var last = (from x in Ticks
                            where item.Index == x.Index.Trim()
                               && date <= x.TradingDay
                            select x)
                            .First();
                value += (decimal)last.Price * item.Volume;
            }
            return value;
        }
    }
}
