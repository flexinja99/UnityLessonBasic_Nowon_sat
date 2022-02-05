using System;

namespace UnityLesson_CSharp_StaticExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Orc orc1= new Orc();

            orc1.name = "오크";
            orc1.height = 240.0f;
            orc1.genderChar = '남';
            orc1.isResting = true;
            orc1.age = 30;

            orc1.jump();
            orc1.smash();

            Orc. typeName = "오크타입";
            Orc.SayTypeName();

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

        internal void smash()
        {
            throw new NotImplementedException();
        }
    }
    private void sayTypeName;

    public  void SayTypeName()
        {
            Console.WriteLine($" {name} (이)가 점프했다");
        }

        public void smash()
        {
            Console.WriteLine($" {name} (이)가 휘둘렀다");
        }
         
         
    }
    public class Person
    {
        public int age;
        public float height;
        public char genderChar;
        public string name;

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
            Console.WriteLine($"{name} 의 나이 : {age}");

        }

        void SayHeight()
        {
            Console.WriteLine(height);
            Console.WriteLine($"{name} 의 키 : {height}");

        }

        void SayGenderChar()
        {
            Console.WriteLine(genderChar);
            Console.WriteLine($"{name} 의 성별 : {genderChar}");
        }

        void SayName()
        {
            Console.WriteLine(name);
            Console.WriteLine($"{name} 의 이름 :{name}");

        }

        void SayIsResting()
        {
            Console.WriteLine(isResting);
            Console.WriteLine($"{name} 는 쉬고있나? : {isResting}");

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
} 