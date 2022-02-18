using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using static ImportNFTTextureExample;

public class ProfileManager : MonoBehaviour
{
    [Header("Buttons")]
    [Space(5)]

    [SerializeField] private UnityEngine.UI.Button newButton;
    [SerializeField] private UnityEngine.UI.Button settingsButton;
    [SerializeField] private UnityEngine.UI.Button homeButton;
    [SerializeField] private UnityEngine.UI.Button searchButton;
    [SerializeField] private UnityEngine.UI.Button newPostButton;
    [SerializeField] private UnityEngine.UI.Button shopButton;
    [SerializeField] private UnityEngine.UI.Button profileButton;
    [SerializeField] private UnityEngine.UI.Button removeWallet;

    [Header("TextMesh")]
    [Space(5)]
    [SerializeField] private TextMeshProUGUI accountId;
    [SerializeField] private TextMeshProUGUI balanceText;


    [Space(12)]
    [Header("Game Objects")]
    [Space(5)]

    [SerializeField] private GameObject homeScene;
    [SerializeField] private GameObject searchScene;
    [SerializeField] private GameObject createPostScene;
    [SerializeField] private GameObject shopScene;
    [SerializeField] private GameObject profileScene;
    [SerializeField] private GameObject settingsSlide;
    [SerializeField] private GameObject createSlide;
    [SerializeField] private GameObject wallet;

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
        _ = LoadWalletAsync();
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
        settingsSlide.GetComponent<SlideingUI>().SlideUp();
    }

    private void On_Click_NewButton()
    {
        createSlide.GetComponent<SlideingUI>().SlideUp();
    }

    private void InactiveProfileScene()
    {
        profileScene.SetActive(false);
    }
    public async Task LoadWalletAsync()
    {
       
        if (PlayerPrefs.GetString("Account") != null && PlayerPrefs.GetString("Account").Length > 0)
        {
           
            accountId.text = $"Acc Id: {PlayerPrefs.GetString("Account")}";
            removeWallet.gameObject.SetActive(true);
            wallet.SetActive(true);
            GetAllERC1155Token();
            GetAllERC721Token();
            string balance = await GetBalanceAsync();
            balanceText.text = $"Balance: {WEI_TO_ETH(balance)} ETH";
            
        }
        else
        {
            removeWallet.gameObject.SetActive(false);
            wallet.SetActive(false);
        }
    }
    private async Task<string> GetBalanceAsync()
    {
        string chain = "ethereum";
        string network = "rinkeby"; // mainnet ropsten kovan rinkeby goerli
        string account = PlayerPrefs.GetString("Account");
        string balance = await EVM.BalanceOf(chain, network, account);
        
        return balance;
    }
    async public void AddWalletAsync()
    {
        int timestamp = (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
        // set expiration time
        int expirationTime = timestamp + 60;
        // set message
        string message = expirationTime.ToString();
        // sign message
        string signature = await Web3Wallet.Sign(message);
        // verify account
        string account = await EVM.Verify(message, signature);
        int now = (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
        // validate
        if (account.Length == 42 && expirationTime >= now)
        {
            PlayerPrefs.SetString("Account", account);
            _ = LoadWalletAsync();
            DialogBoxController.Instance.ShowDialog("Wallet Added Sucessfully",()=>
            {
               

            });
        }

    }
    public void RemoveWallet()
    {
        DialogBoxController.Instance.ShowDialog("Do You Want To Remove Wallet?", () =>
        {

            PlayerPrefs.SetString("Account", "");
            _ = LoadWalletAsync();

        },()=> { },"No","Yes");
      
    }
    private string WEI_TO_ETH(string balance)
    {
        float wei = float.Parse(balance);
        float decimals = 1000000000000000000; // 18 decimals
        float eth = wei / decimals;
        return Convert.ToDecimal(eth).ToString();
    }
    private float ETH_TO_WEI()
    {
        float eth = float.Parse("0.1");
        float decimals = 1000000000000000000; // 18 decimals
        float wei = eth * decimals;
        print(Convert.ToDecimal(eth).ToString());
        return wei;
    }
    async void GetAllERC1155Token()
    {
        string chain = "ethereum";
        string network = "rinkeby"; // mainnet ropsten kovan rinkeby goerli
        string account = PlayerPrefs.GetString("Account");  //"0xebc0e6232fb9d494060acf580105108444f7c696";
        string contract = "";
        string response = await EVM.AllErc1155(chain, network, account, contract);
        try
        {

            NFTs[] erc1155s = JsonConvert.DeserializeObject<NFTs[]>(response);
            print($"Number Of Token:{erc1155s.Length}");
            foreach (NFTs nFTs in erc1155s)
            {
                print($"Contract:{nFTs.contract}||tokenId:{nFTs.tokenId}||Uri:{nFTs.uri}||Balance:{nFTs.balance}");


                //UnityWebRequest webRequest = UnityWebRequest.Get(nFTs.uri);
                //await webRequest.SendWebRequest();
                //var downloadData = webRequest.downloadHandler.data;
                //print("downloadData: " + downloadData.ToString());
                //Response data = JsonUtility.FromJson<Response>(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));

                //print("imageUri: " + data.ToString());
                //// parse json to get image uri
                //string imageUri = data.image;
                //print("imageUri: " + imageUri);
            }

        }
        catch
        {
            print("Error: " + response);
        }
    }
    async void GetAllERC721Token()
    {
        string chain = "ethereum";
        string network = "rinkeby"; // mainnet ropsten kovan rinkeby goerli
        string account = PlayerPrefs.GetString("Account");  //"0xebc0e6232fb9d494060acf580105108444f7c696";
        string contract = "";
        string response = await EVM.AllErc721(chain, network, account, contract);
        try
        {

            NFTs[] erc1155s = JsonConvert.DeserializeObject<NFTs[]>(response);
            print($"Number Of Token:{erc1155s.Length}");
            foreach (NFTs nFTs in erc1155s)
            {
                print($"Contract:{nFTs.contract}||tokenId:{nFTs.tokenId}||Uri:{nFTs.uri}||Balance:{nFTs.balance}");

                if(nFTs.uri.StartsWith("http://")|| nFTs.uri.StartsWith("https://"))
                {
                    UnityWebRequest webRequest = UnityWebRequest.Get(nFTs.uri);
                    await webRequest.SendWebRequest();
                    var downloadData = webRequest.downloadHandler.data;
                    print("downloadData: " + System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));
                    Response data = JsonUtility.FromJson<Response>(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));

                    //print("imageUri: " + data.ToString());
                    // parse json to get image uri
                    string imageUri = data.image;
                    print("imageUri: " + imageUri);
                }

            }

        }
        catch
        {
            print("Error: " + response);
        }
    }
    private class NFTs
    {
        public string contract { get; set; }
        public string tokenId { get; set; }
        public string uri { get; set; }
        public string balance { get; set; }
    }

}
