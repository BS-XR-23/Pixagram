using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SlideingUI : MonoBehaviour
{
    [SerializeField] private float slidingSpeed = 1f;
    [SerializeField] private Transform slidingUI;
    [SerializeField] private Transform sliderHidePosition;
    [SerializeField] private Transform sliderShowPosition;
    
    private void Start()
    {
        slidingUI.transform.position = sliderHidePosition.position;
    }

    [ContextMenu("Slide Up")]
    public void SlideUp()
    {
        slidingUI.transform.DOMove(sliderShowPosition.position, slidingSpeed);
    }
    
    [ContextMenu("Slide Down")]
    public void SlideDown()
    {
        slidingUI.DOMove(sliderHidePosition.position, slidingSpeed);
    }
}
