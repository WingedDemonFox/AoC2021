namespace GitAoCCSharp{

    public static class Day05{
        
        public static long Part1(){

            var part1sX = new List<long>();
            var part1sY = new List<long>();
            var part2sX = new List<long>();
            var part2sY = new List<long>();

            foreach (string line in File.ReadLines(@"data/day05.txt"))
            {
                var splittedLine = line.Split(" -> ");
                var part1 = splittedLine[0].Split(",");
                var part2 = splittedLine[1].Split(",");
                
                var x1Temp = Convert.ToInt64(part1[0]);
                var y1Temp = Convert.ToInt64(part1[1]);

                var x2Temp = Convert.ToInt64(part2[0]);
                var y2Temp = Convert.ToInt64(part2[1]);

                if((x1Temp == x2Temp) || (y1Temp == y2Temp)){
                    part1sX.Add(x1Temp);
                    part1sY.Add(y1Temp);
                    part2sX.Add(x2Temp);
                    part2sY.Add(y2Temp);
                }
            }
            
            var sizeXForBoard = Math.Max(part1sX.Max(), part2sX.Max())+1;
            var sizeYForBoard = Math.Max(part1sY.Max(), part2sY.Max())+1;

            var boardMade = new long[sizeYForBoard, sizeXForBoard];

            for (int pointIndex = 0; pointIndex < part1sX.Count(); pointIndex++){
                var x1 = part1sX[pointIndex];
                var y1 = part1sY[pointIndex];

                var x2 = part2sX[pointIndex];
                var y2 = part2sY[pointIndex];

                if(x1 == x2){
                    var minY = Math.Min(y1, y2);
                    var maxY = Math.Max(y1,y2);
                    for(var i = minY; i <= maxY; i++){
                        boardMade[i, x1] += 1;
                    }
                }else if( y1 == y2){
                    var minX = Math.Min(x1, x2);
                    var maxX = Math.Max(x1,x2);
                    for(var i = minX; i <= maxX; i++){
                        boardMade[y1, i] += 1;
                    }
                }
                else{
                    continue;
                }
            }

            //PrintBoard(sizeXForBoard, sizeYForBoard, boardMade);
            
        
            return maxCountValue(sizeXForBoard, sizeYForBoard, boardMade);
        }

        public static long maxCountValue(long sizeX, long sizeY, long[,] board){
            var dictToFindMax = new Dictionary<long, long>();
            for(int i = 0; i < sizeY; i++){
                for(int j = 0; j < sizeX; j++){
                    var num = board[i,j];
                    if(!dictToFindMax.ContainsKey(num)){
                        dictToFindMax.Add(num,1);
                    }else{
                        dictToFindMax[num] += 1;
                    }
                }
            }
            
            if(dictToFindMax.ContainsKey(1) || dictToFindMax.ContainsKey(0)){
                dictToFindMax.Remove(1);
                dictToFindMax.Remove(0);
            }

            return dictToFindMax.Values.Sum();
        }

        public static void PrintBoard(long sizeX, long sizeY, long[,] board){
            for(int i = 0; i < sizeY; i++){
                for(int j = 0; j < sizeX; j++){
                    Console.Write(board[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            
        }


        public static long Part2(){
            var part1sX = new List<long>();
            var part1sY = new List<long>();
            var part2sX = new List<long>();
            var part2sY = new List<long>();

            foreach (string line in File.ReadLines(@"data/day05.txt"))
            {
                var splittedLine = line.Split(" -> ");
                var part1 = splittedLine[0].Split(",");
                var part2 = splittedLine[1].Split(",");
                
                var x1Temp = Convert.ToInt64(part1[0]);
                var y1Temp = Convert.ToInt64(part1[1]);

                var x2Temp = Convert.ToInt64(part2[0]);
                var y2Temp = Convert.ToInt64(part2[1]);

                part1sX.Add(x1Temp);
                part1sY.Add(y1Temp);
                part2sX.Add(x2Temp);
                part2sY.Add(y2Temp);
                
            }

            var sizeXForBoard = Math.Max(part1sX.Max(), part2sX.Max())+1;
            var sizeYForBoard = Math.Max(part1sY.Max(), part2sY.Max())+1;
            var boardMade = new long[sizeYForBoard, sizeXForBoard];

            for (int pointIndex = 0; pointIndex < part1sX.Count(); pointIndex++){
                var x1 = part1sX[pointIndex];
                var y1 = part1sY[pointIndex];

                var x2 = part2sX[pointIndex];
                var y2 = part2sY[pointIndex];

                if(x1 == x2){
                    var minY = Math.Min(y1, y2);
                    var maxY = Math.Max(y1,y2);
                    
                    for(var i = minY; i <= maxY; i++){
                        boardMade[i, x1] += 1;
                    }
                }else if( y1 == y2){
                    var minX = Math.Min(x1, x2);
                    var maxX = Math.Max(x1,x2);
                   
                    for(var i = minX; i <= maxX; i++){
                        boardMade[y1, i] += 1;
                    }
                } else if (true){
                    if(x1 < x2 && y1 < y2){
                        for(int i = 0; i < 200000; i++){
                            boardMade[y1+i,x1+i] += 1;
                            if(y1+i == y2 && x1+i == x2){
                                break;
                            }
                        }
                    }
                    else if(x1 > x2 && y1 > y2){
                        for(int i = 0; i < 200000; i++){
                            boardMade[y1-i,x1-i] += 1;
                            if(y1-i == y2 && x1-i == x2){
                                break;
                            }
                        }
                    } else if(x1 < x2 && y1 > y2){
                        for(int i = 0; i < 200000; i++){
                            boardMade[y1-i,x1+i] += 1;
                            if(y1-i == y2 && x1+i == x2){
                                break;
                            }
                        }
                    } else if(x1 > x2 && y1 < y2){
                        for(int i = 0; i < 200000; i++){
                            boardMade[y1+i,x1-i] += 1;
                            if(y1+i == y2 && x1-i == x2){
                                break;
                            }
                        }
                    }

                    
                }
            }

            //PrintBoard(sizeXForBoard, sizeYForBoard, boardMade);
            
        
            return maxCountValue(sizeXForBoard, sizeYForBoard, boardMade);
        }
    }
}