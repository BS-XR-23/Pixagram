using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SlideingUI : MonoBehaviour
{
    [SerializeField] private float slidingSpeed = 1f;
    [SerializeField] private Transform slidingUI;
    [SerializeField] private Transform sliderHidePosition;
    [SerializeField] private Transform sliderShowPosition;
    [SerializeField] private Button blankSpace;
    [SerializeField] private CanvasGroup interactableCanvas;

    private Image _blankSpaceImage;
    
    private void Start()
    {
        slidingUI.transform.position = sliderHidePosition.position;
        _blankSpaceImage = blankSpace.GetComponent<Image>();
        blankSpace.onClick.AddListener(On_Click_BlankSpace);
        blankSpace.enabled = false;
        interactableCanvas.interactable = false;
        interactableCanvas.blocksRaycasts = false;
    }

    private void On_Click_BlankSpace()
    {
       SlideDown();
    }

    [ContextMenu("Slide Up")]
    public void SlideUp()
    {
        slidingUI.transform.DOMove(sliderShowPosition.position, slidingSpeed);
        _blankSpaceImage.DOFade(.75f, slidingSpeed);
        blankSpace.enabled = true;
        interactableCanvas.interactable = true;
        interactableCanvas.blocksRaycasts = true;
    }
    
    [ContextMenu("Slide Down")]
    public void SlideDown()
    {
        slidingUI.DOMove(sliderHidePosition.position, slidingSpeed);
        _blankSpaceImage.DOFade(0f, slidingSpeed);
        blankSpace.enabled = false;
        interactableCanvas.interactable = false;
        interactableCanvas.blocksRaycasts = false;
    }
}
