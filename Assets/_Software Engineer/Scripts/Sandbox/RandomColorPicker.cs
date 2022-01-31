using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomColorPicker : MonoBehaviour
{
    private Image _image;
    // Start is called before the first frame update
    void Start()
    {
        Color32 randomColor = new Color32(
            (byte) Random.Range(0, 255), 
            (byte) Random.Range(0, 255), 
            (byte) Random.Range(0, 255),
            255
        );

        _image = GetComponent<Image>();
        _image.color = randomColor;
    }
    
}
