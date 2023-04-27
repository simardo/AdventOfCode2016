using System.Text;

namespace Day02 {
    internal class Part2 {
        Dictionary<char, int> index = new Dictionary<char, int>();
        Dictionary<int, int[]> keyPad = new Dictionary<int, int[]>();
/*
    1
  2 3 4
5 6 7 8 9
  A B C
    D
*/
        public Part2() {
            index.Add('U', 0);
            index.Add('L', 1);
            index.Add('R', 2);
            index.Add('D', 3);

            keyPad.Add(1, new int[] { -1, -1, -1, 3 });
            keyPad.Add(2, new int[] { -1, -1, 3, 6 });
            keyPad.Add(3, new int[] { 1, 2, 4, 7 });
            keyPad.Add(4, new int[] { -1, 3, -1, 8 });
            keyPad.Add(5, new int[] { -1, -1, 6, -1 });
            keyPad.Add(6, new int[] { 2, 5, 7, 'A' });
            keyPad.Add(7, new int[] { 3, 6, 8, 'B' });
            keyPad.Add(8, new int[] { 4, 7, 9, 'C' });
            keyPad.Add(9, new int[] { -1, 8, -1, -1 });
            keyPad.Add('A', new int[] { 6, -1, 'B', -1 });
            keyPad.Add('B', new int[] { 7, 'A', 'C', 'D' });
            keyPad.Add('C', new int[] { 8, 'B', -1, -1 });
            keyPad.Add('D', new int[] { 'B', -1, -1, -1 });
        }

        public string exec(string input) {
            string[] directions = input.Replace("\r", null).Split("\n");

            StringBuilder result = new StringBuilder();
            int number = 5;

            foreach (string d in directions) {
                foreach (char c in d) {
                    int next = keyPad[number][index[c]];
                    if (next != -1) {
                        number = next;
                    }
                }
                result.Append(number > 9 ? Convert.ToChar(number).ToString() : number);
            }

            return result.ToString();
        }
    }
}
