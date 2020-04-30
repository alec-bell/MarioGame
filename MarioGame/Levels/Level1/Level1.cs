using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static MarioGame.Grid;

namespace MarioGame.Levels
{
    public class Level1 : ILevel
    { 
        private const int LEVEL_TILES_WIDTH = 41;
        private const int LEVEL_TILES_HEIGHT = 26;

        public Grid grid;
        TileMapInterpreter interpreter;
        
        IEntity player;
        public PlayerContext playerController;

        public List<IEntity> entities;
        List<BlockContext> blockControllers = new List<BlockContext>();
        List<IEntity> enemies = new List<IEntity>();

        GraphicsDeviceManager graphics;


        public Level1(GraphicsDeviceManager graphics)
        {
            grid = new Grid(LEVEL_TILES_WIDTH * Grid.TILE_SIDE, LEVEL_TILES_HEIGHT * Grid.TILE_SIDE);
            //interpreter = new TileMapInterpreter("../../../Level1-1.txt");
            interpreter = new TileMapInterpreter("C:/Users/dennis/source/repos/1G3B/Sprint0/Sprint0/TileMap/Level1-1.txt");
            this.graphics = graphics;
        }

        public void Remove(IEntity entity)
        {
            entities.Remove(entity);
            grid.Remove(entity);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(IEntity entity in entities)
            {
                if (!entity.Equals(player))
                {
                    entity.Draw(spriteBatch);
                }
            }

            playerController.Draw(spriteBatch);
        }

        public void Initialize()
        {
            entities = interpreter.LoadLevel(blockControllers, enemies, grid, graphics);

            foreach(IEntity entity in entities)
            {
                if (entity.EntityType.Equals(TileMapInterpreter.Entities.PLAYER))
                {
                    player = entity;
                    playerController = (PlayerContext)player;
                }
            }
        }

        public void LoadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
            Elements e = grid.ElementsAt(0,0);
            HashSet<IEntity> entitys = e.getEntityList();
            if(entitys.Count > 0)
            {
                IEntity ex = entitys.ElementAt(0);
                //Console.WriteLine(ex.Location);
            }
            

            foreach (IEntity entity in entities)
            {
                if (entity.Velocity.X != 0 || entity.Velocity.Y != 0)
                {
                    grid.Remove(entity);
                    grid.Add(entity);

                }
                entity.Update(gameTime);
            }
        }

        public PlayerContext getPlayerController()
        {
            return playerController;
        }

        public void TestMarioLocation()
        {

            bool atLeastOne = false;

            for(int i = 0; i<LEVEL_TILES_WIDTH; i++)
            {
                for(int j = 0; j<LEVEL_TILES_HEIGHT; j++)
                {
                    Elements elements = grid.ElementsAt(i, j);
                    HashSet<IEntity> list = elements.getEntityList();
                    if (list.Count > 1)
                    {
                        Console.WriteLine(i + " " + j);
                        atLeastOne = true;
                    }
                }
            }

            if (!atLeastOne)
            {
                Console.WriteLine("No tiles with mulitple entities");
            }
        }
    }
}
