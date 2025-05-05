using UnityEngine;
using System;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public static void SaveCoin(int playerId, int coinValue)
    {
        // Mevcut coin kaydetme işlemleri
    }
    
    // Yeni eklenen metod
    public static void ResetPlayerData(int playerId)
    {
        // Oyuncu verilerini sıfırlama işlemi
        Debug.Log("Oyuncu " + playerId + " verileri sıfırlandı");
    }
}