using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace Week04
{
    public partial class Form1 : Form
    {
        private List<Flat> Flats;

        RealEstateEntities context = new RealEstateEntities();

        Excel.Application xlApp;
        Excel.Workbook xlWorkbook;
        Excel.Worksheet xlWorksheet;

        public Form1()
        {
            InitializeComponent();

            LoadData();
            CreateExcel();
        }

        private void CreateExcel()
        {
            try
            {
                xlApp = new Excel.Application();

                xlWorkbook = xlApp.Workbooks.Add(Missing.Value);

                xlWorksheet = xlWorkbook.ActiveSheet;

                CreateTable();

                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception e)
            {
                string errorMessage = string.Format("Error: {0}\nLine: {1}", e.Message, e.Source);
                MessageBox.Show(errorMessage, "Error");

                xlWorkbook.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWorkbook = null;
                xlApp = null;
            }
        }

        private void CreateTable()
        {
            string[] headers = new string[] {
                "Kód",
                "Eladó",
                "Oldal",
                "Kerület",
                "Lift",
                "Szobák száma",
                "Alapterület (m2)",
                "Ár (mFt)",
                "Négyzetméter ár (Ft/m2)"};
            for (int i = 0; i < headers.Length; i++)
            {
                xlWorksheet.Cells[1, i + 1] = headers[i];
            }

            object[,] values = new object[Flats.Count, headers.Length];

            int flatNum = 0;
            foreach (Flat f in Flats)
            {
                values[flatNum, 0] = f.Code;
                values[flatNum, 1] = f.Vendor;
                values[flatNum, 2] = f.Side;
                values[flatNum, 3] = f.District;
                values[flatNum, 4] = f.Elevator ? Resource1.HasElevator : Resource1.NoElevator;
                values[flatNum, 5] = f.NumberOfRooms;
                values[flatNum, 6] = f.FloorArea;
                values[flatNum, 7] = f.Price;
                values[flatNum, 8] = f.Price / f.FloorArea;
            }
        }

        private void LoadData()
        {
            Flats = context.Flats.ToList();
        }
    }
}
