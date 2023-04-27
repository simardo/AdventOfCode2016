namespace Day01 {
    internal class Part1 {
        Dictionary<char, char> left = new Dictionary<char, char>();
        Dictionary<char, char> right = new Dictionary<char, char>();
        Dictionary<char, Dictionary<char, char>> leftOrRight = new Dictionary<char, Dictionary<char, char>>();

        public Part1() {
            left.Add('N', 'W');
            left.Add('W', 'S');
            left.Add('S', 'E');
            left.Add('E', 'N');

            right.Add('N', 'E');
            right.Add('E', 'S');
            right.Add('S', 'W');
            right.Add('W', 'N');

            leftOrRight.Add('R', right);
            leftOrRight.Add('L', left);
        }

        public int exec(string input) {
            string[] directions = input.Split(", ");

            char compass = 'N';
            int x = 0;
            int y = 0;

            foreach (string d in directions) {
                char direction = d[0];
                int blocks = Int32.Parse(d.Substring(1));

                compass = leftOrRight[direction][compass];
                if (compass == 'E') {
                    x += blocks;
                } else if (compass == 'W') {
                    x -= blocks;
                } else if (compass == 'N') {
                    y += blocks;
                } else if (compass == 'S') {
                    y -= blocks;
                }
            }

            return Math.Abs(x) + Math.Abs(y);
        }
    }
}
