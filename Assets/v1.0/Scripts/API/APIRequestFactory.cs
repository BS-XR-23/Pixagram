using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class APIRequestFactory
{
    private static APIRequestFactory _instance;
    private User user;
    public static APIRequestFactory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new APIRequestFactory();
            }
            return _instance;
        }
    }
    public async UniTask<T> Get<T>(string url,bool auth=false,string token="")
    {
      
        UnityWebRequest request = UnityWebRequest.Get(url);
        if(auth)request.SetRequestHeader("Authorization", $"Bearer {token}");
        await request.SendWebRequest();
        T info = default(T);
        if (request.result==UnityWebRequest.Result.Success)
        {
        
            var jsonResponse= request.downloadHandler.text;
            Debug.Log($"response:{jsonResponse}");
            info = JsonConvert.DeserializeObject<T>(jsonResponse);
            return info;

        }
        return info;
        
    }
    public async UniTask<string> Login(string url,WWWForm data)
    {
        //string postData = JsonConvert.SerializeObject(data);
        //Debug.Log($"data:{postData}");
        UnityWebRequest request = UnityWebRequest.Post($"{APIEndPoints.base_url}{url}", data);
        try
        {
           
            await request.SendWebRequest();
            if (request.error != null)
            {
                return "fail";
            }
            else
            {
                return request.downloadHandler.text;
            }
        }
        catch
        {
            if (request.error != null)
            {
                return "fail";
            }
        }
        return request.downloadHandler.text;

    }

}
