namespace GitAoCCSharp{
    public class Fish{
        int FishTimer = 0;
        public Fish(){
            FishTimer = 8;
        }
        public Fish(int timer){
            FishTimer = timer;
        }

        public bool DecreaseAndIsThereNew(){
            if(FishTimer == 0){
                FishTimer = 6;
                return true;
            }
            FishTimer -= 1;
            return false;
        }        
    }
    public static class Day06{
        
        public static long Part1(){
            var inputList = new List<Fish>();
            var howManyDays = 80;
            foreach (string line in File.ReadLines(@"data/day06.txt"))
            {
                var splittedLine = line.Split(',');
                foreach(string splitted in splittedLine){
                    inputList.Add(new Fish(int.Parse(splitted)));
                }
            }

            for(int i = 0; i < howManyDays; i++){
                var newFishy = new List<Fish>();

                foreach(Fish fish in inputList){
                    if(fish.DecreaseAndIsThereNew()){
                        newFishy.Add(new Fish());
                    }
                }

                inputList.AddRange(newFishy);
            }
            Console.WriteLine(inputList.Count());

            return inputList.Count();
        }

        public static long Part2(){
            var fishInTimer = new long[9];
            var howManyDays = 256;
            foreach (string line in File.ReadLines(@"data/day06.txt"))
            {
                var splittedLine = line.Split(',');
                foreach(string splitted in splittedLine){
                    var parsed = int.Parse(splitted);
                    fishInTimer[parsed] += 1;
                }
            }

            for(int i = 0; i < howManyDays; i++){
                var fishZeroTemp = fishInTimer[0];
                fishInTimer[0] = fishInTimer[1];
                fishInTimer[1] = fishInTimer[2];
                fishInTimer[2] = fishInTimer[3];
                fishInTimer[3] = fishInTimer[4];
                fishInTimer[4] = fishInTimer[5];
                fishInTimer[5] = fishInTimer[6];
                fishInTimer[6] = fishInTimer[7]+fishZeroTemp;
                fishInTimer[7] = fishInTimer[8];
                fishInTimer[8] = fishZeroTemp;
            }
            long count = 0;
            for(int i = 0; i < 9; i++){
                count += fishInTimer[i];
            }
            return count;
        }
    }
}