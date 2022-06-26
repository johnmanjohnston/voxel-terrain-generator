using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject TerrainBase;

    public int Width;
    public int Height;
    public int Seed;

    private void Start() {
        NoiseGenerator Generator = new NoiseGenerator(Width, Height, Seed);
        float[] NoiseData = Generator.Calculate();

        for (int y = 0; y < Height; y++) {
            for (int x = 0; x < Width; x++) {
                float CurrentNoise = NoiseData[y * Width + x];

                if (CurrentNoise > 0.2f) {
                    for (int i = 1; i < CurrentNoise * 7; i++) {
                        GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        Cube.transform.position = new Vector3(x - 15, i, y - 15);
                        Cube.transform.parent = TerrainBase.transform;
                    }
                }
            }
        }
    }
}
