using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharp : MonoBehaviour
{

    public int width = 256;
    public int height = 256;
    public float red = 255;
    public float scale = 1;

    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
    }

    private Texture2D GenerateTexture()
    {
        Texture2D texutre = new Texture2D(width, height);

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texutre.SetPixel(x, y, color);
            }

        }

        //gameObject.GetComponent<MeshRenderer>().material.color = new Color(255, 97, 0);
        texutre.Apply();
        return texutre;
    }

    private Color CalculateColor(int x, int y)
    {
        float xCord = (float)x / width * scale;
        float yCord = (float)y / height * scale;

        float sample = Mathf.PerlinNoise(xCord, yCord);
        return new Color(sample, sample, 255);

    }
}
