using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//GRIDDY GRID GRID

namespace MarioGame
{
    public class Grid
    {

        public struct CoordinatePair
        {
            public int x;
            public int y;

            public CoordinatePair(int i, int j)
            {
                x = i;
                y = j;
            }
        }

        private struct grid
        {
            public Elements list;

            public grid(Elements elements)
            {
                list = elements;
            }
        }

        public const int TILE_SIDE = 16;
        private int tileHeight;
        private int tileWidth;

        private grid[,] tileMap;

        private Dictionary<IEntity, Coordinates> coordinateMap = new Dictionary<IEntity, Coordinates>();

        public void Add(IEntity entity)
        {
            Vector2 location = entity.Location;

            Coordinates coordinates = new Coordinates();

            while (location.X < entity.Location.X + entity.WidthHeight.X)
            {
                location.Y = entity.Location.Y;
                while (location.Y < entity.Location.Y + entity.WidthHeight.Y)
                {
                    tileMap[(int)location.X / TILE_SIDE, (int)location.Y / TILE_SIDE].list.add(entity);
                    coordinates.add(new CoordinatePair((int)location.X / TILE_SIDE, (int)location.Y / TILE_SIDE));
                    location.Y += TILE_SIDE;
                }
                location.X += TILE_SIDE;
            }

            tileMap[(int)(entity.Location.X + entity.WidthHeight.X - 1) / TILE_SIDE, (int)(entity.Location.Y) / TILE_SIDE].list.add(entity);
            tileMap[(int)(entity.Location.X) / TILE_SIDE, (int)(entity.Location.Y + entity.WidthHeight.Y - 1) / TILE_SIDE].list.add(entity);
            tileMap[(int)(entity.Location.X + entity.WidthHeight.X - 1) / TILE_SIDE, (int)(entity.Location.Y + entity.WidthHeight.Y - 1) / TILE_SIDE].list.add(entity);

            coordinates.add(new CoordinatePair((int)(entity.Location.X + entity.WidthHeight.X - 1) / TILE_SIDE, (int)(entity.Location.Y) / TILE_SIDE));
            coordinates.add(new CoordinatePair((int)(entity.Location.X) / TILE_SIDE, (int)(entity.Location.Y + entity.WidthHeight.Y - 1) / TILE_SIDE));
            coordinates.add(new CoordinatePair((int)(entity.Location.X + entity.WidthHeight.X - 1) / TILE_SIDE, (int)(entity.Location.Y + entity.WidthHeight.Y - 1) / TILE_SIDE));

            coordinateMap.Add(entity, coordinates);
        }

        public void Remove(IEntity entity)
        {
            Coordinates coordinates = coordinateMap[entity];
            coordinateMap.Remove(entity);

            HashSet<CoordinatePair> tiles = coordinates.returnSet();

            while (tiles.Count > 0)
            {
                CoordinatePair pair = tiles.First();
                tiles.Remove(pair);
                tileMap[pair.x, pair.y].list.remove(entity);
            }


        }

        public Elements ElementsAt(int x, int y)
        {
            return tileMap[x, y].list;
        }

        public HashSet<CoordinatePair> locationOf(IEntity entity)
        {
            return coordinateMap[entity].returnSet();
        }

        public Grid(int levelWidth, int levelHeight)
        {
            tileHeight = levelHeight / TILE_SIDE;
            tileWidth = levelWidth / TILE_SIDE;

            

            tileMap = new grid[tileWidth, tileHeight];

            for(int i = 0; i<tileWidth; i++)
            {
                for(int j = 0; j<tileHeight; j++)
                {
                    tileMap[i, j] = new grid(new Elements());
                }
            }
        }

        public class Elements
        {

            HashSet<IEntity> entityList = new HashSet<IEntity>();

            public void add(IEntity entity)
            {
                entityList.Add(entity);
            }

            public void remove (IEntity entity)
            {
                entityList.Remove(entity);
            }

            public HashSet<IEntity> getEntityList()
            {
                return entityList;
            }

            public int sizeOfEntityList()
            {
                return entityList.Count;
            }

        }
        public class Coordinates
        {
            protected HashSet<CoordinatePair> tiles = new HashSet<CoordinatePair>();

            public void add(CoordinatePair pair)
            {
                tiles.Add(pair);
            }

            public HashSet<CoordinatePair> returnSet()
            {
                return new HashSet<CoordinatePair>(tiles);
            }
        }
    }
}
