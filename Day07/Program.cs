using Day07;
using Libs;

string test1 = @"abba[mnop]qrst
abcd[bddb]xyyx
aaaa[qwer]tyui
ioxxoj[asdfgh]zxcvbn";

Part1 p1 = new Part1();

Console.WriteLine("Part1");
Console.WriteLine(p1.exec(test1));
Console.WriteLine(p1.exec(new StreamReader(Utils.GetInputFilename()).ReadToEnd()));

string test2 = @"aba[bab]xyz
xyx[xyx]xyx
aaa[kek]eke
zazbz[bzb]cdb
kkkfysfugyvqnfvj[ahhqkrufcvhfvapblc]jfincvlxbjivelqrs[mpoymhslpyekjmy]eicbqlzecwuugez[tsqmqvjiokqofbp]senbbdxrdigwcjwik";

Part2 p2 = new Part2();

Console.WriteLine("Part2");
Console.WriteLine(p2.exec(test2));
Console.WriteLine(p2.exec(new StreamReader(Utils.GetInputFilename()).ReadToEnd()));