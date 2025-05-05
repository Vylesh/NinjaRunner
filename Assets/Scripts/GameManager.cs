using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private GameObject player;
    [SerializeField] private SegmentGenerator segmentGenerator;

    private Vector3 playerStartPosition;

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

    void Start()
    {
        if (player != null)
            playerStartPosition = player.transform.position;
    }

    public void RestartGame()
    {
        // Oyuncuyu başlangıç pozisyonuna geri döndür
        if (player != null)
            player.transform.position = playerStartPosition;

        // MasterInfo üzerindeki verileri sıfırla
        if (MasterInfo.Instance != null)
            MasterInfo.Instance.ResetCoins();

        // Segment Generator'ı sıfırla
        if (segmentGenerator != null)
            segmentGenerator.ResetGenerator();

        // Tüm coinleri aktifleştir
        CollectCoin[] allCoins = UnityEngine.Object.FindObjectsByType<CollectCoin>(FindObjectsSortMode.None);
        foreach(CollectCoin coin in allCoins)
        {
            coin.ResetCoin();
        }

        // Veritabanı kayıtlarını sıfırla (isteğe bağlı)
        DatabaseManager.ResetPlayerData(1);
    }
}