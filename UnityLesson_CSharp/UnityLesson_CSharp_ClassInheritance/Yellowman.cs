using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_ClassInheritance
{
    internal class Yellowman : Human
    {
        public override void Breath()
        {
            base.Breath();
            height += 0.0003f;
            wegiht += 0.0003f;
        }
    }
}
