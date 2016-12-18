using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace StateMachine
{
    internal class Map
    {
        public List<IntRect> CollisionRectangleShapes;
        private Sprite[,,] _tiles;

        private Texture invisTexture;
        public List<Sprite> collisionsprites;
        public List<Sprite> enemySprites;
        public IntRect collisionRect;

        private int _mapWidth, _mapHeight,
            _tileMapHeight, _tileMapWidth,
            _tileWidth, _tileHeight;

        private const uint FLIPPED_HORIZONTALLY_FLAG = 0x80000000;
        private const uint FLIPPED_VERTICALLY_FLAG = 0x40000000;
        private const uint FLIPPED_DIAGONALLY_FLAG = 0x20000000;

        public OpenWorldScene MyScene;

        private XDocument xmlDoc = XDocument.Parse(File.ReadAllText("Resources/Map/TileMap.tmx"));

        /// <summary>
        /// Parsing the values from .tmx and creating a tilemap
        /// </summary>
        /// <param name="world"></param>
        public Map(OpenWorldScene world)
        {
            this.MyScene = world;
            Texture textureAtlas = new Texture("Resources/Map/TextureAtlas.png");
            Sprite[] spritePool;

            foreach (var root in xmlDoc.Elements())
            {
                ObjectCollision();

                _tileWidth = int.Parse(root.Attribute(XName.Get("tilewidth")).Value);
                _tileHeight = int.Parse(root.Attribute(XName.Get("tileheight")).Value);

                _mapHeight = int.Parse(root.Attribute(XName.Get("height")).Value);
                _mapWidth = int.Parse(root.Attribute(XName.Get("width")).Value);

                var tileSetProps = root.Element(XName.Get("tileset"));
                _tileMapWidth = int.Parse(tileSetProps.Attribute(XName.Get("columns")).Value);
                _tileMapHeight = int.Parse(tileSetProps.Attribute(XName.Get("tilecount")).Value) / _tileMapWidth;

                spritePool = new Sprite[_tileMapHeight * _tileMapWidth + 1];
                spritePool[0] = new Sprite(new Texture("Resources/Map/NotVisible.png"));

                // Cutting Atlas into Tiles

                for (int y = 0; y < _tileMapHeight; y++)
                {
                    for (int x = 0; x < _tileMapWidth; x++)
                    {
                        IntRect rect = new IntRect(x * _tileHeight, y * _tileWidth, _tileWidth, _tileHeight);
                        spritePool[(y * _tileMapWidth) + x + 1] = new Sprite(textureAtlas, rect);
                    }
                }

                var layers = root.Elements(XName.Get("layer"));

                _tiles = new Sprite[_mapWidth, _mapHeight, layers.Count()];

                int currentlayer = 0;

                //Queue for Drawing the tiles on a map. (Layers )

                foreach (var layer in layers)
                {
                    var data = layer.Element("data").Value.Replace("\n", String.Empty).Split(',');
                    for (int y = 0; y < _mapHeight; y++)
                    {
                        // Rotating and scaling. Formula was taken from the tilemap docs. 
                        for (int x = 0; x < _mapWidth; x++)
                        {
                            var globalId = uint.Parse(data[y * _mapWidth + x]);
                            var id = globalId &
                                                ~(FLIPPED_HORIZONTALLY_FLAG |
                                                  FLIPPED_VERTICALLY_FLAG |
                                                  FLIPPED_DIAGONALLY_FLAG);

                            _tiles[x, y, currentlayer] = new Sprite(spritePool[id]);

                            bool fh = (globalId & FLIPPED_HORIZONTALLY_FLAG) != 0;
                            bool fv = (globalId & FLIPPED_VERTICALLY_FLAG) != 0;
                            bool fd = (globalId & FLIPPED_DIAGONALLY_FLAG) != 0;

                            _tiles[x, y, currentlayer].Position = new Vector2f((x) * _tileWidth, (y) * _tileHeight);

                            // Check the Rotation of Tiles
                            if (fh && !fv && !fd)
                            {
                                _tiles[x, y, currentlayer].Scale = new Vector2f(-1, 1);
                                _tiles[x, y, currentlayer].Position += new Vector2f(_tileWidth, 0);
                            }
                            if (!fh && fv && !fd)
                            {
                                _tiles[x, y, currentlayer].Scale = new Vector2f(1, -1);
                                _tiles[x, y, currentlayer].Position += new Vector2f(0, _tileHeight);
                            }

                            if (!fh && !fv && fd)
                            {
                                _tiles[x, y, currentlayer].Rotation = 90;
                                _tiles[x, y, currentlayer].Scale = new Vector2f(1, -1);
                            }

                            if (fh && !fv && fd)
                            {
                                _tiles[x, y, currentlayer].Rotation = 90;
                                _tiles[x, y, currentlayer].Position += new Vector2f(_tileWidth, 0);
                            }
                            if (fh && fv && !fd)
                            {
                                _tiles[x, y, currentlayer].Scale = new Vector2f(-1, -1);
                                _tiles[x, y, currentlayer].Position += new Vector2f(_tileWidth, _tileHeight);
                            }
                            if (fh && fv && fd)
                            {
                                _tiles[x, y, currentlayer].Position += new Vector2f(_tileWidth, _tileHeight);
                                _tiles[x, y, currentlayer].Scale = new Vector2f(-1, 1);
                                _tiles[x, y, currentlayer].Rotation = 90;
                            }
                            if (!fh && fv && fd)
                            {
                                _tiles[x, y, currentlayer].Scale = new Vector2f(-1, -1);
                                _tiles[x, y, currentlayer].Position += new Vector2f(0, _tileHeight);
                                _tiles[x, y, currentlayer].Rotation = 90;
                            }
                        }
                    }
                    currentlayer++;
                }
            }
        }
        /// <summary>
        /// Creating a collision for every unmoveable object
        /// </summary>
        public void ObjectCollision()
        {
            CollisionRectangleShapes = new List<IntRect>();
            var collisionObjects = from q in xmlDoc.Descendants("object")
                                   select new
                                   {
                                       id = (int)q.Attribute("id"),
                                       xCoordinates = (int)q.Attribute("x"),
                                       yCoordinates = (int)q.Attribute("y"),
                                       width = (int)q.Attribute("width"),
                                       height = (int)q.Attribute("height")
                                   };
            collisionsprites = new List<Sprite>();

            foreach (var cobj in collisionObjects)
            {
                collisionsprites.Add(new Sprite(new Texture("Resources/Map/Test1.png")) { Position = new Vector2f(cobj.xCoordinates, cobj.yCoordinates), Scale = new Vector2f(cobj.width, cobj.height) });

                CollisionRectangleShapes.Add(new IntRect(cobj.xCoordinates, cobj.yCoordinates, cobj.width, cobj.height));
            }
        }

        public void Draw(RenderWindow window)
        {
            for (int y = 0; y < _mapHeight; y++)
            {
                for (int x = 0; x < _mapWidth; x++)
                {
                    for (int i = 0; i < _tiles.GetLength(2); i++)
                    {
                        window.Draw(_tiles[x, y, i]);
                    }
                }
            }
        }
    }
}