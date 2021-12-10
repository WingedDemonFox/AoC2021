namespace GitAoCCSharp{
    public class Bingo{
        int[,] NumberBoard = new int[5,5];
        
        public bool HasWonOnce = false;

        bool [,] MarkedBoard = new bool[5,5];
        int WinningNumber = 0;
        Dictionary<int, bool> BingoBoardMarked = new Dictionary<int, bool>();

        public Bingo(List<string> lines){
            for(int i = 0; i < lines.Count(); i++){
                var splitted = lines[i].Split(' ');
                var cleanedSplit = new List<int>();
                foreach(var split in splitted){
                    if(string.IsNullOrEmpty(split)){
                        continue;
                    }
                    cleanedSplit.Add(int.Parse(split));
                }
                for(int j = 0; j < cleanedSplit.Count(); j++){
                    NumberBoard[i,j] = cleanedSplit[j];
                    BingoBoardMarked.Add(cleanedSplit[j], false);
                }     
            }

            //PrintBoard();
        }

        public long CalcResult(){
            var sumOfUnmarked = 0;
            foreach(var nums in BingoBoardMarked){
                if(nums.Value == false){
                    sumOfUnmarked += nums.Key;
                }
            }
            return sumOfUnmarked * WinningNumber;
        }

        public bool MarkNumberAndCheck(int toMark){
            if(BingoBoardMarked.ContainsKey(toMark)){
                BingoBoardMarked[toMark] = true;
                for(int i = 0; i < 5; i++){
                    for(int j = 0; j < 5; j++){
                        if(NumberBoard[i,j] == toMark){
                            MarkedBoard[i,j] = true;
                        }
                    }
                }

                if(CheckBoardIfWin()){
                    WinningNumber = toMark;
                    return true;
                }
                return CheckBoardIfWin();
            }
            return false;
        }
        private bool CheckBoardIfWin(){

            for(int i = 0; i < 5; i++){
                var markedinRow = 0;
                for(int j = 0; j < 5; j++){
                    if(MarkedBoard[i,j]){
                        markedinRow++;
                    }
                }
                if(markedinRow == 5){
                    return true;
                }
            }

            for(int j = 0; j < 5; j++){
                var markedColumn = 0;
                for(int i = 0; i < 5; i++){
                    if(MarkedBoard[i,j]){
                        markedColumn++;
                    }
                }

                if(markedColumn == 5){
                    return true;
                }
            }

            return false;
        }

        public void PrintOnlyMarkedNum(){
            for(int i = 0; i < 5; i++){
                for(int j = 0; j < 5; j++){
                    if(MarkedBoard[i,j]){
                        Console.Write(NumberBoard[i,j] + " ");
                    }
                    else{
                        Console.Write("X ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public void PrintBoard(){
            for(int i = 0; i < 5; i++){
                for(int j = 0; j < 5; j++){
                    Console.Write(NumberBoard[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
    public static class Day04{
        
        public static long Part1(){
            bool isFirst = true;
            var listNumbers = new List<int>();
            var listBingoBoards = new List<Bingo>();
            var listBingoLines = new List<string>();

            var listWonBoardsResult = new List<long>();
            foreach (string line in File.ReadLines(@"data/day04.txt"))
            {
                if(isFirst){
                    isFirst = false;
                    var splittedLine = line.Split(',');
                    foreach(string splitted in splittedLine){
                        var parsed = int.Parse(splitted);
                        listNumbers.Add(parsed);
                    }
                    continue;
                }

                if(String.IsNullOrEmpty(line)){
                    if(listBingoLines.Count() != 0){
                        listBingoBoards.Add(new Bingo(listBingoLines));
                        listBingoLines = new List<string>();
                    }                  
                    continue;
                }
                listBingoLines.Add(line);             
            }

            foreach(var num in listNumbers){
                foreach(var board in listBingoBoards){
                    var isWinAndAdd = board.MarkNumberAndCheck(num);
                    //board.PrintOnlyMarkedNum();
                    if(isWinAndAdd){
                        return board.CalcResult();
                    }
                }
            }

            return 99;
        }

        public static long Part2(){
            bool isFirst = true;
            var listNumbers = new List<int>();
            var listBingoBoards = new List<Bingo>();
            var listBingoLines = new List<string>();

            var listWonBoardsResult = new List<long>();
            foreach (string line in File.ReadLines(@"data/day04.txt"))
            {
                if(isFirst){
                    isFirst = false;
                    var splittedLine = line.Split(',');
                    foreach(string splitted in splittedLine){
                        var parsed = int.Parse(splitted);
                        listNumbers.Add(parsed);
                    }
                    continue;
                }

                if(String.IsNullOrEmpty(line)){
                    if(listBingoLines.Count() != 0){
                        listBingoBoards.Add(new Bingo(listBingoLines));
                        listBingoLines = new List<string>();
                    }                  
                    continue;
                }
                listBingoLines.Add(line);             
            }

            foreach(var num in listNumbers){
                foreach(var board in listBingoBoards){
                    var isWinAndAdd = board.MarkNumberAndCheck(num);
                    //board.PrintOnlyMarkedNum();
                    if(isWinAndAdd && !board.HasWonOnce){
                        board.HasWonOnce = true;
                        listWonBoardsResult.Add(board.CalcResult());
                    }
                }
            }

            return listWonBoardsResult.Last();
        }
    }
}