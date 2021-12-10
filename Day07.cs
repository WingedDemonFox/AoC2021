namespace GitAoCCSharp{
    public static class Day07{
        
        public static long Part1(){
            var crabsPositions = new List<int>();
            foreach (string line in File.ReadLines(@"data/day07.txt"))
            {
                var splittedLine = line.Split(',');
                foreach(string splitted in splittedLine){
                    var parsed = int.Parse(splitted);
                    crabsPositions.Add(parsed);
                }
            }

            crabsPositions.Sort();
            var getttindMedian = 0;
            if(crabsPositions.Count() % 2 == 0){
                getttindMedian = crabsPositions.Count/2;
            }
            else{
                getttindMedian = (crabsPositions.Count()+1) / 2;
            }
            var median = crabsPositions[crabsPositions.Count/2];

            var countNeededFuel = 0;
            foreach(var split in crabsPositions){
                var absol = Math.Abs(split - median);
                countNeededFuel+= absol;
            }

            return countNeededFuel;
        }

        public static long Part2(){
             var crabsPositions = new List<int>();
            foreach (string line in File.ReadLines(@"data/day07.txt"))
            {
                var splittedLine = line.Split(',');
                foreach(string splitted in splittedLine){
                    var parsed = int.Parse(splitted);
                    crabsPositions.Add(parsed);
                }
            }

            crabsPositions.Sort();
            
            var avgerage = (crabsPositions.Sum() / crabsPositions.Count());

            var countNeededFuel = 0;
            foreach(var split in crabsPositions){
                var absol = Math.Abs(split - avgerage+1);
                var addingFuel = 1;
                for(int i = 0; i <= absol; i++){
                    addingFuel += i;
                }
                countNeededFuel+= (addingFuel-1);
            }

            var countNeededFuelMean1 = 0;
            foreach(var split in crabsPositions){
                var absol = Math.Abs(split - avgerage-1);
                var addingFuel = 1;
                for(int i = 0; i <= absol; i++){
                    addingFuel += i;
                }
                countNeededFuelMean1+= (addingFuel-1);
            }

            var countNeededFuelMeanM1 = 0;
            foreach(var split in crabsPositions){
                var absol = Math.Abs(split - avgerage);
                var addingFuel = 1;
                for(int i = 0; i <= absol; i++){
                    addingFuel += i;
                }
                countNeededFuelMeanM1+= (addingFuel-1);
            }

            return Math.Min(countNeededFuel, Math.Min(countNeededFuelMean1, countNeededFuelMeanM1));
        }
    }
}