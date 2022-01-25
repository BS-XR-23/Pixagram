using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    [Header("Buttons")] [Space(5)]
    
    [SerializeField] private UnityEngine.UI.Button activityButton;
    [SerializeField] private UnityEngine.UI.Button messengerButton;
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


    #region On_Click_Methods

    private void On_Click_ProfileButton()
    {
        InactiveHomeScene();
        ActiveProfileScene();
    }
    
    private void On_Click_ShopButton()
    {
        InactiveHomeScene();
        ActiveShopScene();
    }
    
    private void On_Click_NewPostButton()
    {
        InactiveHomeScene();
        ActiveCreatPostScene();
    }
    
    private void On_Click_SearchButton()
    {
        InactiveHomeScene();
        ActiveSearchScene();
    }
    
    private void On_Click_HomeButton()
    {
        
    }

    private void On_Click_MessengerButton()
    {
        //InactiveHomeScene();
    }

    private void On_Click_ActivityButton()
    {
        //InactiveHomeScene();
    }

    #endregion
    
    
    #region Private Methods

    private void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(activityButton);
        UnityEngine.Assertions.Assert.IsNotNull(messengerButton);
        UnityEngine.Assertions.Assert.IsNotNull(homeButton);
        UnityEngine.Assertions.Assert.IsNotNull(searchButton);
        UnityEngine.Assertions.Assert.IsNotNull(newPostButton);
        UnityEngine.Assertions.Assert.IsNotNull(shopButton);
        UnityEngine.Assertions.Assert.IsNotNull(profileButton);
        
        activityButton.onClick.AddListener(On_Click_ActivityButton);
        messengerButton.onClick.AddListener(On_Click_MessengerButton);
        homeButton.onClick.AddListener(On_Click_HomeButton);
        searchButton.onClick.AddListener(On_Click_SearchButton);
        newPostButton.onClick.AddListener(On_Click_NewPostButton);
        shopButton.onClick.AddListener(On_Click_ShopButton);
        profileButton.onClick.AddListener(On_Click_ProfileButton);
    }
    
    private void ActiveProfileScene()
    {
        profileScene.SetActive(true);
    }

    private void InactiveHomeScene()
    {
        homeScene.SetActive(false);
    }

    

    private void ActiveShopScene()
    {
        shopScene.SetActive(true);
    }

    

    private void ActiveCreatPostScene()
    {
        createPostScene.SetActive(true);
    }

    

    private void ActiveSearchScene()
    {
        searchScene.SetActive(true);
    }

    #endregion

    

    
}


