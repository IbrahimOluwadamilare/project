using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Simple_calculator
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

        private void reset(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void calculate(object sender, RoutedEventArgs e)
        {
            double var1 = Convert.ToDouble(textBox1.Text);
            double var2 = Convert.ToDouble(textBox2.Text);
 
             ComboBoxItem combo = (ComboBoxItem)comboBox1.SelectedItem;
                string var3 = Convert.ToString(combo);
                MessageBox.Show(var3);
        }
    }
}
