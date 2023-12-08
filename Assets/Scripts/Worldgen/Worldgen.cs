using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Sirenix.OdinInspector;

public class Worldgen : MonoBehaviour
{
    [SerializeField]
    private Tilemap GroundTiles;

    public TileBase GrassTile;
    public TileBase LightGrassTile;
    public TileBase WaterTile;
    public TileBase EarthTile;
    public TileBase ChestTile;

    private Texture2D NoiseTexture;
    private Renderer Render;

    [SerializeField]
    private int Size = 1;

    [SerializeField]
    private int Lacunarity = 1;

    [SerializeField]
    private int Octaves = 1;

    [SerializeField]
    private int Persinstance = 1;

    [SerializeField]
    private float Scale = 1;

    [Range(0f, 100f)]
    [SerializeField]
    private float ChestChance = 2;

    [SerializeField]
    private int Treshold = 1;

    [Button("Generate Noise Map!")]
    private void GenerateButton()
    {
        GenerateGround();
    }

    private void Start()
    {
        /*Render = GetComponent<Renderer>();
        NoiseTexture = new Texture2D(100, 100);

        NoiseTexture.filterMode = FilterMode.Point;*/
        
       GenerateGround();

       //Tile = GroundTiles.GetTile(new Vector3Int(4, 1));

       //Render.material.mainTexture = NoiseTexture;
    }

    private void GenerateGround()
    {
        for(int x = 0; x < Size; x++)
        {
            for(int y = 0; y < Size; y++)
            {
                float amplitude = 1;
                float frequency = 1;
                float HeightSample = 0;

                for (int o = 0; o < Octaves; o++)
                {
                    float xCoord = (float)x / Size * Scale;
                    float yCoord = (float)y / Size * Scale;

                    float noise = Mathf.PerlinNoise(xCoord, yCoord);

                    HeightSample += noise * amplitude;

                    amplitude *= Persinstance;
                    frequency *= Lacunarity;
                }

                TileBase Tile;

                if(HeightSample < 0.5f)
                {
                    Tile = WaterTile;
                }
                else if(HeightSample > 0.5f && HeightSample < 0.7f)
                {
                    Tile = EarthTile;
                }
                else if (HeightSample > 0.7f && HeightSample < 0.9f)
                {
                    Tile = LightGrassTile;
                }
                else
                {
                    Tile = GrassTile;
                }
                
                // We can't spawn chests in water
                if(HeightSample > 0.53)
                {
                    float a = (float)Random.Range(0, 100000) / 1000;

                    if(a < ChestChance)
                    {
                        Tile = ChestTile;
                    }
                }

                GroundTiles.SetTile(new Vector3Int(x - (Size / 2), y - (Size / 2), 0), Tile);
            }
        }
    }
}