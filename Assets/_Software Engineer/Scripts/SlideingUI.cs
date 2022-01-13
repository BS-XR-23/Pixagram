using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SlideingUI : MonoBehaviour
{
    [SerializeField] private float slidingSpeed = 1f;
    [SerializeField] private Transform sliderHidePosition;
    [SerializeField] private Transform sliderShowPosition;
    
    private void Start()
    {
        transform.position = sliderHidePosition.position;
    }

    [ContextMenu("Slide Up")]
    public void SlideUp()
    {
        transform.DOMove(sliderShowPosition.position, slidingSpeed);
    }
    
    [ContextMenu("Slide Down")]
    public void SlideDown()
    {
        transform.DOMove(sliderHidePosition.position, slidingSpeed);
    }


    private void Update()
    {
        Debug.Log(transform.position);
    }
}
