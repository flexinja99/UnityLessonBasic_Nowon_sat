using System;

namespace UnityLesson_CSharp_ForLoop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //for문
            //기본형태
            /* for(인덱스용 변수 선언 및 초기화; for문을 실행할 조건; 루프가 한번 실행할 문장)
            {
               반복수행시 실행할 내용
            }*/


            string[] arr_PersonName = new string[3];
            arr_PersonName[0] = "감아무개";
            arr_PersonName[1] = "이아무개";
            arr_PersonName[2] = "박아무개";

            int length = arr_PersonName.Length;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(arr_PersonName[i]);
            }

            //김아무개만 출력을 하고싶다. 김아무개의 인덱스 규칙은 : 3n
            for (int i = 0; i < length; i++)
                if (arr_PersonName[i] == "김아무개")
                {
                    Console.WriteLine(arr_PersonName[i]);
                }
            // 인텍스 규칙을 활횽한 예시
            for (int i = 0; i < length; i += 3)
            {
                Console.WriteLine(arr_PersonName[i]);

            }
          
            


        }
    }
}
