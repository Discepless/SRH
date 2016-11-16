using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Xml.Linq;
using SFML.Graphics;
using SFML.System;

namespace RPG
{
    class XMap
    {
        private Sprite[,,] _tiles;
        private int _mapWidth, _mapHeight,
            _tileMapHeight, _tileMapWidth,
            _tileWidth, _tileHeight;

        const uint FLIPPED_HORIZONTALLY_FLAG = 0x80000000;
        const uint FLIPPED_VERTICALLY_FLAG = 0x40000000;
        const uint FLIPPED_DIAGONALLY_FLAG = 0x20000000;

        public XMap()
        {
            XDocument xmlDoc = XDocument.Parse(File.ReadAllText("Maps/TileMap.tmx"));
            Texture textureAtlas = new Texture("Maps/TextureAtlas.png");
            Sprite[] spritePool;
            
            foreach (var root in xmlDoc.Elements())
            {
                _tileWidth = int.Parse(root.Attribute(XName.Get("tilewidth")).Value);
                _tileHeight = int.Parse(root.Attribute(XName.Get("tileheight")).Value);

                _mapHeight = int.Parse(root.Attribute(XName.Get("height")).Value);
                _mapWidth = int.Parse(root.Attribute(XName.Get("width")).Value);

                var tileSetProps = root.Element(XName.Get("tileset"));
                _tileMapWidth = int.Parse(tileSetProps.Attribute(XName.Get("columns")).Value);
                _tileMapHeight = int.Parse(tileSetProps.Attribute(XName.Get("tilecount")).Value) / _tileMapWidth;

                spritePool = new Sprite[_tileMapHeight * _tileMapWidth + 1];
                spritePool[0] = new Sprite(new Texture("Maps/NotVisible.png"));
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
                           bool fv =   (globalId & FLIPPED_VERTICALLY_FLAG) != 0;
                           bool fd =   (globalId & FLIPPED_DIAGONALLY_FLAG) != 0;
                      
                           _tiles[x, y, currentlayer].Position = new Vector2f(x * _tileWidth, y * _tileHeight);
                           _tiles[x, y, currentlayer].Scale = new Vector2f(1 * (fh ? -1 : 1) * (fd ?-1 : -1), 1 * (fv ? -1 : 1) * (fd ? -1 : -1));
                           
                            

                        }
                    }
                    currentlayer++;
                }
            }

            Console.WriteLine("Lel");

            
            
            
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

    class Map
    {
        private Sprite[,] tiles;
        private int mapWidth = 100;
        private int mapHeight = 100;

        public Map()
        {
            int tilemapWidth = 32;
            int tilemapHeight = 32;
            int tileSize = 32;

            Texture texture = new Texture("Maps/terrain_atlas.png");
            Sprite[] tilemap = new Sprite[tilemapWidth * tilemapHeight * 4];
            

            for (int y = 0; y < tilemapHeight; y++)
            {
                for (int x = 0; x < tilemapWidth; x++)
                {
                    IntRect rect = new IntRect(x*tileSize, y*tileSize, tileSize, tileSize);
                    tilemap[(y*tilemapWidth) + x] = new Sprite(texture, rect);
                }
            }

            tiles = new Sprite[mapWidth,mapHeight];
            StreamReader reader = new StreamReader("Maps/TileMap.csv");

            for (int y = 0; y < mapHeight; y++)
            {

                string line = reader.ReadLine();
                string[] items = line.Split(',');


                for (int x = 0; x < mapWidth; x++)
                {

                    int id = Convert.ToInt32(items[x]);
                    tiles[x,y] = new Sprite(tilemap[id]);
                    tiles [x,y].Position = new Vector2f(tileSize * x, tileSize * y);

                }
            }

            reader.Close();

            
        }

        public void Draw(RenderWindow window)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    window.Draw(tiles[x, y]);
                }
            }
        }
    }
}
