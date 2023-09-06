using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorManager : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] List<Color> colors;
    private int colorIndex;
    public Color newColor { get; private set; }
    
    private void Start()
    {
        material.color = Color.cyan;
        StartCoroutine(ChangeColor());
    }
    
    IEnumerator ChangeColor()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            colorIndex = Random.Range(0, colors.Count);
            newColor = colors[colorIndex];
            material.color = Color.Lerp(material.color, newColor, 0.5f);
        }
    }
}
