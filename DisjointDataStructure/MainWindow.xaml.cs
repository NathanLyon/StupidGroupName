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

                Stopwatch timer = new Stopwatch();
                for (int i = 0; i < 10000; i++)
                {
                    int n = rand.Next();
                    numbers.Add(n); // this is to help keep track of numbers so we can do unions and lookups later.
                    timer.Start();
                    disjointSet.MakeSet(n);
                    timer.Stop();
                }
                mksetOne.Text = String.Format("Avg MS: {0}", timer.ElapsedMilliseconds / 1000);
                timer.Reset();

                for (int i = 0; i < numbers.Count; i++)
                {
                    int lookup = numbers[rand.Next(numbers.Count)];
                    timer.Start();
                    disjointSet.Find(lookup);
                    timer.Stop();
                }
                findOne.Text = String.Format("Avg MS: {0}", timer.ElapsedMilliseconds / 1000);
                timer.Reset();

                for (int i = 0; i < numbers.Count; i++)
                {
                    int lookupA = numbers[rand.Next(numbers.Count)];
                    int lookupB = numbers[rand.Next(numbers.Count)];
                    timer.Start();
                    disjointSet.Union(disjointSet.Find(lookupA), disjointSet.Find(lookupB));
                    timer.Stop();
                }
                unionOne.Text = String.Format("Avg MS: {0}", timer.ElapsedMilliseconds / 1000);
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

                Stopwatch timer = new Stopwatch();
                for (int i = 0; i < 10000; i++)
                {
                    int n = rand.Next();
                    numbers.Add(n); // this is to help keep track of numbers so we can do unions and lookups later.
                    timer.Start();
                    disjointSet.MakeSet(n);
                    timer.Stop();
                }
                mksetTwo.Text = String.Format("Avg MS: {0}", timer.ElapsedMilliseconds / 1000);
                timer.Reset();

                for (int i = 0; i < numbers.Count; i++)
                {
                    int lookup = numbers[rand.Next(numbers.Count)];
                    timer.Start();
                    disjointSet.Find(lookup);
                    timer.Stop();
                }
                findTwo.Text = String.Format("Avg MS: {0}", timer.ElapsedMilliseconds / 1000);
                timer.Reset();

                for (int i = 0; i < numbers.Count; i++)
                {
                    int lookupA = numbers[rand.Next(numbers.Count)];
                    int lookupB = numbers[rand.Next(numbers.Count)];
                    timer.Start();
                    disjointSet.Union(lookupA, lookupB);
                    timer.Stop();
                }
                unionTwo.Text = String.Format("Avg MS: {0}", timer.ElapsedMilliseconds / 1000);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.StackTrace);
            }
        }
    }
}
