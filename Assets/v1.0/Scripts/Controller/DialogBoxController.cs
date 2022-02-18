using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxController : MonoBehaviour
{
    public static DialogBoxController Instance;
    private GameObject _dialogBox;
    [SerializeField]
    private TextMeshProUGUI _messageBox;
    [SerializeField]
    private Button _action1;
    [SerializeField]
    private Button _action2;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _dialogBox = gameObject.transform.GetChild(0).gameObject;
    }
    public void ShowDialog(string message, Action action2=null, Action action1 = null, string action1Text="Cancel", string action2Text="Ok")
    {
        _dialogBox.SetActive(true);
        _messageBox.text = message;
        if (action1 != null)
        {
            _action1.GetComponentInChildren<TextMeshProUGUI>().text = action1Text;
            _action1.onClick.AddListener(action1.Invoke);
        }
        else
        {
            _action1.gameObject.SetActive(false);
        }
        _action2.GetComponentInChildren<TextMeshProUGUI>().text = action2Text;
        if (action2 != null) _action2.onClick.AddListener(action2.Invoke);
    }
}
