using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostImageResponsive : MonoBehaviour
{
    public Sprite image;
    public float aspectRatio;
    
    private void Awake()
    {
        Debug.Log(image.rect.height);
        Debug.Log(image.bounds.size.y);
        aspectRatio = image.bounds.size.x / image.bounds.size.y;
        gameObject.GetComponent<AspectRatioFitter>().aspectRatio = aspectRatio;
        gameObject.GetComponent<Image>().sprite = image;
    }
}
