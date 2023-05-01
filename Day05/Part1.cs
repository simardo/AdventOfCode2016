using System.Security.Cryptography;
using System.Text;

namespace Day05 {

    internal class Part1 {

        public Part1() {
        }

        public string exec(string input) {
            List<string> entries = new List<string>();

            using (MD5 md5 = MD5.Create("md5")) {
                int index = 0;
                while (entries.Count < 8) {
                    byte[] hash = md5!.ComputeHash(Encoding.ASCII.GetBytes($"{input}{index}"));
                    if (hash[0] == 0 && hash[1] == 0 && hash[2] <= 0x0F) {
                        entries.Add(hash[2].ToString("X1"));
                    }
                    index++;
                }
            }

            return string.Join("", entries).ToLower();
        }
    }
}
