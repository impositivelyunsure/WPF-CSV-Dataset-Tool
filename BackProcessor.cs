using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Malin_SSS_AT3
{
    public class BackProcessor
    {
        public Dictionary<int, string> MasterFile = new Dictionary<int, string>();
        public SortedDictionary<int, string> SortedDictionary = new SortedDictionary<int, string>();

        public void ReadCsv(string path)
        {
            foreach (var line in File.ReadLines(path))
            {
                var parts = line.Split(',');

                if (string.IsNullOrWhiteSpace(line)) continue;

                if (parts.Length < 0) continue;

                var left = parts[0].Trim().Trim('"').TrimStart('\ufeff'); // clean key cell
                var right = parts[1].Trim().Trim('"');                     // clean value cell

                if (!int.TryParse(left, out var key)) continue;          // header/empty/space-only -> skip

                MasterFile[key] = right;
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
    }
}
