using System.Text;

namespace Day02 {
    internal class Part1 {
        Dictionary<char, int> index = new Dictionary<char, int>();
        Dictionary<int, int[]> keyPad = new Dictionary<int, int[]>();

        public Part1() {
            index.Add('U', 0);
            index.Add('L', 1);
            index.Add('R', 2);
            index.Add('D', 3);

            keyPad.Add(1, new int[] { -1, -1, 2, 4 });
            keyPad.Add(2, new int[] { -1, 1, 3, 5 });
            keyPad.Add(3, new int[] { -1, 2, -1, 6 });
            keyPad.Add(4, new int[] { 1, -1, 5, 7 });
            keyPad.Add(5, new int[] { 2, 4, 6, 8 });
            keyPad.Add(6, new int[] { 3, 5, -1, 9 });
            keyPad.Add(7, new int[] { 4, -1, 8, -1 });
            keyPad.Add(8, new int[] { 5, 7, 9, -1 });
            keyPad.Add(9, new int[] { 6, 8, -1, -1 });
        }

        public string exec(string input) {
            string[] directions = input.Replace("\r", null).Split("\n");

            List<int> result = new List<int>();
            int number = 5;

            foreach (string d in directions) {
                foreach (char c in d) {
                    int next = keyPad[number][index[c]];
                    if (next != -1) {
                        number = next;
                    }
                }
                result.Add(number);
            }

            return String.Join("", result);
        }
    }
}
