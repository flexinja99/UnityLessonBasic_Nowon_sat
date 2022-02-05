using System;

namespace UnityLesson_CSharp_StaticExample
{
    internal class orc1
    {
        public static int age { get; internal set; }
        public static bool isResting { get; internal set; }
        public static char genderChar { get; internal set; }
        public static float height { get; internal set; }
        public static string name { get; internal set; }

        internal static void jump()
        {
            throw new NotImplementedException();
        }

        internal static void smash()
        {
            throw new NotImplementedException();
        }
    }
}