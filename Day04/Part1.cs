using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Day04 {

    internal class KeyComparer : IComparer<KeyValuePair<char, int>> {
        public int Compare(KeyValuePair<char, int> x, KeyValuePair<char, int> y) {
            int result = y.Value.CompareTo(x.Value);
            if (result == 0) {
                result = x.Key.CompareTo(y.Key);
            }
            return result;
        }
    }

    internal class Part1 {

        public Part1() {
        }

        public int exec(string input) {
            Regex re = new Regex(@"([a-z-]+)(\d+)\[([a-z]+)\]", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection mc = re.Matches(input);

            int result = 0;

            foreach (Match m in mc) {
                GroupCollection gc = m.Groups;
                string name = gc[1].Value.Replace("-", "");
                int id = Convert.ToInt32(gc[2].Value);
                string checksum = gc[3].Value;

                Dictionary<char, int> dict = new Dictionary<char, int>();
                foreach (char c in name) {
                    if (!dict.ContainsKey(c)) {
                        dict.Add(c, 0);
                    }
                    dict[c] = dict[c] + 1;
                }
                char[] sorted = dict.ToImmutableList().Sort(new KeyComparer()).Select(kv => kv.Key).ToArray();
                string verifier = new string(sorted);

                if (verifier.StartsWith(checksum)) {
                    result += id;
                }
            }
            return result;
        }
    }
}
