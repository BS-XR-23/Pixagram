using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
   
    [SerializeField]
    private TextMeshProUGUI _productName;
    [SerializeField]
    private TextMeshProUGUI _price;
    [SerializeField]
    private TextMeshProUGUI _description;
    [SerializeField]
    private RawImage _rawImage;
    [SerializeField]
    private Button _buyNow;
    [SerializeField]
    private Transform _modelParent;
    public Button fullscreen;
    [SerializeField]
    public GameObject fullscreenIcon;

    private string _permalink;
    void Start()
    {
        _rawImage.gameObject.SetActive(true);
    }
    public void Init(string name,string price,string description,string permalink,Product2 product, string texureURL = "")
    {
        _productName.text = name;
        _price.text = price;
        _description.text = description;
        _permalink = permalink;
        _buyNow.onClick.AddListener(BuyNow);
        LoadTexture(texureURL);

        if (product == null) {

            fullscreenIcon.SetActive(false);
        }
       
    }
    private async void LoadTexture(string texureURL)
    {
        UnityWebRequest textureRequest = UnityWebRequestTexture.GetTexture(texureURL);
        await textureRequest.SendWebRequest();
        if(_rawImage!=null)
        {
            _rawImage.texture = ((DownloadHandlerTexture)textureRequest.downloadHandler).texture;
            print($"ratio:{_rawImage.GetComponent<AspectRatioFitter>().aspectRatio} tex:{_rawImage.texture.width}");
            _rawImage.GetComponent<AspectRatioFitter>().aspectRatio = _rawImage.texture.width / (float)_rawImage.texture.height;
            _rawImage.enabled = true;
            
        }
       
    }
    private void BuyNow()
    {
        Application.OpenURL(_permalink);
    }
   
}
