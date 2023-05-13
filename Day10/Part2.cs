using System.Text.RegularExpressions;

namespace Day10 {

    internal partial class Part2 {
        private readonly Dictionary<int, Bot> bots = new Dictionary<int, Bot>();
        private readonly Dictionary<int, Bot> outputs = new Dictionary<int, Bot>();

        [GeneratedRegex(@"value (\d+) goes to bot (\d+)", RegexOptions.IgnoreCase)]
        private partial Regex ValueBotRegex();

        [GeneratedRegex(@"bot (\d+) gives low to (bot|output) (\d+) and high to (bot|output) (\d+)", RegexOptions.IgnoreCase)]
        private partial Regex BotGivesRegex();

        public Part2() {
        }

        const string BOT = "bot";

        public int Exec(string input) {
            using StringReader sr = new StringReader(input);
            string? s;
            while ((s = sr.ReadLine()) != null) {
                Match m = ValueBotRegex().Match(s);
                if (m.Success) {
                    int value = Convert.ToInt32(m.Groups[1].Value);
                    int botNumber = Convert.ToInt32(m.Groups[2].Value);

                    GetBotByID(botNumber).AddChip(value);

                    continue;
                }
                m = BotGivesRegex().Match(s);
                if (m.Success) {
                    int botNumber = Convert.ToInt32(m.Groups[1].Value);
                    string lowDestination = m.Groups[2].Value;
                    int idLowDestination = Convert.ToInt32(m.Groups[3].Value);
                    string highDestination = m.Groups[4].Value;
                    int idHighDestination = Convert.ToInt32(m.Groups[5].Value);

                    Bot bot = GetBotByID(botNumber);
                    bot.Low = lowDestination == BOT ? GetBotByID(idLowDestination) : GetOutputByID(idLowDestination);
                    bot.High = highDestination == BOT ? GetBotByID(idHighDestination) : GetOutputByID(idHighDestination);

                    continue;
                }
            }

            foreach (Bot b in bots.Values) {
                b.Init();
            }

            return outputs[0].Chips[0] * outputs[1].Chips[0] * outputs[2].Chips[0];
        }

        private Bot GetBotByID(int id) {
            if (!bots.TryGetValue(id, out Bot? bot)) {
                bot = new Bot(id, 0, 0);
                bots.Add(id, bot);
            }
            return bot;
        }

        private Bot GetOutputByID(int id) {
            if (!outputs.TryGetValue(id, out Bot? output)) {
                output = new Bot(id, 0, 0);
                outputs.Add(id, output);
            }
            return output;
        }
    }
}
