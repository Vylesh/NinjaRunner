using UnityEngine;
using TMPro; // TextMeshPro için gerekli namespace

public class CoinUIUpdater : MonoBehaviour
{
    public TMP_Text coinText; // Text yerine TMP_Text kullanıyoruz

    void Start()
    {
        if (coinText == null)
        {
            Debug.LogError("CoinUIUpdater: coinText atanmamış!");
        }
    }

    void Update()
    {
        if (coinText != null && MasterInfo.Instance != null)
        {
            coinText.text = "Coins: " + MasterInfo.Instance.GetCoins().ToString();
        }
    }
}