using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NFTData : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImage;
    [SerializeField]
    private TextMeshProUGUI _name;
    
    public void Init(string name,string texureURL)
    {
        LoadTexture(texureURL);
        _name.text = name;
    }
    private async void LoadTexture(string texureURL)
    {
        UnityWebRequest textureRequest = UnityWebRequestTexture.GetTexture(texureURL);
        await textureRequest.SendWebRequest();
        _rawImage.texture = ((DownloadHandlerTexture)textureRequest.downloadHandler).texture;
    }

    
}
