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

        string[] headers;
        object[,] values;

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
                FormatTable();

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

        private void FormatTable()
        {
            Excel.Range headerRange = xlWorksheet.get_Range(GetCell(1, 1), GetCell(1, headers.Length));
            headerRange.Font.Bold = true;
            headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            headerRange.EntireColumn.AutoFit();
            headerRange.RowHeight = 40;
            headerRange.Interior.Color = Color.LightBlue;
            headerRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);

            Excel.Range dataRange = xlWorksheet.get_Range(
                GetCell(2, 1),
                GetCell(1 + values.GetLength(0), values.GetLength(1)));
            dataRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);

            Excel.Range firstColDataRange = xlWorksheet.get_Range(GetCell(2, 1), GetCell(1 + values.GetLength(0), 1));
            firstColDataRange.Font.Bold = true;
            firstColDataRange.Interior.Color = Color.LightYellow;

            Excel.Range lastColDataRange = xlWorksheet.get_Range(
                GetCell(2, values.GetLength(1)),
                GetCell(1 + values.GetLength(0), values.GetLength(1)));
            lastColDataRange.Interior.Color = Color.LightGreen;
            lastColDataRange.NumberFormat = "0.00";
        }

        private void CreateTable()
        {
            headers = new string[] {
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

            values = new object[Flats.Count, headers.Length];

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
                values[flatNum, 8] = String.Format("={0}*1000000/{1}", GetCell(flatNum + 2, 8), GetCell(flatNum + 2, 7));
                flatNum++;
            }

            xlWorksheet.get_Range(
                GetCell(2, 1),
                GetCell(1 + values.GetLength(0), values.GetLength(1))).Value2 = values;
        }

        private string GetCell(int x, int y)
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);
            }
            ExcelCoordinate += x.ToString();

            return ExcelCoordinate;
        }

        private void LoadData()
        {
            Flats = context.Flats.ToList();
        }
    }
}
