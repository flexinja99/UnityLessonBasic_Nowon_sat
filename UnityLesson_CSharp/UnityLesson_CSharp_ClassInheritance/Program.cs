using System;
using System.Collections.Generic;

namespace UnityLesson_CSharp_ClassInheritance
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Creature creature = new Creature();

            for (int i = 0; i < 10; i++)
            {
                creature.Breath();
            }
            Console.WriteLine(creature.age);

            Human human = new Human();
            for (int i = 0; i < 10; i++)
            {
                human.Breath();
            }
            Console.WriteLine($"age : {human.age},height : {human.height}, wehght : {human.wegiht}");

            Dog dog = new Dog();
            dog.tailLength = 1f;

            // 각 인종 20명, 두발로 걷기
            //================================================
            //case : 각 인종에 대한 리스트 별개로 생성하기
            List<Whiteman> whiteMen = new List<Whiteman>();
            List<Blackman> blackman = new List<Blackman>();
            List<Yellowman> yellowman = new List<Yellowman>();
            for (int i = 0; i < 20; i++)
            {
                Whiteman tmpMan = new Whiteman();
                whiteMen.Add(tmpMan);
            }
            for (int i = 0; i < 20; i++)
            {
                Blackman tmpMan = new Blackman();
                blackman.Add(tmpMan);
            }
            for (int i = 0; i < 20; i++)
            {
                Yellowman tmpMan = new Yellowman();
                yellowman.Add(tmpMan);
            }
            foreach (var item in whiteMen)
            {
                item.TwoLeggedWalk();
            }
            foreach (var item in blackman)
            {
                item.TwoLeggedWalk();
            }
            foreach (var item in yellowman)
            {
                item.TwoLeggedWalk();
            }

            //WhiteMan 객체화 -> Human 으로 인스턴스화
            //Human 변수에 있는 Breath 를 호출하면 WhiteMan에 있는 breath 가 호출됨
            //
            // 자식 객체를 부모 클래스타입으로 인스터스화 시키고
            // 해당 변수의 virtual 맴버 함수가 호출된다.
            // 자식 객체의 override된 함수가 호출된다.
            Human testHuman = new Whiteman();
            testHuman.Breath();
            Console.WriteLine($"{testHuman.height}{testHuman.wegiht}");

            // case : 위 성질을 이용하요 부모클래스(human)리스트 하나만 생성
            List<Human> humen  = new List<Human>();
            for (int i = 0; i < 20; i++)
            {
                Human tmpHuman1 = new Whiteman();
                humen.Add(tmpHuman1);
                Human tmpHuman2 = new Blackman();
                humen.Add(tmpHuman2);
                Human tmpHuman3 = new Yellowman();
                humen.Add(tmpHuman3);
            }
            foreach (var item in humen)
            {
                item.TwoLeggedWalk();
            }
            
            // 인터페이스 인스턴스화 예시
            ITwoLeggedWalker walker = new Whiteman();
            walker.TwoLeggedWalk();
            //case : 인터페이스로 인스턴스화 시키는 방법
            List<ITwoLeggedWalker> walkers = new List<ITwoLeggedWalker>();
            for (int i = 0;i < 20;i++)
            {
                ITwoLeggedWalker tmpWalker1 = new Whiteman();
                walkers.Add(tmpWalker1);
                ITwoLeggedWalker tmpwalker2 = new Blackman();
                walkers.Add(tmpwalker2);
                ITwoLeggedWalker tmpWalker3 = new Yellowman();
                walkers.Add(tmpWalker3);

            }
            foreach (var item in walkers)
            {
                item.TwoLeggedWalk();
            }
        }
    }
}
