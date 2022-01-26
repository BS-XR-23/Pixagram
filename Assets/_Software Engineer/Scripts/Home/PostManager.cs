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
    
    
    private GameObject _commentsScene;
    private GameObject _shareScene;
    private GameObject _ellipsisScene;
    
    

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
        
        _commentsScene = GameObject.Find("Comments");
        _shareScene = GameObject.Find("Share");
        _ellipsisScene = GameObject.Find("Ellipsis");

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
        _shareScene.GetComponent<SlideingUI>().SlideUp();
    }

    private void On_Click_CommentButton()
    {
        _commentsScene.GetComponent<SlideingUI>().SlideUp();
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
        _ellipsisScene.GetComponent<SlideingUI>().SlideUp();
    }
}
