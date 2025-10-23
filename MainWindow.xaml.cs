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
using System.IO;

namespace Malin_SSS_AT3
{
    public partial class MainWindow : Window
    {
        FrontProcessor frontProcessorObj = new FrontProcessor();
        BackProcessor backProcessorObj = new BackProcessor();
        string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MalinStaffNamesV3.csv");
        public MainWindow()
        {
            InitializeComponent();
            backProcessorObj.ReadCsv(filePath);
            frontProcessorObj.DisplayUnsortedListBox((MainWindow)MainWindow.GetWindow(this), backProcessorObj);
        }

        private void lstBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            frontProcessorObj.SelectionChanged((MainWindow)MainWindow.GetWindow(this));
        }

        private void txtBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            frontProcessorObj.NameTextChanged((MainWindow)MainWindow.GetWindow(this), backProcessorObj);
        }

        private void txtBoxClientID_TextChanged(object sender, TextChangedEventArgs e)
        {
            frontProcessorObj.IDTextChanged((MainWindow)MainWindow.GetWindow(this), backProcessorObj);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            frontProcessorObj.WindowKeyDown(backProcessorObj, (MainWindow)MainWindow.GetWindow(this), e);
        }

        private void lstBoxSecondDisplay_KeyUp(object sender, KeyEventArgs e)
        {
            frontProcessorObj.ListBoxSecondDisplayKeyUp((MainWindow)MainWindow.GetWindow(this), e);
        }

        private void txtBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            frontProcessorObj.TextBoxNameKeyDown((MainWindow)MainWindow.GetWindow(this), e);
        }

        private void txtBoxClientID_KeyDown(object sender, KeyEventArgs e)
        {
            frontProcessorObj.TextBoxClientIDKeyDown((MainWindow)MainWindow.GetWindow(this), e);
        }
    }
}