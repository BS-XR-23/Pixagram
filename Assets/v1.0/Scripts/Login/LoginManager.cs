using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    [Header("InputFields")] [Space(5)]
    
    [SerializeField] private TMP_InputField userNameInputField;
    [SerializeField] private TMP_InputField passWordInputField;
    

    [Space(12)] [Header("Buttons")] [Space(5)]
    
    [SerializeField] private UnityEngine.UI.Button logInButton;
    [SerializeField] private UnityEngine.UI.Button forgetYourLogInDetailsButton;
    [SerializeField] private UnityEngine.UI.Button logInWithFacebookButton;
    [SerializeField] private UnityEngine.UI.Button dontHaveAnAccountButton;


    [Space(12)] [Header("GameObjects")] [Space(5)]

    [SerializeField] private GameObject loginScene;
    [SerializeField] private GameObject homeScene;
    [SerializeField] private GameObject walletScene;

    private void Start()
    {

        UnityEngine.Assertions.Assert.IsNotNull(logInButton);
        UnityEngine.Assertions.Assert.IsNotNull(forgetYourLogInDetailsButton);
        UnityEngine.Assertions.Assert.IsNotNull(logInWithFacebookButton);
        UnityEngine.Assertions.Assert.IsNotNull(dontHaveAnAccountButton);

        logInButton.onClick.AddListener(On_Click_LoginButton);
        forgetYourLogInDetailsButton.onClick.AddListener(On_Click_ForgetYourLogInDetailsButton);
        logInWithFacebookButton.onClick.AddListener(On_Click_LogInWithFacebookButton);
        dontHaveAnAccountButton.onClick.AddListener(On_Click_DontHaveAnAccountButton);
        if (PlayerPrefs.GetInt("logged_in")>0)
        {
            loginScene.SetActive(false);
            homeScene.SetActive(true);
        }
       
       
    }
    
    void On_Click_LoginButton()
    {
        print("i am called");
        PlayerPrefs.SetInt("logged_in",1);
        string accId = PlayerPrefs.GetString("Account");
        if (accId != null && accId.Length > 0)
        {
            ActiveHomeScene();
        }
        else
        {
            ActiveWalletScene();
        }
        InactiveLogInScene();
    }
    
    void On_Click_ForgetYourLogInDetailsButton()
    {
        
    }
    
    void On_Click_LogInWithFacebookButton()
    {
        
    }
    
    void On_Click_DontHaveAnAccountButton()
    {
        
    }
    
    
    void ActiveHomeScene()
    {
        homeScene.SetActive(true);
    }
    void ActiveWalletScene()
    {
        walletScene.SetActive(true);
    }

    void InactiveLogInScene()
    {
        loginScene.SetActive(false);
    }

}
