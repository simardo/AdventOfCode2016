namespace Day03 {
    internal class Part2 {

        public Part2() {
        }

        public int exec(string input) {
            List<string> rows = input.Split('\n').ToList();

            List<int>[] triangles = reset();

            int result = 0;
            for (int i = 0; i < rows.Count; i++) {
                List<int> cols = rows[i].Split(' ').Where(s => !string.IsNullOrEmpty(s)).Select(int.Parse).ToList();
                for (int c = 0; c < cols.Count; c++) {
                    triangles[c].Add(cols[c]);
                }
                if (triangles[0].Count % 3 == 0) {
                    result += triangles.Count(sides => sides[0] < sides[1] + sides[2] && sides[1] < sides[0] + sides[2] && sides[2] < sides[0] + sides[1]);
                    triangles = reset();
                }
            }

            return result;
        }

        private List<int>[] reset() {
            return new List<int>[] {
                new List<int>(),
                new List<int>(),
                new List<int>()
            };
        }
    }
}
