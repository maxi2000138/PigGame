using System;

[Serializable]
public class CubesFileData
{
    public Tiles[] tiles;
    [Serializable]
    public class Tiles
    {
        public int id;
        public Properties[] properties;

        [Serializable]
        public class Properties
        {
            public string value;
        }
    }
}