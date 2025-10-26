using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using System.Diagnostics;

namespace Malin_SSS_AT3
{
    public class BackProcessor
    {
        public Dictionary<int, string> MasterFile = new Dictionary<int, string>();
        public SortedDictionary<int, string> SortedDictionary = new SortedDictionary<int, string>();


        public double TestRead(string path)
        {
            var sw = Stopwatch.StartNew();

            ReadCsv(path);

            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        }

        public double TestWrite(string path)
        {
            var sw = Stopwatch.StartNew();

            // Your existing WriteCsv
            SaveCsv(path);

            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        }


        // Read csv file into the dictionary
        public void ReadCsv(string path)
        {
            foreach (var line in File.ReadLines(path))
            {
                var parts = line.Split(',');

                if (string.IsNullOrWhiteSpace(line)) continue;

                if (parts.Length < 0) continue;

                var left = parts[0].Trim().Trim('"').TrimStart('\ufeff'); 
                var right = parts[1].Trim().Trim('"');                     

                if (!int.TryParse(left, out var key)) continue;          

                MasterFile[key] = right;
            }
        }

        // save the dictionary as a csv
        public void SaveCsv(string path)
        {
            try
            {
                // Convert the dictionary back into CSV lines
                var lines = MasterFile.Select(kvp => $"{kvp.Key},{kvp.Value}");

                // Overwrite or create the CSV file
                File.WriteAllLines(path, lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving CSV file:\n{ex.Message}");
            }
        }

        // Filter by both Name and ID
        public IOrderedEnumerable<KeyValuePair<int, string>> Filter(string name, string id)
        {
            name = name.Trim();
            id = id.Trim();

            // regex query for both name and id
            var query = MasterFile.Where(item => (string.IsNullOrEmpty(name) || item.Value.StartsWith(name)) && // query the name
            (string.IsNullOrEmpty(id) || item.Key.ToString().StartsWith(id))).OrderBy(item => item.Value); // query the id

            return query;
        }


        // Create staff method for admin panel
        // decided on returning strings of feedback to be used in status strip messages instead of passing through --
        // the admin window and grabbing text box values. this is to keep the seperation of front end and back end logic
        public string CreateStaff(string id, string name)
        {
            if (!int.TryParse(id, out int parsedId))
            {
                return $"The entered ID is not a valid input.";
            }

            if (string.IsNullOrEmpty(name))
            {
                return "The staff input name cannot be empty.";
            }

            if (MasterFile.ContainsKey(parsedId))
            {
                return $"The staff ID {parsedId} already exists.";
            }

            if (!parsedId.ToString().StartsWith("77"))
            {
                return $"The staff ID {parsedId} does not start with 77.";
            }
            MasterFile.Add(parsedId, name);
            return $"New staff member {name} , {parsedId} has been created.";
        }

        // update staff member
        public string UpdateStaff(string id, string name)
        {
            // if id is parsed as an int and the dictionary contains that id, change the name at that id found
            if (int.TryParse(id, out int parsedId) &&
                MasterFile.ContainsKey(parsedId))
            {
                MasterFile[parsedId] = name;
                return $"Staff ID {parsedId} has been updated.";
            }
            else
            {
                return $"The staff ID {id} is not a valid input, or cannot be found.";
            }
        }

        // delete staff member
        public string DeleteStaff(string id, string name)
        {
            if (int.TryParse(id, out int parsedId) &&
                MasterFile.Remove(parsedId))
            {
                return $"The staff ID {parsedId} has been removed.";
            }
            return $"Could not remove staff member.";
        }
    }
}
