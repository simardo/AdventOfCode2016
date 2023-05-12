using System.Text;

namespace Day09 {

    internal class Part2 {

        private string input;

        private static bool EOS(StringReader sr) {
            return sr.Peek() == -1;
        }

        private static string ReadTo(StringReader sr, char c) {
            StringBuilder buffer = new StringBuilder();
            while (sr.Peek() != Convert.ToInt32(c)) {
                int charInt = sr.Read();
                if (charInt > -1) {
                    buffer.Append(Convert.ToChar(charInt));
                } else {
                    break;
                }
            }
            return buffer.ToString();
        }

        public Part2(string input) {
            this.input = input;
        }

        public long Exec() {
            long result = 0;

            Queue<Tuple<int, string>> toProcess = new Queue<Tuple<int, string>>();
            toProcess.Enqueue(new Tuple<int, string>(1, input));

            while (toProcess.Count > 0) {
                Tuple<int, string> item = toProcess.Dequeue();
                using StringReader sr = new StringReader(item.Item2);
                int mode = 0;
                while (!EOS(sr)) {
                    if (mode == 0) {
                        result += ReadTo(sr, '(').Length * item.Item1;
                        mode = 1;
                    } else if (mode == 1) {
                        sr.Read(); // (
                        int take = Convert.ToInt32(ReadTo(sr, 'x'));
                        sr.Read(); // x
                        int times = Convert.ToInt32(ReadTo(sr, ')'));
                        sr.Read(); // )
                        char[] toRepeat = new char[take];
                        sr.Read(toRepeat, 0, take);
                        toProcess.Enqueue(new Tuple<int, string>(times * item.Item1, new string(toRepeat)));
                        mode = 0;
                    }
                }
            }

            return result;
        }
    }
}
