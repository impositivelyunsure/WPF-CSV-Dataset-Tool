using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
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

        // Display the original, unsorted list box
        public void DisplayUnsortedListBox(MainWindow mwindow, BackProcessor processor)
        {
            mwindow.lstBoxDisplay.Items.Clear();

            foreach (var item in processor.MasterFile)
            {
                mwindow.lstBoxDisplay.Items.Add($"{item.Key}, {item.Value}");
            }
        }

        // Display the queried list box
        public void DisplayQueriedListBox(MainWindow mwindow, IOrderedEnumerable<KeyValuePair<int, string>> query)
        {
            mwindow.lstBoxSecondDisplay.Items.Clear();
            foreach (var item in query)
            {
                mwindow.lstBoxSecondDisplay.Items.Add($"{item.Key}, {item.Value}");
            }
        }

        // Name text box event handler for changed text, updates & displays the queried list box
        public void NameTextChanged(MainWindow mwindow, BackProcessor processor)
        {
            DisplayQueriedListBox(mwindow, processor.Filter(mwindow.txtBoxName.Text, mwindow.txtBoxClientID.Text));
        }

        // ID text box event handler for changed text, updates & displays the queried list box
        public void IDTextChanged(MainWindow mwindow, BackProcessor processor)
        {
            DisplayQueriedListBox(mwindow, processor.Filter(mwindow.txtBoxName.Text, mwindow.txtBoxClientID.Text));
        }

        // Selection changed event handler for queried list box
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

        // Ctrl + N clears 
        public void TextBoxNameKeyDown(MainWindow mwindow, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.N)
            {
                mwindow.txtBoxName.Clear();
                mwindow.txtBoxName.Focus();
                e.Handled = true;
            }
        }

        // Ctrl + I clears
        public void TextBoxClientIDKeyDown(MainWindow mwindow, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.I)
            {
                mwindow.txtBoxClientID.Clear();
                mwindow.txtBoxClientID.Focus();
                e.Handled = true;
            }
        }

        // Redundant as selection changed event already handles the queried list box display --
        // meaning, once an item is selected, the list box will only show that one selected item and the associated text boxes are filled.
        // you can still call it, but it will only be on that one remaining item that is being displayed in the list box.
        public void ListBoxSecondDisplayKeyUp(MainWindow mwindow, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                SelectionChanged(mwindow);
            }
        }

        // Opening Admin GUI
        public void WindowKeyDown(MainWindow window, KeyEventArgs e)
        {
            bool alt = (Keyboard.Modifiers & ModifierKeys.Alt) != 0;
            var key = e.SystemKey == Key.None ? e.Key : e.SystemKey;

            if (alt && key == Key.A)
            {
                var admin = new AdminWindow();
                admin.Owner = window;
                admin.ShowDialog();
            }
        }
    }
}
