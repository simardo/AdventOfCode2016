using Day04;
using Libs;

string test1 = @"aaaaa-bbb-z-y-x-123[abxyz]
a-b-c-d-e-f-g-h-987[abcde]
not-a-real-room-404[oarel]
totally-real-room-200[decoy]";

Part1 p1 = new Part1();

Console.WriteLine("Part1");
Console.WriteLine(p1.exec(test1));
Console.WriteLine(p1.exec(new StreamReader(Utils.GetInputFilename()).ReadToEnd()));

string test2 = "qzmt-zixmtkozy-ivhz-343[zim]";

Part2 p2 = new Part2();

Console.WriteLine("Part2");
Console.WriteLine(p2.exec(test2));
Console.WriteLine(p2.exec(new StreamReader(Utils.GetInputFilename()).ReadToEnd()));