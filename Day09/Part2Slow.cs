using System.Text;

namespace Day09 {

    internal class Part2Slow {

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

        public Part2Slow(string input) {
            this.input = input;
        }

        public long Exec() {
            long result = 0;
            bool toProcess = true;
            while (toProcess) {
                toProcess = false;
                StringBuilder temp = new StringBuilder();
                using StringReader sr = new StringReader(input);
                int mode = 0;

                while (!EOS(sr)) {
                    if (mode == 0) {
                        result += ReadTo(sr, '(').Length;
                        mode = 1;
                    } else if (mode == 1) {
                        toProcess = true;
                        sr.Read(); // (
                        int take = Convert.ToInt32(ReadTo(sr, 'x'));
                        sr.Read(); // x
                        int times = Convert.ToInt32(ReadTo(sr, ')'));
                        sr.Read(); // )
                        char[] toRepeat = new char[take];
                        sr.Read(toRepeat, 0, take);
                        if (toRepeat.Contains('(') || toRepeat.Contains(')') || toRepeat.Contains('x')) {
                            for (int i = 1; i <= times; i++) {
                                temp.Append(toRepeat);
                            }
                            if (temp.Length > 0.75 * temp.Capacity) {
                                break;
                            }
                        } else {
                            result += (take * times);
                        }
                        mode = 0;
                    }
                }

                input = temp.ToString() + sr.ReadToEnd();
            }
            return result;
        }
    }
}
