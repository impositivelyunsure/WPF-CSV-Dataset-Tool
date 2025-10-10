using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Xml.Linq;

namespace Malin_SSS_AT3
{
    public class FrontProcessor
    {
        public void ClearTextBoxes(MainWindow mwindow)
        {
            mwindow.txtBoxClientID.Text = string.Empty;
            mwindow.txtBoxName.Text = string.Empty;
        }

        // the 1st list box that is unselectable
        public void DisplayUnsortedListBox(MainWindow mwindow, BackProcessor processor)
        {
            mwindow.lstBoxDisplay.Items.Clear();

            foreach(var item in processor.MasterFile)
            {
                mwindow.lstBoxDisplay.Items.Add($"{item.Key}, {item.Value}");
            }




        }

        public void DisplayQueriedListBox(MainWindow mwindow, IOrderedEnumerable<KeyValuePair<int, string>> query)
        {
            mwindow.lstBoxSecondDisplay.Items.Clear();
            foreach (var item in query)
            {
                mwindow.lstBoxSecondDisplay.Items.Add($"{item.Key}, {item.Value}");
            }
        }
        public void NameTextChanged(MainWindow mwindow, BackProcessor processor)
        {
            DisplayQueriedListBox(mwindow, processor.Filter(mwindow.txtBoxName.Text, mwindow.txtBoxClientID.Text)); 
        }

        public void IDTextChanged(MainWindow mwindow, BackProcessor processor)
        {
            DisplayQueriedListBox(mwindow, processor.Filter(mwindow.txtBoxName.Text, mwindow.txtBoxClientID.Text));
        }

        public void SelectionChanged(MainWindow mwindow)
        {
            if (mwindow.lstBoxSecondDisplay.SelectedItem is string line)
            {
                var parts = line.Split(',');
                if (parts.Length >= 2)
                {
                    mwindow.txtBoxClientID.Text = parts[0].Trim();
                    mwindow.txtBoxName.Text = parts[1].Trim();
                }
            }
        }
    }
}
