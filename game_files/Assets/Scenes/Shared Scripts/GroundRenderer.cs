using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRenderer : MonoBehaviour
{
    public Sprite groundSprite;
    public Sprite surfaceSprite;
    public Sprite caveSprite;

    public Sprite pointSprite;
    public int worldSize = 100;
    public float seed;
    public float surfaceFreq = 0.2f;
    public float caveFreq = 0.1f;
    public float terrainFreq = 0.1f;
    public Texture2D noiseTexture;

    public float heightMultiplier = 2f;
    public float heightAddition = 1f;

    private void Start()
    {
        seed = Random.Range(-1000, 1000);
        GenerateNoise();
        GenerateTerrain();
    }

    public void GenerateTerrain()
    {
        for (int x = 0; x < worldSize; x++)
        {
            float height = Mathf.PerlinNoise((x + seed) * terrainFreq, seed * terrainFreq) * heightMultiplier + heightAddition;
            for (int y = 0; y < height; y++)
            {
                if (noiseTexture.GetPixel(x, y).r > surfaceFreq)
                {
                    if (y < height - 1)
                    {
                        RenderTile(x, y, groundSprite, "solid");
                    }
                    else if (y == height - 9)
                    {
                        RenderTile(x, y, caveSprite, "solid");
                    }
                    else
                    {
                        RenderTile(x, y, surfaceSprite, "solid");
                    }

                    if (y >= height - 1)
                    {
                        int t = Random.Range(0, 10);
                        if (t == 0)
                        {
                            RenderTile(x, y + 1, pointSprite, "point");
                        }
                    }

                }
            }
        }
    }
    public void GenerateNoise()
    {
        noiseTexture = new Texture2D(worldSize, worldSize);
        for (int x = 0; x < noiseTexture.width; x++)
        {
            for (int y = 0; y < noiseTexture.width; y++)
            {
                float v = Mathf.PerlinNoise((x + seed) * caveFreq, (y + seed) * caveFreq);
                noiseTexture.SetPixel(x, y, new Color(v, v, v));
            }
        }
        noiseTexture.Apply();
    }

    public void RenderTile(int x, int y, Sprite sprite, string type = "solid")
    {
        GameObject newTile = new GameObject("Tile");
        newTile.transform.parent = this.transform;
        newTile.AddComponent<SpriteRenderer>();
        if (type == "solid")
        {
            newTile.AddComponent<BoxCollider2D>();
            newTile.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);
        }
        else if (type == "point")
        {
            newTile.AddComponent<CircleCollider2D>();
            newTile.GetComponent<CircleCollider2D>().isTrigger = true;
        }

        newTile.GetComponent<SpriteRenderer>().sprite = sprite;
        newTile.transform.position = new Vector2(x + 0.5f, y + 0.5f);

    }


}
