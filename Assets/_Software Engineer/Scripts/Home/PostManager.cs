using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PostManager : MonoBehaviour
{
    [Header("Texts")] [Space(5)] 
    
    [SerializeField] private TMP_Text accountName;
    [SerializeField] private TMP_Text views;
    [SerializeField] private TMP_Text comments;
    
    
    [Space(12)] [Header("Buttons")] [Space(5)]
    
    [SerializeField] private UnityEngine.UI.Button ellipsisButton;
    [SerializeField] private UnityEngine.UI.Button reactButton;
    [SerializeField] private UnityEngine.UI.Button unReactButton;
    [SerializeField] private UnityEngine.UI.Button commentButton;
    [SerializeField] private UnityEngine.UI.Button shareButton;
    [SerializeField] private UnityEngine.UI.Button addToCollectionButton;
    [SerializeField] private ButtonDoubleClickListener imageHolder;


    [Space(12)] [Header("Game Objects")] [Space(5)] 
    
    [SerializeField] private GameObject commentsScene;
    [SerializeField] private GameObject shareScene;
    
    

    private void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(ellipsisButton);
        UnityEngine.Assertions.Assert.IsNotNull(reactButton);
        UnityEngine.Assertions.Assert.IsNotNull(unReactButton);
        UnityEngine.Assertions.Assert.IsNotNull(commentButton);
        UnityEngine.Assertions.Assert.IsNotNull(shareButton);
        UnityEngine.Assertions.Assert.IsNotNull(addToCollectionButton);
        
        ellipsisButton.onClick.AddListener(On_Click_EllipsisButton);
        reactButton.onClick.AddListener(On_Click_ReactButton);
        unReactButton.onClick.AddListener(On_Click_UnReactButton);
        commentButton.onClick.AddListener(On_Click_CommentButton);
        shareButton.onClick.AddListener(On_Click_ShareButton);
        addToCollectionButton.onClick.AddListener(On_Click_AddToCollectionButton);
        imageHolder.onDoubleClick.AddListener(On_Click_imageHolder);
    }

    private void On_Click_imageHolder()
    {
        throw new NotImplementedException();
    }

    private void On_Click_AddToCollectionButton()
    {
        throw new NotImplementedException();
    }

    private void On_Click_ShareButton()
    {
        shareScene.SetActive(true);
    }

    private void On_Click_CommentButton()
    {
        commentsScene.SetActive(true);
    }

    private void On_Click_UnReactButton()
    {
        throw new NotImplementedException();
    }

    private void On_Click_ReactButton()
    {
        throw new NotImplementedException();
    }

    private void On_Click_EllipsisButton()
    {
        throw new NotImplementedException();
    }
}
