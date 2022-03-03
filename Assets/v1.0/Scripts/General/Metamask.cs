using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Metamask : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onSuccess;
    [SerializeField]
    private UnityEvent onFailure;
    async public void AddWalletAsync()
    {
        int timestamp = (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
        // set expiration time
        int expirationTime = timestamp + 60;
        // set message
        string message = expirationTime.ToString();
        // sign message
        string signature = await Web3Wallet.Sign(message);
        // verify account
        string account = await EVM.Verify(message, signature);
        int now = (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
        // validate
        if (account.Length == 42 && expirationTime >= now)
        {
            PlayerPrefs.SetString("Account", account);
            DialogBoxController.Instance.ShowDialog("Wallet Added Sucessfully", () =>
            {
               
            });
            onSuccess?.Invoke();
        }
        else
        {
            onFailure?.Invoke();
            DialogBoxController.Instance.ShowDialog("Failed To Add Wallet", () =>
            {

            });
        }

    }
}
