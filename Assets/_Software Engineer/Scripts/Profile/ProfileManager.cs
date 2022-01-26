using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    [Header("Buttons")] [Space(5)]
    
    [SerializeField] private UnityEngine.UI.Button newButton;
    [SerializeField] private UnityEngine.UI.Button settingsButton;
    [SerializeField] private UnityEngine.UI.Button homeButton;
    [SerializeField] private UnityEngine.UI.Button searchButton;
    [SerializeField] private UnityEngine.UI.Button newPostButton;
    [SerializeField] private UnityEngine.UI.Button shopButton;
    [SerializeField] private UnityEngine.UI.Button profileButton;
    
    
    [Space(12)] [Header("Game Objects")] [Space(5)] 
    
    [SerializeField] private GameObject homeScene;
    [SerializeField] private GameObject searchScene;
    [SerializeField] private GameObject createPostScene;
    [SerializeField] private GameObject shopScene;
    [SerializeField] private GameObject profileScene;
    
    private void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(newButton);
        UnityEngine.Assertions.Assert.IsNotNull(settingsButton);
        UnityEngine.Assertions.Assert.IsNotNull(homeButton);
        UnityEngine.Assertions.Assert.IsNotNull(searchButton);
        UnityEngine.Assertions.Assert.IsNotNull(newPostButton);
        UnityEngine.Assertions.Assert.IsNotNull(shopButton);
        UnityEngine.Assertions.Assert.IsNotNull(profileButton);
        
        newButton.onClick.AddListener(On_Click_NewButton);
        settingsButton.onClick.AddListener(On_Click_SettingsButton);
        homeButton.onClick.AddListener(On_Click_HomeButton);
        searchButton.onClick.AddListener(On_Click_SearchButton);
        newPostButton.onClick.AddListener(On_Click_NewPostButton);
        shopButton.onClick.AddListener(On_Click_ShopButton);
        profileButton.onClick.AddListener(On_Click_ProfileButton);
    }

    private void On_Click_ProfileButton()
    {
        throw new System.NotImplementedException();
    }

    private void On_Click_ShopButton()
    {
        InactiveProfileScene();
        shopScene.SetActive(true);
    }

    private void On_Click_NewPostButton()
    {
        InactiveProfileScene();
        createPostScene.SetActive(true);
    }

    private void On_Click_SearchButton()
    {
        InactiveProfileScene();
        searchScene.SetActive(true);
    }

    private void On_Click_HomeButton()
    {
        InactiveProfileScene();
        homeScene.SetActive(true);
    }

    private void On_Click_SettingsButton()
    {
        throw new System.NotImplementedException();
    }

    private void On_Click_NewButton()
    {
        throw new System.NotImplementedException();
    }

    private void InactiveProfileScene()
    {
        profileScene.SetActive(false);
    }
}
