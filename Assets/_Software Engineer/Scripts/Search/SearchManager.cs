using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchManager : MonoBehaviour
{
    [Header("Buttons")] [Space(5)]
    
    [SerializeField] private UnityEngine.UI.Button headerSearchButton;
    [SerializeField] private UnityEngine.UI.Button homeButton;
    [SerializeField] private UnityEngine.UI.Button footerSearchButton;
    [SerializeField] private UnityEngine.UI.Button newPostButton;
    [SerializeField] private UnityEngine.UI.Button shopButton;
    [SerializeField] private UnityEngine.UI.Button profileButton;

    
    [Space(12)] [Header("Game Objects")] [Space(5)] 
    
    [SerializeField] private GameObject search01Scene;
    [SerializeField] private GameObject search02Scene;
    [SerializeField] private GameObject homeScene;
    [SerializeField] private GameObject newPostScene;
    [SerializeField] private GameObject shopScene;
    [SerializeField] private GameObject profileScene;

    private void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(headerSearchButton);
        UnityEngine.Assertions.Assert.IsNotNull(homeButton);
        UnityEngine.Assertions.Assert.IsNotNull(footerSearchButton);
        UnityEngine.Assertions.Assert.IsNotNull(newPostButton);
        UnityEngine.Assertions.Assert.IsNotNull(shopButton);
        UnityEngine.Assertions.Assert.IsNotNull(profileButton);
        
        headerSearchButton.onClick.AddListener(On_Click_HeaderSearchButton);
        homeButton.onClick.AddListener(On_Click_HomeButton);
        footerSearchButton.onClick.AddListener(On_Click_FooterSearchButton);
        newPostButton.onClick.AddListener(On_Click_NewPostButton);
        shopButton.onClick.AddListener(On_Click_ShopButton);
        profileButton.onClick.AddListener(On_Click_ProfileButton);
    }

    private void On_Click_ProfileButton()
    {
        InactiveSearch01Scene();
        profileScene.SetActive(true);
    }

    private void On_Click_ShopButton()
    {
        InactiveSearch01Scene();
        shopScene.SetActive(true);
    }

    private void On_Click_NewPostButton()
    {
        InactiveSearch01Scene();
        newPostScene.SetActive(true);
    }

    private void On_Click_FooterSearchButton()
    {
        throw new NotImplementedException();
    }

    private void On_Click_HomeButton()
    {
        InactiveSearch01Scene();
        homeScene.SetActive(true);
    }

    private void On_Click_HeaderSearchButton()
    {
        throw new NotImplementedException();
    }


    private void InactiveSearch01Scene()
    {
        search01Scene.SetActive(false);
    }
}
