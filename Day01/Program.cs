using Day01;

string test1 = "R2, L3";
string test2 = "R2, R2, R2";
string test3 = "R5, L5, R5, R3";

Part1 p1 = new Part1();

Console.WriteLine("Part1");
Console.WriteLine(p1.exec(test1));
Console.WriteLine(p1.exec(test2));
Console.WriteLine(p1.exec(test3));
Console.WriteLine(p1.exec(new StreamReader("C:\\Users\\simardo\\source\\repos\\AdventOfCode2016\\Day01\\input.txt").ReadToEnd()));

string test4 = "R8, R4, R4, R8";

Part2 p2 = new Part2();

Console.WriteLine("Part2");
Console.WriteLine(p2.exec(test4));
Console.WriteLine(p2.exec(new StreamReader("C:\\Users\\simardo\\source\\repos\\AdventOfCode2016\\Day01\\input.txt").ReadToEnd()));