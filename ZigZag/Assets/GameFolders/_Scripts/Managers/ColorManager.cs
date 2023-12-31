using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] List<Color> colors;
    private int colorIndex;
    public Color newColor { get; private set; }
    
    private void Start()
    {
        colorIndex = 0;
        material.color = colors[0];
        StartCoroutine(ColorTimer());
    }

    private void Update()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        if(GameManager.Instance.IsGameOver && !GameManager.Instance.IsGameStarted) return;
        
        newColor = colors[colorIndex]; 
        material.color = Color.Lerp(material.color, newColor, 0.5f * Time.deltaTime);
    }

    IEnumerator ColorTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(11f);
            if (colorIndex == colors.Count - 1) 
                colorIndex = 0;
            else if (colorIndex < colors.Count)
                colorIndex++;
            SoundManager.Instance.PlayOneShot(3);
        }
    }
}
