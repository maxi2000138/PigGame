[System.Serializable]
public class LevelFileData
{
    public Layer[] layers;

    [System.Serializable]
    public class Layer
    {
        public int[] data;
        public int width;
        public int height;
    }
}