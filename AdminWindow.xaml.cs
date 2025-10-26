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
using System.IO;

namespace Malin_SSS_AT3
{
    public partial class AdminWindow : Window
    {
        BackProcessor backProcessorObj = new BackProcessor();
        FrontProcessor frontProcessorObj = new FrontProcessor();
        string csvPath = "Data/MalinStaffNamesV3.csv";

        public AdminWindow(BackProcessor backPro, string genId, string genName)
        {
            InitializeComponent();
            txtBoxAdminID.Text = genId;
            txtBoxAdminName.Text = genName;
            backProcessorObj = backPro;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            stsStrip.Items.Add(backProcessorObj.CreateStaff(txtBoxAdminID.Text, txtBoxAdminName.Text));
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            stsStrip.Items.Add(backProcessorObj.UpdateStaff(txtBoxAdminID.Text, txtBoxAdminName.Text));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            stsStrip.Items.Add(backProcessorObj.DeleteStaff(txtBoxAdminID.Text, txtBoxAdminName.Text));
            frontProcessorObj.ClearAdminTextBoxes((AdminWindow)AdminWindow.GetWindow(this));
        }

        // save csv file on window close
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            backProcessorObj.SaveCsv(csvPath);
            backProcessorObj.TestWrite(csvPath); // test method to retrieve performance info (milliseconds taken to perform)
        }

        // close admin panel on ALT + L
        private void AdminWindow_KeyDown(object sender, KeyEventArgs e)
        {
            bool alt = (Keyboard.Modifiers & ModifierKeys.Alt) != 0;
            var key = e.SystemKey == Key.None ? e.Key : e.SystemKey;

            if (alt && key == Key.L)
            {
                this.Close();
                e.Handled = true;
            }
        }

        // save csv
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            backProcessorObj.SaveCsv(csvPath);
        }
    }
}
