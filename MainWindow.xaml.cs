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

namespace Malin_SSS_AT3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FrontProcessor frontProcessorObj = new FrontProcessor();
        BackProcessor backProcessorObj = new BackProcessor();
        public MainWindow()
        {
            InitializeComponent();
            backProcessorObj.ReadCsv(@"D:\Diploma - Software Development\ICTPRG535  ICTPRG547  ICTICT517 - Complex Data Structures\Assessments\MalinStaffNamesV3.csv");
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
    }
}