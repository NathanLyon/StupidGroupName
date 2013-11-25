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
            //THIS WILL DRIVE EVERYTHING, DON'T LOSE IT!!
            try
            {
                Random lucasRand = new Random(42);
                List<int> lnum = new List<int>();
                for (int i = 0; i < 1000; i++)
                {
                    lnum.Add(lucasRand.Next());
                }



                ListDisjointSet<int> lucas;
                lucas = new ListDisjointSet<int>();
            }
            catch (Exception err)
            {
            }

            try
            {
                Random paulRand = new Random(42);
                DisjointDataSet<int> paul;
                paul = new DisjointDataSet<int>();
            }
            catch (Exception err)
            {
            }
        }
    }
}
