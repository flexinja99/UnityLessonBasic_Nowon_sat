using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_ClassInheritance
{
    internal class Whiteman : Human
    {
        public override void Breath()
        {
            base.Breath();

            age++;
            height += 0.0003f;
            wegiht += 0.00035f;
        }



    }
}
