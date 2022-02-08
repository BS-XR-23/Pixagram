using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("Buttons")] [Space(5)]
    
    [SerializeField] private UnityEngine.UI.Button backButton;
    
    
    [Space(12)] [Header("Game Objects")] [Space(5)] 
    
    [SerializeField] private GameObject homeScene;
    [SerializeField] private GameObject shopScene;
    
    
    private void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(backButton);

        backButton.onClick.AddListener(On_Click_BackButton);
    }

    private void On_Click_BackButton()
    {
        shopScene.SetActive(false);
        homeScene.SetActive(true);
    }
}
