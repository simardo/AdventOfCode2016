using Libs;
using System.Text.RegularExpressions;

namespace Day08 {

    internal partial class Part1 {

        [GeneratedRegex(@"rect (\d+)x(\d+)", RegexOptions.IgnoreCase)]
        private partial Regex RectRegex();

        [GeneratedRegex(@"rotate row y=(\d+) by (\d+)", RegexOptions.IgnoreCase)]
        private partial Regex RotateRowRegex();

        [GeneratedRegex(@"rotate column x=(\d+) by (\d+)", RegexOptions.IgnoreCase)]
        private partial Regex RotateColumnRegex();

        private int width;
        private int height;

        private List<OldNew<bool>> values;
        private OldNew<bool>[][] display;

        private void Apply() {
            foreach (OldNew<bool> value in values) {
                value.Apply();
            }
        }

        public Part1(int width, int height) {
            this.width = width;
            this.height = height;

            values = new List<OldNew<bool>>();
            display = new OldNew<bool>[height][];
        }

        public int Exec(string input) {
            List<string> sequences = new List<string>(input.Replace("\r", null).Split('\n'));

            for (int row = 0; row < height; row++) {
                display[row] = new OldNew<bool>[width];
                for (int col = 0; col < width; col++) {
                    OldNew<bool> value = new OldNew<bool>(false);
                    display[row][col] = value;
                    values.Add(value);
                }
            }

            foreach (string sequence in sequences) {
                Match m;
                m = RectRegex().Match(sequence);
                if (m.Success) {
                    int w = Convert.ToInt32(m.Groups[1].Value);
                    int h = Convert.ToInt32(m.Groups[2].Value);

                    for (int x = 0; x < w; x++) {
                        for (int y = 0; y < h; y++) {
                            display[y][x].Value = true;
                        }
                    }
                    Apply();

                    continue;
                }
                m = RotateRowRegex().Match(sequence);
                if (m.Success) {
                    int y = Convert.ToInt32(m.Groups[1].Value);
                    int b = Convert.ToInt32(m.Groups[2].Value) % width;

                    for (int x = 0; x < width; x++) {
                        int target = x + b;
                        if (target >= width) {
                            target = target - width;
                        }
                        display[y][target].Value = display[y][x].Value;
                    }
                    Apply();

                    continue;
                }
                m = RotateColumnRegex().Match(sequence);
                if (m.Success) {
                    int x = Convert.ToInt32(m.Groups[1].Value);
                    int b = Convert.ToInt32(m.Groups[2].Value) % height;

                    for (int y = 0; y < height; y++) {
                        int target = y + b;
                        if (target >= height) {
                            target = target - height;
                        }
                        display[target][x].Value = display[y][x].Value;
                    }

                    Apply();
                    continue;
                }
            }

            return values.Count(v => v.Value == true);
        }

        public string Render() {
            return string.Join("\n", display.Select(row => string.Join("", row.Select(col => col.Value ? "#" : " "))));
        }
    }
}
