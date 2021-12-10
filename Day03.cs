namespace GitAoCCSharp{
    public static class Day03{
        static int LengthLine = 12;
        public static long Part1(){
           
            string gammaRateCheat = String.Empty;
            string epsilonRateCheat = String.Empty;

            int countLines = 0;

            var maxCountArray = new int[LengthLine];
            foreach (string line in File.ReadLines(@"data/day03.txt"))
            {
                countLines += 1;
                for(var i = 0; i < LengthLine; i++){
                    maxCountArray[i] += line[i]-'0';
                }
            }

            for(var i = 0; i < LengthLine; i++){
                if(maxCountArray[i] < countLines/2){
                    gammaRateCheat = gammaRateCheat + '0';
                    epsilonRateCheat = epsilonRateCheat + '1';
                }else{
                    gammaRateCheat = gammaRateCheat + '1';
                    epsilonRateCheat = epsilonRateCheat +'0';
                }
            }

            var gammaRate = Convert.ToInt64(gammaRateCheat,2);
            var epsilonRate = Convert.ToInt64(epsilonRateCheat, 2);

            return gammaRate * epsilonRate;
        }    

        public static long Part2(){
            var allLinesForOxy = new List<string>();
            var allLinesForC02 = new List<string>();
            var oxyRate = String.Empty;
            var co2Rate = String.Empty;

            foreach (string line in File.ReadLines(@"data/day03.txt"))
            {
                allLinesForOxy.Add(line);
                allLinesForC02.Add(line);
            }

            oxyRate = FindOxy(allLinesForOxy, 0);
            co2Rate = FindCo2(allLinesForC02, 0);
            
            var oxy = Convert.ToInt64(oxyRate,2);
            var co2 = Convert.ToInt64(co2Rate, 2);
            
            return oxy * co2;
        }


        private static string FindOxy(List<string> oxyList, int position){
            if(position >= LengthLine){
                return oxyList[0];
            }
            var mostCommon = FindMostCommonInPosition(oxyList, position, oxyList.Count());
        
            var newList = FilterOutOnPosition(oxyList, position, mostCommon);
             if(newList.Count() == 1){
                return newList[0];
            }else{
                return FindOxy(newList, position+1);
            }            
        }

        private static string FindCo2(List<string> co2List, int position){
            if(position >= LengthLine){
                return co2List[0];
            }
            var mostCommon = FindLeastCommonInPosition(co2List, position);

            var newList = FilterOutOnPosition(co2List, position, mostCommon);
            if(newList.Count() == 1){
                return newList[0];
            }else{
                return FindCo2(newList, position+1);
            }            
        }

        private static List<string> FilterOutOnPosition(List<string> allLines, int position, int toFilterOut){
            var newList = new List<string>();
            foreach(var line in allLines){
                if((line[position] -'0')== toFilterOut){
                     newList.Add(line);
                }
            }
            return newList;
        }

        private static int FindMostCommonInPosition(List<string> allLines, int position, int count){
            var maxCount = 0;

            foreach(string line in allLines){
                maxCount += line[position] - '0';
            }

            if(maxCount < Math.Ceiling(count/2.0)){
                return  0;
            }else if( maxCount >= count/2){
               return   1;
            }
            
            return -9999;
        }

        private static int FindLeastCommonInPosition(List<string> allLines, int position){
            var result = -1;
            var maxCountArray = new int[LengthLine];

            foreach(string line in allLines){
                maxCountArray[position] += line[position] - '0';
            }
            
            if(maxCountArray[position] < Math.Ceiling(allLines.Count/2.0)){
                result = 1;
            }else{
               result = 0;
            }
            
            return result;
        }

    }
}