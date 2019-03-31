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

namespace XMLReview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Widget> widgetList = new List<Widget>();
        Widget WorkingWidget;
        public MainWindow()
        {
            InitializeComponent();
            widgetList = WidgetLoader.ReadWidgets("widget.xml");
            WidgetGrid.ItemsSource = widgetList;
        }

        private void Chip_Click(object sender, RoutedEventArgs e)
        {
            WorkingWidget = new Widget
            {
                Name = PatientName.Text,
                DOB = DateTime.Parse(DOB.Text),
                NumberOfWidgets = 0
            };
            Console.WriteLine(WorkingWidget);
            Console.WriteLine(widgetList);
            widgetList.Add(WorkingWidget);
            WidgetGrid.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Widget w = ((FrameworkElement)sender).DataContext as Widget;
            w.IncrementWidgets();
            MessageBox.Show($"Added New Widget! New Count: {w.NumberOfWidgets}", w.NumberOfWidgets.ToString());
            WidgetGrid.Items.Refresh();
        }

        private void Chip_Click_1(object sender, RoutedEventArgs e)
        {
            WidgetLoader.WriteWidgets(widgetList, "widget.xml");
        }
    }
}
