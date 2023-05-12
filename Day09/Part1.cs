using System.Text;

namespace Day09 {

    internal class Part1 {

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

        public Part1(string input) {
            this.input = input;
        }

        public int Exec() {
            using StringReader sr = new StringReader(input);
            int result = 0;
            int mode = 0;

            while (!EOS(sr)) {
                if (mode == 0) {
                    result += ReadTo(sr, '(').Length;
                    mode = 1;
                } else if (mode == 1) {
                    sr.Read(); // (
                    int take = Convert.ToInt32(ReadTo(sr, 'x'));
                    sr.Read(); // x
                    int times = Convert.ToInt32(ReadTo(sr, ')'));
                    sr.Read(); // )
                    result += (take * times);
                    sr.Read(new char[take], 0, take);
                    mode = 0;
                }
            }
            return result;
        }
    }
}
