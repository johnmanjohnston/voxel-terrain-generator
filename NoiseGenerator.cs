using UnityEngine;

public class NoiseGenerator {
    private int Width;
    private int Height;

    private float YOrg;
    private float XOrg;

    private float Scale;

    private int Seed;

    public NoiseGenerator(int width, int height, int seed) {
        this.Width = width;
        this.Height = height;
        this.Seed = seed;
    }

    public float[] Calculate() {
        // fastnoiselite is so damn good why haven't i heard of this before?
        
        FastNoiseLite FastNoise = new FastNoiseLite();
        FastNoise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2S);
        FastNoise.SetSeed(Seed);
        float[] NoiseData = new float[Width * Height];
        int index = 0;

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < (Height + Width) / 2; x++)
            {
                NoiseData[index++] = FastNoise.GetNoise(x, y);
            }
        }

        return NoiseData;
    }

    public Texture2D GetTexture(float[] NoiseData, float w, float h) {
        Texture2D NoiseTexture = new Texture2D(Width, Height);
 
        for (int y = 0; y < Height; y++) {
            for (int x = 0; x < Width; x++) {
                NoiseTexture.SetPixel(x, y, new Color(NoiseData[y * Width + x], NoiseData[y * Width + x], NoiseData[y * Width + x]));
            }
        }

        NoiseTexture.Apply();
        // NoiseTexture.filterMode = FilterMode.Point;
        NoiseTexture.wrapMode = TextureWrapMode.Clamp;
        NoiseTexture.anisoLevel = 0;
        NoiseTexture.Apply();

        return NoiseTexture;
    }
}