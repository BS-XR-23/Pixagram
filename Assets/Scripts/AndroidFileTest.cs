using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AndroidFileTest : MonoBehaviour
{
    public string m_selectedFilePath;

    public string imagePath;

    public List<string> fileNames;

    public Image img;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetRecentFile()
    {
        // m_selectedFilePath = Application.persistentDataPath;
        // Debug.Log(m_selectedFilePath);

        m_selectedFilePath = "/storage/emulated/0/DCIM/Camera/";
        
        // Debug.Log("Function is called");
        //
        //
        DirectoryInfo dataDir = new DirectoryInfo (m_selectedFilePath);
        // var AllImage = dataDir.EnumerateFiles("*.png", SearchOption.AllDirectories);
        //var AllImages = Directory.EnumerateFiles(m_selectedFilePath, "*.png", SearchOption.AllDirectories);
        
        try {
            FileInfo[] fileinfo = dataDir.GetFiles ();
            for (int i=0; i<fileinfo.Length; i++) {
                string name=fileinfo [i].Name;
                //var replacement = new{Find="Autoconnected Player ",Replace=""};
                //string[] charsToTrim = { "Autoconnected", "Player" };
                //int index1 = name.IndexOf("Autoconnected Player ");
                //string finalName = name.Replace(replacement.Find, replacement.Replace);
                fileNames.Add(name);
                //name = name.Replace("Autoconnected Player ", "");
                //Debug.Log(name);
            }
        }
        catch (System.Exception e) 
        {
            Debug.Log (e);
        }
        
        foreach (string fileName in fileNames)
        {
            Debug.Log(fileName);
        }
        // if (AllImage.Count() <= 0)
        // {
        //     Debug.Log("All Image is empty");
        // }
        //
        //
        // foreach (var image in AllImage)
        // {
        //     Debug.Log(image.Name);
        // }
    }

    public void ShowThePicture()
    {
        imagePath = "/storage/emulated/0/DCIM/Camera/Arko.jpg";
        if( File.Exists( imagePath ) )

        {
            var imageBytes = File.ReadAllBytes( imagePath );
            Texture2D texture = new Texture2D(1,1);
            texture.LoadImage(imageBytes);
            Sprite s = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1f);
            img.sprite = s;
            Debug.Log("Image is loaded");
        }
    }
}
