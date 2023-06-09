﻿namespace Day06 {

    internal class Part2 {

        public Part2() {
        }

        public string exec(string input) {
            List<Dictionary<char, int>> corrected = new List<Dictionary<char, int>>();

            string[] messages = input.Replace("\r", null).Split('\n');
            foreach (string message in messages) {
                if (corrected.Count == 0) {
                    for (int i = 1; i <= message.Length; i++) {
                        corrected.Add(new Dictionary<char, int>());
                    }
                }
                for (int i = 0; i < message.Length; i++) {
                    if (!corrected[i].ContainsKey(message[i])) {
                        corrected[i].Add(message[i], 0);
                    }
                    corrected[i][message[i]] = corrected[i][message[i]] + 1;
                }
            }

            string result = "";
            foreach (Dictionary<char, int> c in corrected) {
                KeyValuePair<char, int> max = c.Aggregate(new KeyValuePair<char, int>('z', int.MaxValue), (prev, kv) => {
                    if (kv.Value < prev.Value) {
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
