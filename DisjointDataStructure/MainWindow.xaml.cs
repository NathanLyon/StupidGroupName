using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using LucasFivas.DisjointSet;
using paulbaker;

namespace DisjointDataStructure
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //LUCAS
            try
            {
                Random rand = new Random(42);
                List<int> numbers = new List<int>();
                ListDisjointSet<int> disjointSet;
                disjointSet = new ListDisjointSet<int>();

                Stopwatch iterationTimer = new Stopwatch();
                List<long> ticksList = new List<long>();
                for (int i = 0; i < 10000; i++)
                {
                    int n = rand.Next();
                    numbers.Add(n);
                    iterationTimer.Start();
                    disjointSet.MakeSet(n);
                    iterationTimer.Stop();
                    ticksList.Add(iterationTimer.ElapsedTicks);
                    iterationTimer.Reset();
                }
                mksetOne.Text = String.Format("Avg : {0}, Max: {1}, Min: {2}", ticksList.Average(), ticksList.Max(), ticksList.Min());
                ticksList.Clear();

                for (int i = 0; i < numbers.Count * 3; i++)
                {
                    int lookup = numbers[rand.Next(numbers.Count)];
                    iterationTimer.Start();
                    disjointSet.Find(lookup);
                    iterationTimer.Stop();
                    ticksList.Add(iterationTimer.ElapsedTicks);
                    iterationTimer.Reset();
                }
                findOne.Text = String.Format("Avg : {0}, Max: {1}, Min: {2}", ticksList.Average(), ticksList.Max(), ticksList.Min());
                ticksList.Clear();

                for (int i = 0; i < numbers.Count * 3; i++)
                {
                    int lookupA = numbers[rand.Next(numbers.Count)];
                    int lookupB = numbers[rand.Next(numbers.Count)];
                    iterationTimer.Start();
                    disjointSet.Union(disjointSet.Find(lookupA), disjointSet.Find(lookupB));
                    iterationTimer.Stop();
                    ticksList.Add(iterationTimer.ElapsedTicks);
                    iterationTimer.Reset();
                }
                unionOne.Text = String.Format("Avg : {0}, Max: {1}, Min: {2}", ticksList.Average(), ticksList.Max(), ticksList.Min());
            }
            catch (Exception err)
            {
                Console.WriteLine(err.StackTrace);
            }


            //PAUL
            try
            {
                Random rand = new Random(42);
                List<int> numbers = new List<int>();
                DisjointDataSet<int> disjointSet;
                disjointSet = new DisjointDataSet<int>();

                Stopwatch iterationTimer = new Stopwatch();
                List<long> ticksList = new List<long>();
                for (int i = 0; i < 10000; i++)
                {
                    int n = rand.Next();
                    numbers.Add(n);
                    iterationTimer.Start();
                    disjointSet.MakeSet(n);
                    iterationTimer.Stop();
                    ticksList.Add(iterationTimer.ElapsedTicks);
                    iterationTimer.Reset();
                }
                mksetTwo.Text = String.Format("Avg : {0}, Max: {1}, Min: {2}", ticksList.Average(), ticksList.Max(), ticksList.Min());
                ticksList.Clear();

                for (int i = 0; i < numbers.Count * 3; i++)
                {
                    int lookup = numbers[rand.Next(numbers.Count)];
                    iterationTimer.Start();
                    disjointSet.Find(lookup);
                    iterationTimer.Stop();
                    ticksList.Add(iterationTimer.ElapsedTicks);
                    iterationTimer.Reset();
                }
                findTwo.Text = String.Format("Avg : {0}, Max: {1}, Min: {2}", ticksList.Average(), ticksList.Max(), ticksList.Min());
                ticksList.Clear();

                for (int i = 0; i < numbers.Count * 3; i++)
                {
                    int lookupA = numbers[rand.Next(numbers.Count)];
                    int lookupB = numbers[rand.Next(numbers.Count)];
                    iterationTimer.Start();
                    disjointSet.Union(lookupA, lookupB);
                    iterationTimer.Stop();
                    ticksList.Add(iterationTimer.ElapsedTicks);
                    iterationTimer.Reset();
                }
                unionTwo.Text = String.Format("Avg : {0}, Max: {1}, Min: {2}", ticksList.Average(), ticksList.Max(), ticksList.Min());
            }
            catch (Exception err)
            {
                Console.WriteLine(err.StackTrace);
            }
        }
    }
}
