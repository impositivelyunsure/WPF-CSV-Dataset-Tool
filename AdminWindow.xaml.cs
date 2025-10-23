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
using System.Windows.Shapes;

namespace Malin_SSS_AT3
{
    public partial class AdminWindow : Window
    {
        BackProcessor backProcessorObj = new BackProcessor();

        public AdminWindow()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            backProcessorObj.CreateStaff(txtBoxAdminID.Text, txtBoxAdminName.Text);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            backProcessorObj.UpdateStaff(txtBoxAdminID.Text, txtBoxAdminName.Text);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            backProcessorObj.DeleteStaff(txtBoxAdminID.Text, txtBoxAdminName.Text);
        }
    }
}
