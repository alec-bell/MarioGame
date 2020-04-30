using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public interface IPowerState
    {
        void Mushroom();
        void Damage();
        void Flower();
        void Star();
        void Transition();
        void ChangeToSmallMario();
        void ChangeToSuperMario();

        void ChangeToFireMario();
    }
}
