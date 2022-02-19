using System;
 // switch -case 에 적합한 형태 ,
 //각 요소들이 동시에 일어나는 경우가 없는 상황에 적합한 형태
 // 특히 FSM(Finite State Machine).
 // 

enum e_PlayerState
{
    ldle, // ...0000000
    Attack, // ...0000001
    Jump, // ...00000010
    Walk, //...00000011
    Run, // ... 0000100
    Dash, // ...0000101
    Home, // ... 00000110
    DashAttack, //...000000111
}  

// 각 요소들이 동시에 일어나는 경우가 없는 상황에 적합한 형태
[Flags] // ToString()속성을 참조할때 중복되는 모든 요소들에 대해 표현이 가능(문자열로 형변환이 가능)
enum e_PlayerStateFlags
{
    ldle = 0,            // ...0000000
    Attack = 1 << 0,     // ...0000001
    Jump = 1 << 1,       // ...0000010
    Walk = 1 << 2,       // ...0000100
    Run = 1 << 3,        // ...0001000
    Dash = 1 << 4,       // ...0010000
    Home = 1 << 5,       // ...0100000
    JumpAttack = Jump | Attack, //000100001
}
namespace UnityLesson_CSharp_EnumAndSwitchCase
{
    internal class Program
        
        //Casting 캐스팅
        //비트 정보 그대로 들고외서 타입만 변경시킴
    {
        static e_PlayerState createMotion = (e_PlayerState)11;
        static void Main(string[] args)
        {
            // Enum-bit
            e_PlayerStateFlags flags = e_PlayerStateFlags.Jump | e_PlayerStateFlags.Attack;
            Console.WriteLine(flags);

            Warrior warrior = new Warrior(); // 각 요소들이 동시에 일어나는 경우가 없는 상황에 적합한 형태
             // ToString()속성을 참조할때 중복되는 모든 요소들에 대해 표현이 가능(문자열로 형변환이 가능)
            Console.WriteLine("셍성할 전사의 이름을 입력하세요");
            warrior.name = Console.ReadLine();
            if (createMotion == e_PlayerState.ldle)
            {
                // do nothing
            }
            else if (createMotion == e_PlayerState.Attack)
            {
                warrior.Attack();
            }
            else if (createMotion == e_PlayerState.Jump)
            {
                warrior.Jump();
            }
            else if (createMotion == e_PlayerState.Run)
            {
                warrior.Run();
            }
            else if (createMotion == e_PlayerState.Walk)
            {
                warrior.Walk();
            }
            else if (createMotion == e_PlayerState.Dash)
            {
                warrior.Dash();
            }
            else if (createMotion != e_PlayerState.Home)
            {
                warrior.Home();
            }
            else
            {
                Console.WriteLine("어 상태가 이상한데");
            }

            // switch - case 형태
            /* switch (경우의 수 매개 변수)
             {
                 case 경우:
                       이경우에 실행할 내용
                 case 경우2:
                        이 경우에 실행할 내용
                     break;
                 default:
             }*/


            // Switch _case 분기
            switch (createMotion)
            {
                case e_PlayerState.ldle:
                    // do nothing
                    break;
                case e_PlayerState.Attack:
                    warrior.Attack();
                    break;
                case e_PlayerState.Jump:
                    warrior.Jump();
                    break;
                case e_PlayerState.Walk:
                    warrior.Walk();
                    break;
                case e_PlayerState.Run:
                    warrior.Run();
                    break;
                case e_PlayerState.Dash:
                    warrior.Dash();
                    break;
                case e_PlayerState.Home:
                    warrior.Home();
                    break;
                default:
                    Console.WriteLine("전사는 그런거 할줄 몰라요");
                    break;
            }


            // 전사에게 동작 명령하기
            Console.WriteLine("전사에게 명령을 내려 주세요");
            string motionInput = Console.ReadLine();
            e_PlayerState motion;
            bool isParsed = Enum.TryParse(motionInput, out motion);
            if (isParsed) 

            switch (motion)
            {
                case e_PlayerState.ldle:
                    // do nothing
                    break;
                case e_PlayerState.Attack:
                    warrior.Attack();
                    break;
                case e_PlayerState.Jump:
                    warrior.Jump();
                    break;
                case e_PlayerState.Walk:
                    warrior.Walk();
                    break;
                case e_PlayerState.Run:
                    warrior.Run();
                    break;
                case e_PlayerState.Dash:
                    warrior.Dash();
                    break;
                case e_PlayerState.Home:
                    warrior.Home();
                    break;
                default:
                    Console.WriteLine("전사는 그런거 할줄 몰라요");
                    break;
            }




        }        
            

        
        public class Warrior
        {
            public string name;

            public void Attack()
            {
                Console.WriteLine($"{name} (이)가 공격함");
            }
            
            public void Jump()
            {
                Console.WriteLine($"{name} (이)가 뜀");

            }

            public void Run()
            {
                Console.WriteLine($"{name} (이)가 달림");

            }

            public void Walk()
            {
                Console.WriteLine($"{name} (이)가 걸음");
            }

            public void Dash()
            {
                Console.WriteLine($"{name} (이)가 대쉬");
            }

            public void Home()
            {
                Console.WriteLine($"{name} (이)가 집");
            }
        }
    }

}
