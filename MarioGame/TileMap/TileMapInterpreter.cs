using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class TileMapInterpreter
    {

        /*
         * X = Blank space
         * 
         * H = Hidden block (hidden)
         * J = Hidden block (non hidden)
         * 
         * Q = Question Block w/ item
         * W = Question Block w/ star
         * E = Question Block w/ coin
         * 
         * B = Brick block (no item)
         * N = Brick block (1 coin)
         * C = Brick block (10 coins)
         * M = Brick block (item)
         * V = Brick block (star)
         * F = Destroyed Block
         * 
         * A = Floor block
         * S = Stair block
         * D = Used block
         * 
         * G = Green Koopa
         * K = Goomba
         * L = Red Koopa
         * 
         * R = Coin
         * T = Flower
         * Y = Super Mushroom
         * I = 1 up Mushroom
         * U = star
         * 
         * P = player
         * 
         */

        public enum Entities
        {
            BLANK,
            HIDDEN_HIDDEN,
            HIDDEN_NONHIDDEN,
            QUESTION_ITEM,
            QUESTION_STAR,
            QUESTION_COIN,
            BRICK_NOITEM,
            BRICK_COIN,
            BRICK_COINS,
            BRICK_ITEM,
            BRICK_STAR,
            DESTROYED,
            FLOOR,
            STAIR,
            USED,
            GREEN_KOOPA,
            RED_KOOPA,
            GOOMBA,
            COIN,
            FLOWER,
            SUPER_MUSHROOM,
            UP_MUSHROOM,
            STAR,
            PLAYER
        }

        private System.IO.StreamReader file;
        private Dictionary<char, Entities> charMap = new Dictionary<char, Entities>();

        //Map chars to Entites

        private string line;
        private object graphics;

        public TileMapInterpreter(string f)
        {
            file = new System.IO.StreamReader(f);

            line = file.ReadLine();

            while(line.Length == 0 || line[0] != '*')
            {
                line = file.ReadLine();
            }

            //Map characters
            charMap.Add('X', Entities.BLANK);
            charMap.Add('H', Entities.HIDDEN_HIDDEN);
            charMap.Add('J', Entities.HIDDEN_NONHIDDEN);
            charMap.Add('Q', Entities.QUESTION_ITEM);
            charMap.Add('W', Entities.QUESTION_STAR);
            charMap.Add('E', Entities.QUESTION_COIN);
            charMap.Add('B', Entities.BRICK_NOITEM);
            charMap.Add('N', Entities.BRICK_COIN);
            charMap.Add('C', Entities.BRICK_COINS);
            charMap.Add('M', Entities.BRICK_ITEM);
            charMap.Add('V', Entities.BRICK_STAR);
            charMap.Add('F', Entities.DESTROYED);
            charMap.Add('A', Entities.FLOOR);
            charMap.Add('S', Entities.STAIR);
            charMap.Add('D', Entities.USED);
            charMap.Add('G', Entities.GREEN_KOOPA);
            charMap.Add('K', Entities.GOOMBA);
            charMap.Add('L', Entities.RED_KOOPA);
            charMap.Add('R', Entities.COIN);
            charMap.Add('T', Entities.FLOWER);
            charMap.Add('Y', Entities.SUPER_MUSHROOM);
            charMap.Add('I', Entities.UP_MUSHROOM);
            charMap.Add('U', Entities.STAR);
            charMap.Add('P', Entities.PLAYER);

        }

        public List<IEntity> LoadLevel(List<BlockContext> blockControllers, List<IEntity>enemies, Grid grid, GraphicsDeviceManager graphics)
        {
            List<TileMapInterpreter.Entities> list = InterpretNextLine();

            List<IEntity> entities = new List<IEntity>();

            int currentHeight = 0;

            while (!AtEOS())
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Entities entity = list[i];

                    switch (entity)
                    {
                        case Entities.BLANK:
                            {
                                break;
                            }
                        case Entities.BRICK_COIN:
                            {
                                IEntity thing = new BlockContext(BlockContext.Blocks.BRICK, new Vector2(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE));
                                entities.Add(thing);
                                grid.Add(thing);
                                blockControllers.Add((BlockContext)thing);
                                break;
                            }
                        case Entities.BRICK_COINS:
                            {
                                IEntity thing = new BlockContext(BlockContext.Blocks.BRICK, new Vector2(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE));
                                entities.Add(thing);
                                grid.Add(thing);
                                blockControllers.Add((BlockContext)thing);
                                break;
                            }
                        case Entities.BRICK_ITEM:
                            {
                                IEntity thing = new BlockContext(BlockContext.Blocks.BRICK, new Vector2(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE));
                                entities.Add(thing);
                                grid.Add(thing);
                                blockControllers.Add((BlockContext)thing);
                                break;
                            }
                        case Entities.BRICK_NOITEM:
                            {
                                IEntity thing = new BlockContext(BlockContext.Blocks.BRICK, new Vector2(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE));
                                entities.Add(thing);
                                grid.Add(thing);
                                blockControllers.Add((BlockContext)thing);
                                break;
                            }
                        case Entities.BRICK_STAR:
                            {
                                IEntity thing = new BlockContext(BlockContext.Blocks.BRICK, new Vector2(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE));
                                entities.Add(thing);
                                grid.Add(thing);
                                blockControllers.Add((BlockContext)thing);
                                break;
                            }
                        case Entities.COIN:
                            {
                                IEntity thing = new Sprites.CoinSprite(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE, CoinType.Static, CoinFrame.FirstFrame);
                                entities.Add(thing);
                                grid.Add(thing);
                                break;
                            }
                        case Entities.DESTROYED:
                            {
                                break;
                            }
                        case Entities.FLOOR:
                            {
                                IEntity thing = new BlockContext(BlockContext.Blocks.FLOOR, new Vector2(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE));
                                entities.Add(thing);
                                grid.Add(thing);
                                blockControllers.Add((BlockContext)thing);
                                break;
                            }
                        case Entities.FLOWER:
                            {
                                IEntity thing = new Sprites.FireFlowerSprite(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE, FireFlowerFrame.FirstFrame);
                                entities.Add(thing);
                                grid.Add(thing);
                                break;
                            }
                        case Entities.GOOMBA:
                            {
                                IEntity thing = new Sprites.RedGoombaSprite(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE, false);
                                entities.Add(thing);
                                grid.Add(thing);
                                enemies.Add(thing);
                                break;
                            }
                        case Entities.GREEN_KOOPA:
                            {
                                IEntity thing = new Sprites.GreenKoopaSprite(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE);
                                entities.Add(thing);
                                grid.Add(thing);
                                enemies.Add(thing);
                                break;
                            }
                        case Entities.HIDDEN_HIDDEN:
                            {
                                IEntity thing = new BlockContext(BlockContext.Blocks.HIDDEN, new Vector2(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE));
                                entities.Add(thing);
                                grid.Add(thing);
                                blockControllers.Add((BlockContext)thing);
                                break;
                            }
                        case Entities.HIDDEN_NONHIDDEN:
                            {
                                IEntity thing = new BlockContext(BlockContext.Blocks.BRICK, new Vector2(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE));
                                entities.Add(thing);
                                grid.Add(thing);
                                blockControllers.Add((BlockContext)thing);
                                break;
                            }
                        case Entities.SUPER_MUSHROOM:
                            {
                                IEntity thing = new Sprites.MushroomSprite(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE, MushroomType.Super);
                                entities.Add(thing);
                                grid.Add(thing);
                                break;
                            }
                        case Entities.UP_MUSHROOM:
                            {
                                IEntity thing = new Sprites.MushroomSprite(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE, MushroomType._1Up);
                                entities.Add(thing);
                                grid.Add(thing);
                                break;
                            }
                        case Entities.PLAYER:
                            {
                                IEntity thing = new PlayerContext(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, new Vector2(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE));
                                entities.Add(thing);
                                grid.Add(thing);
                                break;
                            }
                        case Entities.QUESTION_COIN:
                            {
                                IEntity thing = new BlockContext(BlockContext.Blocks.QUESTION, new Vector2(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE));
                                entities.Add(thing);
                                grid.Add(thing);
                                blockControllers.Add((BlockContext)thing);
                                break;
                            }
                        case Entities.QUESTION_ITEM:
                            {
                                IEntity thing = new BlockContext(BlockContext.Blocks.QUESTION, new Vector2(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE));
                                entities.Add(thing);
                                grid.Add(thing);
                                blockControllers.Add((BlockContext)thing);
                                break;
                            }
                        case Entities.QUESTION_STAR:
                            {
                                IEntity thing = new BlockContext(BlockContext.Blocks.QUESTION, new Vector2(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE));
                                entities.Add(thing);
                                grid.Add(thing);
                                blockControllers.Add((BlockContext)thing);
                                break;
                            }
                        case Entities.RED_KOOPA:
                            {
                                IEntity thing = new Sprites.RedKoopaSprite(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE);
                                entities.Add(thing);
                                grid.Add(thing);
                                enemies.Add(thing);
                                break;
                            }
                        case Entities.STAIR:
                            {
                                IEntity thing = new BlockContext(BlockContext.Blocks.STAIR, new Vector2(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE));
                                entities.Add(thing);
                                grid.Add(thing);
                                blockControllers.Add((BlockContext)thing);
                                break;
                            }
                        case Entities.STAR:
                            {
                                IEntity thing = new Sprites.StarmanSprite(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE, StarmanFrame.FirstFrame);
                                entities.Add(thing);
                                grid.Add(thing);
                                break;
                            }
                        case Entities.USED:
                            {
                                IEntity thing = new BlockContext(BlockContext.Blocks.USED, new Vector2(i * Grid.TILE_SIDE, currentHeight * Grid.TILE_SIDE));
                                entities.Add(thing);
                                grid.Add(thing);
                                blockControllers.Add((BlockContext)thing);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }

                }
                list = InterpretNextLine();
                currentHeight++;
            }

            return entities;
        }


        public List<Entities> InterpretNextLine()
        {
            List<Entities> list = new List<Entities>();

            if (!file.EndOfStream)
            {
                line = file.ReadLine();
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != ' ' && line[i] != '\n')
                    {
                        list.Add(charMap[line[i]]);
                    }
                }
            }


            return list;
        }

        public bool AtEOS()
        {
            return file.EndOfStream;
        }


    }
}
