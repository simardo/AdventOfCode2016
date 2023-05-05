namespace Day07 {

    internal class Part1 {

        public Part1() {
        }

        public int exec(string input) {
            List<string> ips = new List<string>(input.Replace("\r", null).Split('\n'));

            int result = 0;
            foreach (string ip in ips) {
                bool inHypernet = false;
                bool supportsTLS = false;
                Queue<char> window = new Queue<char>();
                foreach (char c in ip) { 
                    if (c == '[') { 
                        inHypernet = true;
                        window.Clear();
                    } else if (c == ']') {
                        inHypernet = false;
                        window.Clear();
                    } else {
                        if (window.Count == 4) {
                            window.Dequeue();
                        }
                        window.Enqueue(c);
                        if (window.Count == 4) {
                            bool isAbba = (window.ElementAt(0) == window.ElementAt(3) && window.ElementAt(1) == window.ElementAt(2) && window.ElementAt(0) != window.ElementAt(1));
                            if (isAbba) {
                                supportsTLS = true;
                                if (inHypernet) {
                                    supportsTLS = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                result += supportsTLS ? 1 : 0;
            }

            return result;
        }
    }
}
