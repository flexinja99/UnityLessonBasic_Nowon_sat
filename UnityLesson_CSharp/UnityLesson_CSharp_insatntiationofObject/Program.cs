using System;

namespace UnityLesson_CSharp_insatntiationofObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Person person1 = new Person();
            //점(.) 연산자 - 맴버에 접근하는 연산지
            person1.age = 40;
            person1.height = 223.4f;
            person1.isResting = true;
            person1.genderChar = '여';
            person1.name = "김아무게";
            // 객체의 맴버 함수 호출
             person1.SayAll_info();


           Person person2 = new Person();
        }
    }
}
 public class Person
{
   public int age;
   public float height;
   public  char genderChar;
   public  string name;

    public bool isResting { get; internal set; }

    void Sayll_info()
    {
        SayAge();
        SayHeight();
        SayGenderChar();
        SayName();
    }
   

    void SayAge()
    {
        Console.WriteLine(age);// WriteLine 는 함수 콘솔창에 출력
        Console.WriteLine("S {name} 의 나이 : {age}");  

    }

    void SayHeight()
    {
        Console.WriteLine(height);
        Console.WriteLine("S {name} 의 키 : {hight}");

    }

    void SayGenderChar()
    {
        Console.WriteLine(genderChar);
        Console.WriteLine("S {name} 의 성별 : {genderChar}");
    }

    void SayName()
    {
        Console.WriteLine(name);
        Console.WriteLine("S {name} 의 이름 : {Name}");

    }

    void SayIsResting()
    { 
        Console.WriteLine(isResting);
        Console.WriteLine("S {name} 는 쉬고있나? : {isResting}");

      void SayAll_info()
    {
        throw new NotImplementedException();
    }
}

    internal void SayAll_info()
    {
        throw new NotImplementedException();
    }
}
