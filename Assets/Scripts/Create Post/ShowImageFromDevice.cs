using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ShowImageFromDevice : MonoBehaviour
{
    public GameObject smallPhotoPrefab;
    public GameObject createPostScrollViewContent;
    private string _selectedFilePath;
    private List<string> _imagePath;


    private void Start()
    {
        _selectedFilePath = "/storage/emulated/0/DCIM/Camera/";
        GetAllFileName();
    }


    // public void ShowPictureFromInternalMemory()
    // {
    //     _selectedFilePath = "/storage/emulated/0/DCIM/Camera/";
    //     DirectoryInfo dataDir = new DirectoryInfo (_selectedFilePath);
    //     
    //     
    //         FileInfo[] fileinfo = dataDir.GetFiles ();
    //         //for (int i=0; i<fileinfo.Length; i++) {
    //         for (int i=0; i<10; i++) {
    //             string name = fileinfo [i].Name;
    //             _imagePath = _selectedFilePath + name;
    //             
    //             if( File.Exists( _imagePath ) )
    //
    //             {
    //                 var imageBytes = File.ReadAllBytes( _imagePath );
    //                 Texture2D texture = new Texture2D(1,1);
    //                 texture.LoadImage(imageBytes);
    //                 Sprite s = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1f);
    //                 GameObject imgGameObject = Instantiate(smallPhotoPrefab, createPostScrollViewContent.transform);
    //                 Image img = imgGameObject.GetComponent<Image>();
    //                 img.sprite = s;
    //             }
    //         }
    //     
    //     
    // }
    

    // public async void GetAllFileName()
    // {
    //     DirectoryInfo dataDir = new DirectoryInfo (_selectedFilePath);
    //     FileInfo[] fileinfo = dataDir.GetFiles ();
    //
    //     
    //     Debug.Log("File is saving");
    //     foreach (var file in fileinfo)
    //     {
    //         string finalPath = _selectedFilePath + file.Name;
    //         //_imagePath.Add(finalPath);
    //         Debug.Log(finalPath);
    //         await Task.Yield();
    //     }
    //     // Debug.Log("File is saved");
    //     // BeginCreatingPhotoAsset();
    // }
    public async void GetAllFileName()
    {
        DirectoryInfo dataDir = new DirectoryInfo (_selectedFilePath);
        FileInfo[] fileinfo = dataDir.GetFiles ();

        
        Debug.Log("File is saving");

        for (int i = 0; i < 12; i++)
        {
            string finalPath = _selectedFilePath + fileinfo[i].Name;
            var imageBytes = File.ReadAllBytes(finalPath);
            Texture2D texture = new Texture2D(1,1);
            texture.LoadImage(imageBytes);
            Sprite s = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1f);
            GameObject imgGameObject = Instantiate(smallPhotoPrefab, createPostScrollViewContent.transform);
            Image img = imgGameObject.GetComponent<Image>();
            img.sprite = s;
            Debug.Log(finalPath);
            await Task.Yield();
        }
        // foreach (var file in fileinfo)
        // {
        //     string finalPath = _selectedFilePath + file.Name;
        //     
        //     
        //     var imageBytes = File.ReadAllBytes(finalPath);
        //     Texture2D texture = new Texture2D(1,1);
        //     texture.LoadImage(imageBytes);
        //     Sprite s = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1f);
        //     GameObject imgGameObject = Instantiate(smallPhotoPrefab, createPostScrollViewContent.transform);
        //     Image img = imgGameObject.GetComponent<Image>();
        //     img.sprite = s;
        //     
        //     
        //     //_imagePath.Add(finalPath);
        //     Debug.Log(finalPath);
        //     await Task.Yield();
        // }
        // Debug.Log("File is saved");
        // BeginCreatingPhotoAsset();
    }

    public async Task CreatePhotoAssets(int pathNumber)
    {
        var imageBytes = File.ReadAllBytes( _imagePath[pathNumber]);
        Texture2D texture = new Texture2D(1,1);
        texture.LoadImage(imageBytes);
        Sprite s = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1f);
        GameObject imgGameObject = Instantiate(smallPhotoPrefab, createPostScrollViewContent.transform);
        Image img = imgGameObject.GetComponent<Image>();
        img.sprite = s;
        await Task.Yield();
    }

    public async void BeginCreatingPhotoAsset()
    {
        for (int i = 0; i < _imagePath.Count; i++)
        {
            await CreatePhotoAssets(i);
        }
    }
    
}
