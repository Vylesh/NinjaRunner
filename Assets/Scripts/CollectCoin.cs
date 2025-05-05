using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] AudioSource coinFX;
    [SerializeField] int coinValue = 1;
    [SerializeField] int playerId = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Ses kaynağını güvenli bir şekilde çal
            if (coinFX != null && coinFX.gameObject != null && coinFX.gameObject.activeInHierarchy)
            {
                coinFX.Play();
            }
            
            // Coin ekleme işlemi
            if (MasterInfo.Instance != null)
            {
                MasterInfo.Instance.AddCoins(coinValue);
            }
            
            // Veritabanı işlemi
            DatabaseManager.SaveCoin(playerId, coinValue);
            
            // Coini deaktif et
            this.gameObject.SetActive(false);
        }
    }

    public void ResetCoin()
    {
        // Coini tekrar görünür yap
        this.gameObject.SetActive(true);
    }
}