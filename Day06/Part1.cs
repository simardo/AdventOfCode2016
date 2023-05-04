namespace Day06 {

    internal class Part1 {

        public Part1() {
        }

        public string exec(string input) {
            List<Dictionary<char, int>> corrected = new List<Dictionary<char, int>>();

            string[] messages = input.Replace("\r", null).Split('\n');
            foreach (string message in messages) {
                char[] chars = message.ToCharArray();
                if (corrected.Count == 0) {
                    for (int i = 1; i <= chars.Length; i++) { 
                        corrected.Add(new Dictionary<char, int>());
                    }
                }
                for (int i = 0; i < chars.Length; i++) {
                    if (!corrected[i].ContainsKey(chars[i])) {
                        corrected[i].Add(chars[i], 0);
                    }
                    corrected[i][chars[i]] = corrected[i][chars[i]] + 1;
                }
            }

            string result = "";
            foreach (Dictionary<char, int> c in corrected) {
               KeyValuePair<char, int> max = c.Aggregate(new KeyValuePair<char, int>('z', int.MinValue), (prev, kv) => {
                    if (kv.Value > prev.Value) {
                        return kv;
                    }
                    return prev;
                });
                result += max.Key;
            }

            return result;
        }
    }
}
