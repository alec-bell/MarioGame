using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Commands
{
    class BoundingCommand : ICommand
    {
        PlayerContext player;
        List<IEntity> entities;
        public BoundingCommand(PlayerContext player,List<IEntity> entities)
        {
            this.player = player;
            this.entities = entities;
        }

        public void Execute()
        {
            foreach (IEntity e in entities)
            {
                if(e.IsBounded == false)
                {
                   e.IsBounded = true;
                }
                else
                {
                    e.IsBounded = false;
                }
               
            }
        }
    }
}
