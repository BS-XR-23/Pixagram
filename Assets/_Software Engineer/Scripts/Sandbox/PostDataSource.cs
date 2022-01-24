using System;
using System.Collections;
using System.Collections.Generic;
using PolyAndCode.UI;
using UnityEngine;



public struct AccountInfo
{
   public string AccountName;
}

public class PostDataSource : MonoBehaviour, IRecyclableScrollRectDataSource
{
   [SerializeField] private RecyclableScrollRect recyclableScrollRect;
   [SerializeField] private int dataLength;

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
