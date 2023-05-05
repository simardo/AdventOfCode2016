using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Day04 {
    internal class Part2 {

        public Part2() {
        }

        public int exec(string input) {
            Regex re = new Regex(@"([a-z-]+)(\d+)\[([a-z]+)\]", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection mc = re.Matches(input);

            int result = 0;

            foreach (Match m in mc) {
                GroupCollection gc = m.Groups;
                string originalName = gc[1].Value;
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
                    int shift = id % 26;
                    string decoded = new(originalName.Select(c => {
                        if (c == '-') {
                            return ' ';
                        }
                        int shifted = c + shift;
                        if (shifted > 'z') {
                            shifted = 'a' + (shifted - 'z') - 1;
                        }
                        return (char)shifted;
                    }).ToArray());

                    if (decoded == "northpole object storage ") {
                        result = id;
                    }
                }
            }
            return result;
        }
    }
}
