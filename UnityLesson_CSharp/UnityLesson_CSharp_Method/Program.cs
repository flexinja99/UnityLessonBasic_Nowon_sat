using System;

namespace UnityLesson_CSharp_Method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintHelloWorld();
            PrintSomething("fjkagnalsgmalsgmlagmalg"); // 함수 호출에서 소괄호 안 내용은 매개변수(parament)
            bool tmpIsFinished = false;
            tmpIsFinished= PrintSomethingAndReturnIsFinshed("fafasffafagg");
            Console.WriteLine(tmpIsFinished);
        }

        // 인자X, 반환X
        static void PrintHelloWorld()
        {
            Console.WriteLine("Hello World!");
        }
        // 인자O, 반환X
        static void PrintSomething(string something) // 함수 정의에서 소괄호 안 내용은 인자 (Argument)
        {
            Console.WriteLine(something);
        }
        // 인자O , 반환 O
        static bool PrintSomethingAndReturnIsFinshed(string something)
        {
            bool isFinished = false; // 지역 변수 ( 이 함수 안에서만 연산을 위해 사용 )
            Console.WriteLine(something);
            isFinished = true;
            return isFinished;
        }
        /*반환형 함수이름(인자자료형 인자이름, 인자자료형 인자이름 ..)
        {
            함수이름 연산 내용

            return 반환할 내용
}
        }*/
    }
}    