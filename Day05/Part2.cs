using System.Security.Cryptography;
using System.Text;

namespace Day05 {
    internal class Part2 {

        public Part2() {
        }

        public string exec(string input) {
            Dictionary<int, string> entries = new Dictionary<int, string>();

            using (MD5 md5 = MD5.Create("md5")) {
                int index = 0;
                while (entries.Count < 8) {
                    byte[] hash = md5!.ComputeHash(Encoding.ASCII.GetBytes($"{input}{index}"));
                    if (hash[0] == 0 && hash[1] == 0 && hash[2] <= 0x0F) {
                        int position = hash[2];
                        if (position >= 0 && position <= 7 && !entries.ContainsKey(position)) {
                            entries.Add(position, (hash[3] >> 4).ToString("X1"));
                        }
                    }
                    index++;
                }
            }

            string[] result = new string[8];
            foreach (KeyValuePair<int, string> kv in entries) {
                result[kv.Key] = kv.Value;
            }

            return string.Join("", result).ToLower();
        }
    }
}
