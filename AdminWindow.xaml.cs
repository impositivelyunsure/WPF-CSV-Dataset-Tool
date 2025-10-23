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
        private readonly int id;
        private readonly string name;

        public AdminWindow(int genId, string genName)
        {
            InitializeComponent();
            txtBoxAdminID.Text = genId.ToString();
            txtBoxAdminName.Text = genName;
        }


        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            stsStrip.Items.Add(backProcessorObj.CreateStaff(txtBoxAdminName.Text, txtBoxAdminID.Text));
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            stsStrip.Items.Add(backProcessorObj.UpdateStaff(txtBoxAdminName.Text, txtBoxAdminID.Text));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            stsStrip.Items.Add(backProcessorObj.DeleteStaff(txtBoxAdminName.Text, txtBoxAdminID.Text));
        }
    }
}
