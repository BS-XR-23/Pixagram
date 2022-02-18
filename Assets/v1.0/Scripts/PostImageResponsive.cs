using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostImageResponsive : MonoBehaviour
{
    public Sprite image;
    public float aspectRatio;
    public Texture Texture;
    
    private void Awake()
    {
        Image image = GetComponent<Image>();
        Texture texture = image.sprite.texture;
    }
    private void Start()
    {
      
    }
}
