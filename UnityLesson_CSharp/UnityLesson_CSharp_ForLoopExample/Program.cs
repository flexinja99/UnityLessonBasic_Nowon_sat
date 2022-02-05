using System;

// Orc 객체를 10마리 만들고 
// Orc 들의 인스턴스는 Orc타입 배열에 넣어준다
//각 오크의 이름은 "오크0" ,오크 1
// 각오크에게 isReseting 멤버변수값은 랜덤으로 넣어준다
//각 오크가 쉬고있는지 확인해서 쉬고있다면 점프하도록 한다.
namespace UnityLesson_CSharp_ForLoopExample
{
    internal class Program

    { 
      
        static void Main(string[] args)
        {
            Orc[] arr_Orc = new Orc[10];
            int length = arr_Orc.Length;
            for (int i = 0; i < length; i++) 
            {
              arr_Orc[i] = new Orc();
                arr_Orc[i].name = $"오크{i}";
            }

          
             // isResating 랜덤 세팅
            for (int i = 0; i < length; i++)
            {
                if (arr_Orc[i].isResting)
                {
                    arr_Orc[i].Jump();
                }
            }


        }
        static private bool GetRandomBool()
        {
            Random random = new Random();//Random클래스 인스턴스화
           int randommInt= random.Next(0,3); // minValue ~ maxValue - 1
            bool randomBool= Convert.ToBoolean(randommInt);
            return randomBool;
        }
    }
public class Orc
{
    static public string typeName;
    public int age;
    public float height;
    public char genderChar;
    public string name;

    public bool isResting { get; internal set; }

    internal static void SayTypeName()
    {
        throw new NotImplementedException();
    }

    internal void jump()
    {
        throw new NotImplementedException();
    }

        internal void Jump()
        {
            throw new NotImplementedException();
        }

        internal void smash()
    {
        throw new NotImplementedException();
    }
}

    internal static void SayTypeName()
    {
        throw new NotImplementedException();
    }

    public void Jump()
    {
        Console.WriteLine($"{name} (이)가 점프했다");



    }

    private void Smash()
    {
        Console.WriteLine($"{name} (이)가 휘둘렀다");

    }

    internal void smash()
    {
        throw new NotImplementedException();
    }
}
         
         
    
