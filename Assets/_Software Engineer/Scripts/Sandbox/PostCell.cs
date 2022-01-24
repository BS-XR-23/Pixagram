using System.Collections;
using System.Collections.Generic;
using PolyAndCode.UI;
using TMPro;
using UnityEngine;

public class PostCell : MonoBehaviour, ICell
{
    public TMP_Text accountName;

    private int _cellIndex;

    public void ConfigureCell(AccountInfo accountInfo, int cellIndex)
    {
        _cellIndex = cellIndex;

        accountName.text = accountInfo.AccountName;
    }
}
