using System.Text.RegularExpressions;

namespace Day10 {

    internal class Bot {
        private readonly List<int> chips = new List<int>();

        private bool initialized = false;

        private readonly int value1;
        private readonly int value2;

        private void GiveChips() {
            if (initialized && chips.Count == 2) {
                Low!.AddChip(Math.Min(chips[0], chips[1]));
                High!.AddChip(Math.Max(chips[0], chips[1]));

                if (chips[0] == value1 && chips[1] == value2 || chips[1] == value1 && chips[0] == value2) {
                    Target = true;
                }

                chips.Clear();
            }
        }

        public Bot(int id, int value1, int value2) {
            ID = id;
            this.value1 = value1;
            this.value2 = value2;
        }

        public int ID { get; private set; }

        public Bot? Low { get; set; }

        public Bot? High { get; set; }

        public bool Target { get; set; }

        public List<int> Chips {
            get {
                return chips;
            }
        }

        public void AddChip(int value) {
            chips.Add(value);
            GiveChips();
        }

        public void Init() {
            initialized = true;
            GiveChips();
        }
    }

    internal partial class Part1 {
        private readonly Dictionary<int, Bot> bots = new Dictionary<int, Bot>();
        private readonly Dictionary<int, Bot> outputs = new Dictionary<int, Bot>();

        [GeneratedRegex(@"value (\d+) goes to bot (\d+)", RegexOptions.IgnoreCase)]
        private partial Regex ValueBotRegex();

        [GeneratedRegex(@"bot (\d+) gives low to (bot|output) (\d+) and high to (bot|output) (\d+)", RegexOptions.IgnoreCase)]
        private partial Regex BotGivesRegex();

        private readonly int value1;
        private readonly int value2;

        public Part1(int value1, int value2) {
            this.value1 = value1;
            this.value2 = value2;
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

            Bot result = bots.Values.First(b => b.Target);

            return result.ID;
        }

        private Bot GetBotByID(int id) {
            if (!bots.TryGetValue(id, out Bot? bot)) {
                bot = new Bot(id, value1, value2);
                bots.Add(id, bot);
            }
            return bot;
        }

        private Bot GetOutputByID(int id) {
            if (!outputs.TryGetValue(id, out Bot? output)) {
                output = new Bot(id, value1, value2);
                outputs.Add(id, output);
            }
            return output;
        }
    }
}
