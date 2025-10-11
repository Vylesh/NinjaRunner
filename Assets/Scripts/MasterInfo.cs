using UnityEngine;
using SQLite; // from sqlite-net
using System.IO;

public class MasterInfo : MonoBehaviour
{
    public static MasterInfo Instance;

    private int _coins;
    private string _dbPath;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _dbPath = Path.Combine(Application.persistentDataPath, "playerdata.sqlite");
            InitializeDatabase();
            LoadCoinsFromDB();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeDatabase()
    {
        using (var db = new SQLiteConnection(_dbPath))
        {
            db.CreateTable<PlayerProgress>();
            if (db.Find<PlayerProgress>("default_player") == null)
            {
                db.Insert(new PlayerProgress { PlayerID = "default_player", Coins = 0 });
            }
        }
    }

    private void LoadCoinsFromDB(string playerID = "default_player")
    {
        using (var db = new SQLiteConnection(_dbPath))
        {
            var player = db.Find<PlayerProgress>(playerID);
            _coins = player != null ? player.Coins : 0;
            if (player == null)
                SaveCoinsToDB(playerID);
        }
        Debug.Log($"Coins loaded from DB: {_coins}");
    }

    public int GetCoins() => _coins;

    private void SaveCoinsToDB(string playerID = "default_player")
    {
        using (var db = new SQLiteConnection(_dbPath))
        {
            db.InsertOrReplace(new PlayerProgress { PlayerID = playerID, Coins = _coins });
        }
        Debug.Log($"Coins saved to DB: {_coins}");
    }

    public void AddCoins(int amount)
    {
        if (amount < 0) return;
        _coins += amount;
        SaveCoinsToDB();
    }

    public void ResetCoins()
    {
        _coins = 0;
        SaveCoinsToDB();
    }
}

public class PlayerProgress
{
    [PrimaryKey]
    public string PlayerID { get; set; }
    public int Coins { get; set; }
}