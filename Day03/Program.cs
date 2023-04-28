using Day03;
using Libs;

string test1 = "    5   10   25";

Part1 p1 = new Part1();

Console.WriteLine("Part1");
Console.WriteLine(p1.exec(test1));
Console.WriteLine(p1.exec(new StreamReader(Utils.GetInputFilename()).ReadToEnd()));


Part2 p2 = new Part2();

Console.WriteLine("Part2");
Console.WriteLine(p2.exec(new StreamReader(Utils.GetInputFilename()).ReadToEnd()));