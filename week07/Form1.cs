using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week07.Entities;

namespace week07
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthChance> BirthChances = new List<BirthChance>();
        List<DeathChance> DeathChances = new List<DeathChance>();

        List<int> MalePop = new List<int>();
        List<int> FemalePop = new List<int>();

        Random rng = new Random(1234);

        public Form1()
        {
            InitializeComponent();

            endYearNumeric.Minimum = 2005;
            endYearNumeric.Maximum = 3000;
            endYearLabel.Text = Resource1.EndYear;
            endYearNumeric.Value = 2024;
            fileLabel.Text = Resource1.PopulationFile;
            browseButton.Text = Resource1.Browse;
            startButton.Text = Resource1.Start;

            BirthChances = GetBirthChances(@"H:\Documents\Corvinus\20-21-1\IRF\Gyak7\születés.csv");
            DeathChances = GetDeathChances(@"H:\Documents\Corvinus\20-21-1\IRF\Gyak7\halál.csv");

        }

        private void RunSim()
        {
            richTextBox1.Clear();
            MalePop.Clear();
            FemalePop.Clear();

            Population = GetPopulation(fileTextBox.Text);
            for (int year = 2005; year <= endYearNumeric.Value; year++)
            {

                for (int i = 0; i < Population.Count; i++)
                {
                    SimStep(year, Population[i]);
                }

                int numOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive
                                  select x).Count();
                int numOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive
                                    select x).Count();
                Console.WriteLine(
                    string.Format("Év:{0} Fiúk:{1} Lányok:{2}", year, numOfMales, numOfFemales));

                MalePop.Add(numOfMales);
                FemalePop.Add(numOfFemales);
            }

            DisplayResults();
        }

        private void DisplayResults()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < MalePop.Count; i++)
            {
                sb.AppendLine(String.Format("Szimulációs év: {0}\n\tFiúk: {1}\n\tLányok: {2}\n", 2005 + i, MalePop[i], FemalePop[i]));
            }
            richTextBox1.Text = sb.ToString();
        }

        private void SimStep(int year, Person person)
        {
            if (!person.IsAlive) return;

            byte age = (byte)(year - person.BirthYear);

            double deathChance = (from x in DeathChances
                                  where x.Gender == person.Gender && x.Age == age
                                  select x.Chance).FirstOrDefault();

            if (rng.NextDouble() <= deathChance)
                person.IsAlive = false;

            if (!person.IsAlive || person.Gender != Gender.Female) return;

            double birthChance = (from x in BirthChances
                                  where x.Age == age
                                  select x.Chance).FirstOrDefault();
            if (rng.NextDouble() <= birthChance)
            {
                Person newborn = new Person();
                newborn.BirthYear = year;
                newborn.NumOfChildren = 0;
                newborn.Gender = (Gender)(rng.Next(1, 3));
                Population.Add(newborn);
            }
        }

        public List<Person> GetPopulation(string csvPath)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvPath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NumOfChildren = int.Parse(line[2])
                    });
                }
            }

            return population;
        }

        public List<BirthChance> GetBirthChances(string csvPath)
        {
            List<BirthChance> birthChances = new List<BirthChance>();

            using (StreamReader sr = new StreamReader(csvPath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    birthChances.Add(new BirthChance()
                    {
                        Age = int.Parse(line[0]),
                        NumOfChildren = int.Parse(line[1]),
                        Chance = double.Parse(line[2])
                    });
                }
            }

            return birthChances;
        }

        public List<DeathChance> GetDeathChances(string csvPath)
        {
            List<DeathChance> deathChances = new List<DeathChance>();

            using (StreamReader sr = new StreamReader(csvPath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    deathChances.Add(new DeathChance()
                    {
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                        Age = int.Parse(line[1]),
                        Chance = double.Parse(line[2])
                    });
                }
            }

            return deathChances;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            RunSim();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            SelectPopulationFile();
        }

        private void SelectPopulationFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Comma separated values (*.csv) | *.csv";
            dialog.DefaultExt = ".csv";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileTextBox.Text = dialog.FileName;
            }
        }
    }
}
