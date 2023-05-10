using Day08;
using Libs;

string test1 = @"rect 3x2
rotate column x=1 by 1
rotate row y=0 by 4
rotate column x=1 by 1";

Console.WriteLine("Part1");
Console.WriteLine(new Part1(7, 3).Exec(test1));
Part1 p1 = new Part1(50, 6);
Console.WriteLine(p1.Exec(new StreamReader(Utils.GetInputFilename()).ReadToEnd()));
Console.WriteLine(p1.Render());