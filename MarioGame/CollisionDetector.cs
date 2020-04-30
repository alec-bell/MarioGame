
using MarioGame.Levels;
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class CollisionDetector
    {
        private Level1 level;
        private List<IEntity> entities;

        public CollisionDetector(List<IEntity> entities, Level1 level)
        {
            this.entities = entities;
            this.level = level;
        }

        public void Update()
        {
            List<Collision> collisions = GetCollisions(GetCollisionTiles(entities));

            while (collisions.Count != 0)
            {
                collisions.Sort();
                Collision collision = collisions.First();

                // Respond to collision
                EntityCollisionHandler handler = new EntityCollisionHandler(level);
                handler.HandleCollision(collision, level);

                collisions = GetCollisions(GetCollisionTiles(level.entities));
            }
        }

        public bool IsTargetInRange(IEntity entity, IEntity other)
        {
            int radius = 50;
            Rectangle rect = Rectangle.Empty;
            rect.X = entity.Boundary.X - radius;
            rect.Y = entity.Boundary.Y - radius;
            rect.Width = entity.Boundary.Width + radius * 2;
            rect.Height = entity.Boundary.Height + radius * 2;
            return rect.Contains(other.Boundary);
        }

        //We want to simulate the frames of where an entity is going
        //so that if mario is moving at a horizontal velocity of 40 that it triggers that he hit something
        //instead of allowing him to move through
        public List<CollisionStats> GetCollisionTiles(List<IEntity> ent)
        {
            //if something is moving really fast this number can be raised to generate more frames per second
            //ideally we'll eventually want to make the simulated frames correspond to the speed of the entity
            int simulatedFrames = 10;
            List<CollisionStats> collisionTiles = new List<CollisionStats>();
            foreach (IEntity entity in ent) {
                CollisionStats colStat = new CollisionStats();
                colStat.entity = entity;
                colStat.frames = new List<TimeFrame>();

                TimeFrame frame = new TimeFrame();
                frame.time = 0;
                frame.entityRectangle = new FloatRectangle(entity.Boundary);
                colStat.frames.Add(frame);

                Vector2 loc = entity.Location;
                Vector2 vel = entity.Velocity;

                //we only want to generate frames for the things we know are going to move
                //so for now none of these things are going to "move"
                //in the future we might want to these to change for certain things like a mushroom that runs away from you
                //or a block that hits the entity above it

                if (!(colStat.entity is BlockContext|| colStat.entity is MushroomSprite || colStat.entity is FireFlowerSprite || colStat.entity is CoinSprite || colStat.entity is StarmanSprite))
                {
                    for (int i = 0; i < simulatedFrames; i++)
                    {
                        float x = vel.X * ((i + 1) / 60f);
                        float y = vel.Y * ((i + 1) / 60f);
                        float width = entity.WidthHeight.X;
                        float height = entity.WidthHeight.Y;

                        TimeFrame simulatedFrame = new TimeFrame();
                        simulatedFrame.entityRectangle = new FloatRectangle((float)Math.Floor(loc.X + x), (float)Math.Floor(loc.Y + y), width, height);
                        simulatedFrame.time = i;

                        colStat.frames.Add(simulatedFrame);
                    }
                }
                collisionTiles.Add(colStat);
            }

            return collisionTiles;
        }

        public List<Collision> GetCollisions(List<CollisionStats> collisionTiles)
        {
            List<Collision> collisions = new List<Collision>();
            foreach(CollisionStats first in collisionTiles)
            {
                foreach(CollisionStats second in collisionTiles)
                {
                    if (!first.entity.Equals(second.entity) && IsTargetInRange(first.entity, second.entity))
                    {
                        foreach (TimeFrame firstFrame in first.frames)
                        {
                            foreach (TimeFrame secondFrame in second.frames)
                            {
                                if (FloatRectangle.Intersects(firstFrame.entityRectangle, secondFrame.entityRectangle))
                                {
                                    if (firstFrame.time == secondFrame.time)
                                    {
                                        Collision c = new Collision();
                                        c.entity1 = first.entity;
                                        c.entity2 = second.entity;
                                        c.intersection = FloatRectangle.Intersect(firstFrame.entityRectangle, secondFrame.entityRectangle);
                                        c.frame = firstFrame;

                                        if (!ContainsCollision(collisions, c))
                                        {
                                            collisions.Add(c);
                                            c.entity1.WasHit = true;
                                            c.entity2.WasHit = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return collisions;
        }

        private bool ContainsCollision(List<Collision> list, Collision c1)
        {
            foreach (Collision c2 in list)
            {
                if (c2.entity1.Equals(c1.entity2) && (c2.entity2.Equals(c1.entity1)) && c2.intersection.Equals(c1.intersection))
                {
                    return true;
                }
            }
            return false;
        }

        public struct Collision : IComparable
        {
            public IEntity entity1;
            public IEntity entity2;
            public FloatRectangle intersection;
            public TimeFrame frame;

            public int CompareTo(object obj)
            {
                Collision c = (Collision)obj;

                if (this.frame.time < c.frame.time)
                {
                    return -1;
                }
                else if (this.frame.time == c.frame.time)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }

            public CollisionSide GetSide()
            {
                if (intersection.height > intersection.width)
                {
                    /*if (entity1.Location.X < entity2.Location.X + entity2.WidthHeight.X)
                    {
                        return CollisionSide.Left;
                    }
                    else if (entity1.Location.X > entity2.Location.X + entity2.WidthHeight.X)
                    {
                        return CollisionSide.Right;
                    }*/

                    if (entity1.Location.X < entity2.Location.X)
                    {
                        return CollisionSide.Right;
                    }
                    else
                    {
                        return CollisionSide.Left;
                    }
                }
                else if (intersection.width > intersection.height)
                {
                    /*if (entity1.Location.Y < entity2.Location.Y + entity2.WidthHeight.Y)
                    {
                        return CollisionSide.Bottom;
                    }
                    else if (entity1.Location.Y > entity2.Location.Y + entity2.WidthHeight.Y)
                    {
                        return CollisionSide.Top;
                    }*/

                    if (entity1.Location.Y < entity2.Location.Y)
                    {
                        return CollisionSide.Bottom;
                    }
                    else
                    {
                        return CollisionSide.Top;
                    }
                }

                return CollisionSide.Top;
            }
        }

        public enum CollisionSide
        {
            Left,
            Right,
            Top,
            Bottom,
            None
        }

        public struct TimeFrame
        {
            public FloatRectangle entityRectangle;
            public int time;
        }

        public struct CollisionStats
        {
            public IEntity entity;
            public List<TimeFrame> frames;
        }

        public struct FloatRectangle
        {
            public float x;
            public float y;
            public float width;
            public float height;

            public FloatRectangle(float x, float y, float width, float height)
            {
                this.x = x;
                this.y = y;
                this.width = width;
                this.height = height;
            }

            public FloatRectangle(Rectangle rect)
            {
                this.x = rect.X;
                this.y = rect.Y;
                this.width = rect.Width;
                this.height = rect.Height;
            }

            public static bool Intersects(FloatRectangle a, FloatRectangle b)
            {
                if (a.x < b.x + b.width && b.x < a.x + a.width && a.y < b.y + b.height)
                {
                    return b.y < a.y + a.height;
                }
                else
                {
                    return false;
                } 
            }

            public static FloatRectangle Intersect(FloatRectangle a, FloatRectangle b)
            {
                float x = Math.Max(a.x, b.x);
                float num1 = Math.Min(a.x + a.width, b.x + b.width);
                float y = Math.Max(a.y, b.y);
                float num2 = Math.Min(a.y + a.height, b.y + b.height);
                if (num1 >= x && num2 >= y)
                    return new FloatRectangle(x, y, num1 - x, num2 - y);
                else
                    return new FloatRectangle(0, 0, 0, 0);
            }

            public override bool Equals(object obj)
            {
                if (obj is FloatRectangle)
                {
                    FloatRectangle rect = (FloatRectangle)obj;
                    return float.Equals(this.x, rect.x) && float.Equals(this.y, rect.y) && float.Equals(this.width, rect.width) && float.Equals(this.height, rect.height);
                }

                return false;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

        }
    }
}