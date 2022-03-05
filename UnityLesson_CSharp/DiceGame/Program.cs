using System;
using System.Collections.Generic;

namespace DiceGame
{
    internal class Program
    {
        static private int totalTile = 20; //  칸의 개수
        static private int currentstarPoint = 0; // 현재 샛별점수
        static private int totalDiceNumber = 20; // 총 주사위 갯수
        static private int currentTileIndex = 0; // 현재 칸의 인덱스
        static private Random random;
        private static int previousTileIndex;

        static void Main(string[] args)
        {
            int currentTileIndex = 0; //현재 칸의 인덱스

            TileMap map = new TileMap();
            map.MapSetup(totalTile);//맵 생성

            int currentDiceNum = totalDiceNumber;
            //주사위 게임 시작
            while (currentTileIndex > 0)
            { 
                int diceValue = RollADice(); // 주사위 굴리기
                currentDiceNum--; //주사위 굴렸으니까 남은 주사위 갯수 차감
                currentTileIndex += diceValue;// 플레이어 주사위 눈금만큼 전진

                // 현재칸이 최대칸을 넘어가버렸을때
                if(currentTileIndex > totalTile - 1)
                {
                    currentTileIndex-=(totalTile-1);
                }
                Console.WriteLine($"현재 플레이어 위치 : {currentTileIndex}");
                // 현재칸의 정보를 받아옴
                TileInfo info = map.mapInfo.GetValueOrDefault(currentTileIndex);
                if (info == null)
                {
                    Console.WriteLine($" Failed to get tilleingo. num : {currentTileIndex}");
                    return;
                }
                info.TileEvent(); //칸의 이벤트호출

                // 플래이어가 샛별칸을 지났는지 체크
                if(currentTileIndex/5 > previousTileIndex / 5)
                {
                    int passedStarTileIndex = currentTileIndex / 5 * 5;
                    TileInfo_Star tileInfo_Star = map.mapInfo.GetValueOrDefault(passedStarTileIndex) as TileInfo_Star;  
                    if(tileInfo_Star != null)
                    {
                       currentstarPoint += tileInfo_Star.starValue;
                    }
                }

                previousTileIndex = currentTileIndex;
                Console.WriteLine($"현제 샛별 점수 : {currentstarPoint}");
                Console.WriteLine($"남은 주사위 갯수 : {currentDiceNum}");

            }
            Console.WriteLine($"Game Finished ! You got total {currentstarPoint} stars");

            static int RollADice()
            {
                string userInput = "Default";
                while (userInput != "")
                {
                    Console.WriteLine("Roll A Dice ! Press Enter");
                    userInput = Console.ReadLine();

                }

                random = new Random();
                int diceValue = random.Next(1, 7);
                Console.WriteLine($"DiceValue : {diceValue}");
                DisplayDice(diceValue); 
                return diceValue;
            }
        }
        static void DisplayDice(int diceValue)
        {

        }

          
        

        
        
           
        
    }
}
