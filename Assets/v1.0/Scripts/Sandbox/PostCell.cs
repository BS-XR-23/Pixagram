using System.Collections;
using System.Collections.Generic;
using PolyAndCode.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PostCell : MonoBehaviour, ICell
{
    public TMP_Text accountName;
    public Image profilePicture;
    public Image postPicture;

    private int _cellIndex;

    public void ConfigureCell(AccountInfo accountInfo, int cellIndex)
    {
        _cellIndex = cellIndex;

        accountName.text = accountInfo.AccountName;
        postPicture.sprite = accountInfo.image;
        profilePicture.sprite = accountInfo.image;
        Texture texture = accountInfo.image.texture;
        print($"1.width:{texture.width},height:{texture.height}");
        float aspectRatio = texture.width /(float) texture.height;
        postPicture.GetComponent<AspectRatioFitter>().aspectRatio = aspectRatio;


    }
}
