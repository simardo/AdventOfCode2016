namespace Day01 {
    internal class Part2 {
        Dictionary<char, char> left;
        Dictionary<char, char> right;
        Dictionary<char, Dictionary<char, char>> leftOrRight;

        public Part2() {
            left = new Dictionary<char, char>();
            left.Add('N', 'W');
            left.Add('W', 'S');
            left.Add('S', 'E');
            left.Add('E', 'N');

            right = new Dictionary<char, char>();
            right.Add('N', 'E');
            right.Add('E', 'S');
            right.Add('S', 'W');
            right.Add('W', 'N');

            leftOrRight = new Dictionary<char, Dictionary<char, char>>();
            leftOrRight.Add('R', right);
            leftOrRight.Add('L', left);
        }

        public int exec(string input) {
            string[] directions = input.Split(", ");

            char compass = 'N';
            int x = 0;
            int y = 0;

            HashSet<string> visited = new HashSet<string>();

            foreach (string d in directions) {
                char direction = d[0];
                int blocks = Int32.Parse(d.Substring(1));

                compass = leftOrRight[direction][compass];
                for (int i = 1; i <= blocks; i++) {
                    if (compass == 'E') {
                        x++;
                    } else if (compass == 'W') {
                        x--;
                    } else if (compass == 'N') {
                        y++;
                    } else if (compass == 'S') {
                        y--;
                    }

                    string pos = $"{x},{y}";
                    if (!visited.Add(pos)) {
                        return Math.Abs(x) + Math.Abs(y);
                    }
                }
            }

            return 0;
        }
    }
}
