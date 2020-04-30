using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public interface IActionState
    {
        void Idle();
        void Running();
        void Crouching();
        void Falling();
        void Jumping();


    }
}
