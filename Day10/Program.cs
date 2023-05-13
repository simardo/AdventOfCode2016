using Day10;
using Libs;

string test1 = @"value 5 goes to bot 2
bot 2 gives low to bot 1 and high to bot 0
value 3 goes to bot 1
bot 1 gives low to output 1 and high to bot 0
bot 0 gives low to output 2 and high to output 0
value 2 goes to bot 2";

Console.WriteLine("Part1");
Console.WriteLine(new Part1(5, 2).Exec(test1));
using (StreamReader sr = new StreamReader(Utils.GetInputFilename())) {
    Console.WriteLine(new Part1(61, 17).Exec(sr.ReadToEnd()));
}

Console.WriteLine("Part2");
using (StreamReader sr = new StreamReader(Utils.GetInputFilename())) {
    Console.WriteLine(new Part2().Exec(sr.ReadToEnd()));
}