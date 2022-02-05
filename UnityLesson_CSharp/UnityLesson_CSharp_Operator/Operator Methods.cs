using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_Operator
{
    static public class Operator_Methods
    {
        public static bool AㅣB { get; private set; }

        // 산술 연산
        //===================================================================
        // 더하기
        static public int Sum(int a, int b)
        {
            return a + b;
        }


        // 논리 연산
        //================================================================

        static public bool LogicOr(bool A, bool B)
        {
            return AㅣB;


        }

        

        static public bool LogicAnd(bool A, bool B)
        {
            return A & B;
        }

        static public bool LogicXor(bool A, bool B)
        { 
            return A ^ B;
        }

       
        
           
        
        // 증가 연산
        //==================================================================
        // 증가 연산자

        static public int Increase(int a)
        {
            // 증감연산자는 해당 문장이 끝난 후에 1증가
            int tmpValue = a;
            tmpValue++;  
            return a++;
        }

        // 감소연산자

        static public int Decrease(int a)
        {
            a--;
            return a;

        }
        // 관계연산
        //===============================
        // 같은지 비교

        static public bool IsSame(int a, int b)
        { 
            return a == b;
        }
        // 다른지 비교
         
        static public bool IsDifferent(int a, int b)
        { 
            return a != b;
        }
        // 큰지 비교

        static public bool IsBigger(int a, int b)
        {
            return a > b;
        }
        // 크거나 같은지 비교
        static public bool IsBiggerOrSame(int a, int b)
        {
            return a >= b;
        }
        // 작은지 비교
        static public bool IsSmaller(int a, int b)
        { 
            return a < b;
        }
        //작거나 같은지  비교

        static public bool IsSmallerOrSame(int a, int b)
        { 
            return a <= b;
        }
        // 논리 연산
        //=========================================
        // or
        static public bool LogicOR(bool A, bool B)
        {
            return A | B;
        
        }

        static public bool LogicAND(bool A, bool B)
        { 
            return A & B;
        
        }

        static public bool LogicXOR(bool A, bool B)
        { 
            return A ^ B;
        }

        static public bool LogicNOT(bool A, bool B)
        {
            return A != B;
        }
        // 조건부논리 연산
        //===============================
        // or

        static public bool ConditionalLogicOR(bool A, bool B)
        { 
            return A | B;
        }
        // and

        static public bool ConditionalLogicAND(bool A, bool B)
        { 
            return A && B;
        }

        // 비트연산
        //=======================================
        // or
        static public bool BitLogicOR(bool A, bool B)
        { 
            return A | B;
        }
        // and
        static public int BitLogicOR(int A, int B)
        { 
            return A & B;
        }
        // xor
        static public bool BitLogicXOR(bool A, bool B)
        {
            return A ^ B;
        }
        // not
        static public int BitLogicNOT(int A)
        { 
            return ~A;
        }
        // shift - left
        static public int BitShiftLeft(int a,int howManyBitsyouWantToShift )
        {
            return a << howManyBitsyouWantToShift; 
        }  
        // shift -  right
        static public int BitShiftRight(int a, int howManyBitsyouWantToShift )
        { 
            return a >> howManyBitsyouWantToShift;
        }


























        






    }
}