using System;

namespace UnityLesson_CSharp_instantiationExample
{
    internal class Program
    {
        private const bool V = false;

        static void Main(string[] args)
        {

            Orc orc1 = new Orc();

            orc1.name = "상급오크";
            orc1.height = 240.2f;
            orc1.genderChar = '남';
            orc1.isResting = false;
            orc1.age = 140;
            orc1.weight = 200;
            orc1.Jump();
            orc1.smash();

            Orc.typeName = "오크타입";
            Orc.SayTypeName();

            Orc orc2 = new Orc();

            orc2.name = "하급오크";
            orc2.height = 140.4f;
            orc2.genderChar = '여';
            orc2.isResting = true;
            orc2.age = 60;
            orc2.weight = 120;
        }
    }




    public class Orc
       {
        static public string typeName;
        public int age;
        public float height;
        public char genderChar;
        public string name;
        public bool isResting;

        public int weight { get; internal set; }

        internal static void SayTypeName()
        {
            throw new NotImplementedException();
        }

        public void Jump() { Console.WriteLine($"{name} (이)가 점프했다");


      
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

       
        
}

     

        
        





