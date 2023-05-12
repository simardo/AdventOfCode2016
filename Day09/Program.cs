using Day09;
using Libs;

string test1 = "ADVENT";
string test2 = "A(1x5)BC";
string test3 = "(3x3)XYZ";
string test4 = "A(2x2)BCD(2x2)EFG";
string test5 = "(6x1)(1x3)A";
string test6 = "X(8x2)(3x3)ABCY";

Console.WriteLine("Part1");
Console.WriteLine(new Part1(test1).Exec());
Console.WriteLine(new Part1(test2).Exec());
Console.WriteLine(new Part1(test3).Exec());
Console.WriteLine(new Part1(test4).Exec());
Console.WriteLine(new Part1(test5).Exec());
Console.WriteLine(new Part1(test6).Exec());
using (StreamReader sr = new StreamReader(Utils.GetInputFilename())) {
    Console.WriteLine(new Part1(sr.ReadToEnd()).Exec());
}

string test7 = "(27x12)(20x12)(13x14)(7x10)(1x12)A";
string test8 = "(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN";

Console.WriteLine("Part2");
Console.WriteLine(new Part2(test3).Exec());
Console.WriteLine(new Part2(test6).Exec());
Console.WriteLine(new Part2(test7).Exec());
Console.WriteLine(new Part2(test8).Exec());
using (StreamReader sr = new StreamReader(Utils.GetInputFilename())) {
    Console.WriteLine(new Part2(sr.ReadToEnd()).Exec());
}