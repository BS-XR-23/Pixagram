using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class StyleItem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _productName;
    [SerializeField]
    private RawImage _rawImage;
    public GameObject checkBox;
    public Button btn;
    void Start()
    {
        
    }
    public void Init(string name, string price, string description, string permalink, string texureURL)
    {
        _productName.text = name;
        LoadTexture(texureURL);

    }
    private async void LoadTexture(string texureURL)
    {
        UnityWebRequest textureRequest = UnityWebRequestTexture.GetTexture(texureURL);
        await textureRequest.SendWebRequest();
        if (_rawImage != null)
        {
            _rawImage.texture = ((DownloadHandlerTexture)textureRequest.downloadHandler).texture;
            GetComponentInChildren<AspectRatioFitter>().aspectRatio = (_rawImage.texture.width / (float)_rawImage.texture.height)+.1f;
            print($"height:{_rawImage.texture.height} width:${_rawImage.texture.width}");
            _rawImage.gameObject.SetActive(true);

        }

    }
}
