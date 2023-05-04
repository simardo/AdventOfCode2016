using Day06;
using Libs;

string test1 = @"eedadn
drvtee
eandsr
raavrd
atevrs
tsrnev
sdttsa
rasrtv
nssdts
ntnada
svetve
tesnvt
vntsnd
vrdear
dvrsen
enarar";

Part1 p1 = new Part1();

Console.WriteLine("Part1");
Console.WriteLine(p1.exec(test1));
Console.WriteLine(p1.exec(new StreamReader(Utils.GetInputFilename()).ReadToEnd()));

Part2 p2 = new Part2();

Console.WriteLine("Part2");
Console.WriteLine(p2.exec(test1));
Console.WriteLine(p2.exec(new StreamReader(Utils.GetInputFilename()).ReadToEnd()));