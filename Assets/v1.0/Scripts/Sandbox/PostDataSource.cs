using System;
using System.Collections;
using System.Collections.Generic;
using PolyAndCode.UI;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public struct AccountInfo
{
   public string AccountName;
   // public int ColorR;
   // public int ColorG;
   // public int ColorB;
   // public int ColorA;
   public Sprite image;
}

public class PostDataSource : MonoBehaviour, IRecyclableScrollRectDataSource
{
   [SerializeField] private RecyclableScrollRect recyclableScrollRect;
   [SerializeField] private int dataLength;
   [SerializeField] private List<Sprite> images;

   private List<AccountInfo> _accountInfos = new List<AccountInfo>();

   private void Awake()
   {
      InitData();
      recyclableScrollRect.DataSource = this;
   }

   private void InitData()
   {
      if (_accountInfos != null)
      {
         _accountInfos.Clear();
      }

      for (int i = 0; i < dataLength; i++)
      {
         AccountInfo obj = new AccountInfo();
         obj.AccountName = i + "_Name";
         // obj.ColorR = Random.Range(0, 255);
         // obj.ColorG = Random.Range(0, 255);
         // obj.ColorB = Random.Range(0, 255);
         // obj.ColorA = 255;
         obj.image = images[Random.Range(0, images.Count)];
         _accountInfos.Add(obj);
      }
   }
   
   public int GetItemCount()
   {
      return _accountInfos.Count;
   }

   public void SetCell(ICell cell, int index)
   {
      var item = cell as PostCell;
      item.ConfigureCell(_accountInfos[index], index);
   }
}
