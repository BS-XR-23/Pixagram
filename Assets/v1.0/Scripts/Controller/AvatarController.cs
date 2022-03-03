using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
public class AvatarController : MonoBehaviour
{
    [Header("Default Style")]
    public Transform defaultSunglass;
    public Transform defaultOutfit;
    public Transform defaultHairCut;

    [Space(2)]
    [Header("Current Style")]
    private Transform _currentSunglass;
    private Transform _currentOutfit;
    private Transform _currentHairCut;

    [Space(2)]
    [Header("Previous Style")]
    private StyleItem _previousSunglass;
    private StyleItem _previousOutfit;
    private StyleItem _previousHairCut;


    [Space(2)]
    [Header("Prefab Parent")]
    [SerializeField]
    private Transform stylePrefabParent;

    [Space(2)]
    [Header("Animation")]
    [SerializeField]
    private Animator animator;

    [Space(2)]
    [Header("Prefab")]
    [SerializeField]
    private StyleItem stylePrefab;

    [SerializeField]
    private TextMeshProUGUI emptyItem;


    public Product2[] products;
    private int nftCount = 0;
    void Start()
    {
        
        string accId = PlayerPrefs.GetString("Account");
        if (accId != null&&accId.Length>0)
        {
            _ = InitDataAsync();
        }
        else
        {
            emptyItem.text = "No NFT.Please Add Your Wallet First";
            emptyItem.gameObject.SetActive(true);
        }
       
    }

    public void ChangeSunglass(Transform sunglass,bool visibility,Product2 product)
    {
       _currentSunglass= Change(sunglass, _currentSunglass, defaultSunglass, visibility, product,false);
    }
    public void ChangeOutfit(Transform outfit, bool visibility, Product2 product)
    {
       _currentOutfit= Change(outfit, _currentOutfit, defaultOutfit, visibility, product);
    }
    public void ChangeHairCut(Transform hairCut, bool visibility, Product2 product)
    {
       
        _currentHairCut= Change(hairCut, _currentHairCut, defaultHairCut, visibility, product);

    }
    public Transform Change(Transform current,Transform previous,Transform defaultStyle,bool visibility, Product2 product, bool activeDefault =true)
    {
        
        if (visibility)
        {
          
            
            if (previous!=null) DestroyImmediate(previous.gameObject);
            defaultStyle.gameObject.SetActive(false);
            previous = Instantiate(current, defaultStyle.parent);
            previous.localScale = defaultStyle.localScale;
            previous.position = defaultStyle.position;
            previous.rotation = defaultStyle.rotation;
            if(product.category=="outfit")
            {
               
                SkinnedMeshRenderer skinnedMeshRenderer = previous.GetComponent<SkinnedMeshRenderer>();
                skinnedMeshRenderer.rootBone = defaultOutfit.GetComponent<SkinnedMeshRenderer>().rootBone;
                skinnedMeshRenderer.bones= defaultOutfit.GetComponent<SkinnedMeshRenderer>().bones;


            }
           
        }
        else
        {
            if (activeDefault)
            {
                defaultStyle.gameObject.SetActive(true);
            }
            DestroyImmediate(previous.gameObject);
        }
        return previous;
    }
    private async Task InitDataAsync()
    {
        print($"Length:{products.Length}");
        for(int i=0;i<products.Length;i++)
        {
            Product2 product = products[i];
            StyleItem styleItem = Instantiate(stylePrefab, stylePrefabParent);
            styleItem.Init(product.product_name, product.price, product.description, product.permalink, product.texture_url);
            styleItem.checkBox.SetActive(false);
            styleItem.gameObject.SetActive(false);
            styleItem.btn.onClick.AddListener(()=>
            {
                animator.SetBool("default_pose",true);
                print(product.product_name);
                if (product.category=="sunglass")
                {
                    if(_previousSunglass!=null&& _previousSunglass!=styleItem)
                    {
                        _previousSunglass.checkBox.SetActive(false);
                    }
                  
                    styleItem.checkBox.SetActive(!styleItem.checkBox.activeSelf);
                    _previousSunglass = styleItem;
                    ChangeSunglass(product.styleObject, styleItem.checkBox.activeSelf, product);
                }
                else if (product.category == "outfit")
                {
                    if (_previousOutfit != null)
                    {
                        _previousOutfit.checkBox.SetActive(false);
                    }
                    styleItem.checkBox.SetActive(true);
                    _previousOutfit = styleItem;
                    ChangeOutfit(product.styleObject, styleItem.checkBox.activeSelf,product);
                }
                else if (product.category == "haircut")
                {
                    if (_previousHairCut != null)
                    {
                        _previousHairCut.checkBox.SetActive(false);
                    }
                    styleItem.checkBox.SetActive(true);
                    _previousHairCut = styleItem;
                    ChangeHairCut(product.styleObject, styleItem.checkBox.activeSelf,product);
                }
            });
            await CheckOwnShip(product.contact, product.token_id, styleItem.gameObject,i);
        }
       
    }
    async Task CheckOwnShip(string contract2,string tokenId2,GameObject gameObject,int index)
    {
        string chain = "ethereum";
        string network = "rinkeby";
        string contract = contract2;
        string account = PlayerPrefs.GetString("Account");
        string tokenId = tokenId2;
       
        System.Numerics.BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, account, tokenId);
        if(balanceOf>0)
        {
            gameObject.SetActive(true);
            emptyItem.gameObject.SetActive(false);
        }
       
        print($"index:{index}");
        print(balanceOf);
        
    }
}
[Serializable]
public class Product2
{
    
    public string product_name;
    public string price;
    public string description;
    public string contact;
    public string token_id;
    public string texture_url;
    public string permalink;
    public string category;
    public Transform styleObject;
    public Vector3 scale;
}
