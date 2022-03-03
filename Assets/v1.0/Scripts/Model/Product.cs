using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    [SerializeField]
    private DraggingController _draggingController;
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
    [SerializeField]
    private Transform defaultModel;

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
        
        if (product == null) {
           
            _draggingController.enabled = false;
            LoadTexture(texureURL);
        }
        else
        {
            _rawImage.enabled = false;
            GameObject obj = Instantiate(product.styleObject.gameObject, _modelParent);

            Rigidbody rb = obj.AddComponent<Rigidbody>();
            rb.angularDrag = defaultModel.GetComponent<Rigidbody>().angularDrag;
            rb.useGravity = defaultModel.GetComponent<Rigidbody>().useGravity;
            obj.AddComponent<BoxCollider>().isTrigger=true;
            obj.name = name;
            if (product.category=="outfit")
            {
                obj.transform.localScale = defaultModel.localScale +new Vector3(40000,40000,40000);
                obj.transform.position = defaultModel.position-new Vector3(0,1.8f,0);
            }
            else
            {
                obj.transform.localScale = defaultModel.localScale;
                obj.transform.position = defaultModel.position;
            }
            
            print($"name:{name}");
            obj.transform.rotation = defaultModel.rotation;
            
            _draggingController.target = obj.transform;
            _draggingController._zoomTarget = obj.transform;
        }
    }
    private async void LoadTexture(string texureURL)
    {
        UnityWebRequest textureRequest = UnityWebRequestTexture.GetTexture(texureURL);
        await textureRequest.SendWebRequest();
        if(_rawImage!=null)
        {
            _rawImage.texture = ((DownloadHandlerTexture)textureRequest.downloadHandler).texture;
            GetComponentInChildren<AspectRatioFitter>().aspectRatio = _rawImage.texture.width / (float)_rawImage.texture.height;
            _rawImage.enabled = true;
            
        }
       
    }
    private void BuyNow()
    {
        Application.OpenURL(_permalink);
    }
   
}
