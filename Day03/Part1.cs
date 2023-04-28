namespace Day03 {
    internal class Part1 {

        public Part1() {
        }

        public int exec(string input) {
            List<string> triangles = input.Split('\n').ToList();

            return triangles.Count(t => {
                List<int> sides = t.Split(' ').Where(s => !string.IsNullOrEmpty(s)).Select(int.Parse).ToList();
                return sides[0] < sides[1] + sides[2] && sides[1] < sides[0] + sides[2] && sides[2] < sides[0] + sides[1];
            });
        }
    }
}
