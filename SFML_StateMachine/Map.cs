using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace GameplayWorld_DM
{
    internal class Map
    {
        private Sprite[,,] _tiles;

        private Texture invisTexture;
        public List<Sprite> collisionsprites;


        private int _mapWidth, _mapHeight,
            _tileMapHeight, _tileMapWidth,
            _tileWidth, _tileHeight;

        private const uint FLIPPED_HORIZONTALLY_FLAG = 0x80000000;
        private const uint FLIPPED_VERTICALLY_FLAG = 0x40000000;
        private const uint FLIPPED_DIAGONALLY_FLAG = 0x20000000;
        XDocument xmlDoc = XDocument.Parse(File.ReadAllText("Resources/Map/TileMap.tmx"));

        public Map()
        {

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
                // Нарезка атласа в спрайты

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

                foreach (var layer in layers)
                {
                    var data = layer.Element("data").Value.Replace("\n", String.Empty).Split(',');
                    for (int y = 0; y < _mapHeight; y++)
                    {
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

                            // §$%&/(
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
        
        public void ObjectCollision()
        {
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
                
                collisionsprites.Add(new Sprite(new Texture("Resources/Map/Test.png")) { Position = new Vector2f(cobj.xCoordinates, cobj.yCoordinates) });                
            }


            // collisionSprite.Position = new Vector2f(cobj.xCoordinates,cobj.yCoordinates);      




            //CollisionRect.TextureRect = new IntRect(cobj.xCoordinates, cobj.yCoordinates, cobj.width, cobj.height); 
            //collisionSprite.TextureRect = CollisionRect.TextureRect;


            //CollisionRect = new RectangleShape();
            //CollisionRect.TextureRect = new IntRect(cobj.xCoordinates,cobj.yCoordinates,cobj.width,cobj.height);

            //Console.WriteLine("id " + cobj.id, "XCoord" + cobj.xCoordinates, "YCoord" + cobj.yCoordinates, "width" + cobj.width, "height" + cobj.height);
        }


        /*
        xmlDoc.Descendants("object").Select(x => new
        {
            id = x.Attribute("id").Value,
            xCoordinates = x.Attribute("x").Value,
            yCoordinates = x.Attribute("y").Value,
            width = x.Attribute("width").Value,
            height = x.Attribute("height").Value,

        }).ToList().ForEach(x =>
        {
            IntRect CollisionRect = new IntRect();
        });
        */


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
            foreach (Sprite sprite in collisionsprites)
            {
                window.Draw(sprite);
            }                           
        }

    }
}




