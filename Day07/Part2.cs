using System.Text.RegularExpressions;

namespace Day07 {

    internal partial class Part2 {

        public Part2() {
        }

        [GeneratedRegex(@"\[(\w+)\]", RegexOptions.IgnoreCase)]
        private partial Regex HypernetRegex();

        public int exec(string input) {
            List<string> ips = new List<string>(input.Replace("\r", null).Split('\n'));

            int result = 0;
            foreach (string ip in ips) {
                string[] supernets = HypernetRegex().Replace(ip, "|").Split('|');
                string[] hypernets = HypernetRegex().Matches(ip).Select(m => m.Groups[1].Value).ToArray();

                bool supportsSSL = false;
                foreach (string supernet in supernets) {
                    Queue<char> window = new Queue<char>();
                    foreach (char c in supernet) {
                        if (window.Count == 3) {
                            window.Dequeue();
                        }
                        window.Enqueue(c);
                        if (window.Count == 3) {
                            bool isAba = window.ElementAt(0) == window.ElementAt(2) && window.ElementAt(0) != window.ElementAt(1);
                            if (isAba) {
                                string bab = new string(new char[] { window.ElementAt(1), window.ElementAt(0), window.ElementAt(1) });
                                if (hypernets.Any(h => h.Contains(bab))) {
                                    supportsSSL = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (supportsSSL) {
                        result++;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
