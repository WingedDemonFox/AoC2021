using GitAoCCSharp;

string[] arrg = Environment.GetCommandLineArgs();

switch(int.Parse(arrg[1])){
    case 3: 
        Console.WriteLine("Day 03 Part 1: " + Day03.Part1());
        Console.WriteLine("Day 03 Part 2: " + Day03.Part2());
        break;
    case 4: 
        Console.WriteLine("Day 04 Part 1: " + Day04.Part1());
        Console.WriteLine("Day 04 Part 2: " + Day04.Part2());
        break;
    case 5: 
        Console.WriteLine("Day 05 Part 1: " + Day05.Part1());
        Console.WriteLine("Day 05 Part 2: " + Day05.Part2());
        break;
    case 6: 
        Console.WriteLine("Day 06 Part 1: " + Day06.Part1());
        Console.WriteLine("Day 06 Part 2: " + Day06.Part2());
        break;
    case 7: 
        Console.WriteLine("Day 07 Part 1: " + Day07.Part1());
        Console.WriteLine("Day 07 Part 2: " + Day07.Part2());
        break;
    default:
        Console.WriteLine("no input given");
        break;
}
