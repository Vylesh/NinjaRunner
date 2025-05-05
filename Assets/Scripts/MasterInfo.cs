using UnityEngine;

public class MasterInfo : MonoBehaviour
{
    public static MasterInfo Instance;
    
    [SerializeField] private int coins = 0;
    
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
    
    public void AddCoins(int amount)
    {
        coins += amount;
    }
    
    public int GetCoins()
    {
        return coins;
    }
    
    // Yeni eklenen metod
    public void ResetCoins()
    {
        coins = 0;
    }
}