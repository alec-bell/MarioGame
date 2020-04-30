using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    interface IController
    {
        List<ICommand> GetCommand(int playerIndex);
        void Update();
    }
}
