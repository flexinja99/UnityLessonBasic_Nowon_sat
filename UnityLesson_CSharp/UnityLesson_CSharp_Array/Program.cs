using System;

namespace UnityLesson_CSharp_Array
{
    internal class Program
    {


        // array
        // 형태: 자료형[]
        //자료형이 정적으로 나열되어있는 셩태
        //크기를 한번 정해놓으면 바꿀수없다.
        static int[] arr_Testint = new int[5];
        static float[] arr_Testfloat = new float[3];
        static float[] arr_Testfloat2 = { 1, 0f, 2, 0f, 3, 0f, 4, 0f };
        static string[] arr_TestString = new string[3];

        static void Main(string[] args)
        {
            arr_Testint[0] = 5;
            arr_Testint[1] = 4;
            arr_Testint[2] = 3;
            arr_Testint[3] = 2;
            arr_Testint[4] = 1;

            Console.WriteLine(arr_Testint[0]);
            Console.WriteLine(arr_Testint[1]);
            Console.WriteLine(arr_Testint[2]);
            Console.WriteLine(arr_Testint[3]);
            Console.WriteLine(arr_Testint[4]);

            arr_Testfloat[0] = 10;
            arr_Testfloat[1] = 9;
            arr_Testfloat[2] = 8;
            
            Console.WriteLine(arr_Testfloat[0]);
            Console.WriteLine(arr_Testfloat[1]);
            Console.WriteLine(arr_Testfloat[2]);

            arr_TestString[0] = "감아무게";
            arr_TestString[1] = "박아무개";
            arr_TestString[2] = "이아무개";
            Console.WriteLine(arr_TestString[0]);
            Console.WriteLine(arr_TestString[1]);
            Console.WriteLine(arr_TestString[2]);


        }
    }
}

    

