using UnityEngine;
using System.IO;

public class DatabasePathChecker : MonoBehaviour
{
    void Start()
    {
        // SQLite eklentisi için gerekli dosyaları kontrol et
        Debug.Log("Uygulama Veri Yolu: " + Application.persistentDataPath);
        Debug.Log("Uygulama Dizini: " + Application.dataPath);
        
        // DLL dosyalarının varlığını kontrol et
        string pluginsPath = Path.Combine(Application.dataPath, "Plugins");
        Debug.Log("Mono.Data.Sqlite.dll var mı: " + File.Exists(Path.Combine(pluginsPath, "Mono.Data.Sqlite.dll")));
        Debug.Log("sqlite3.dll var mı: " + File.Exists(Path.Combine(pluginsPath, "sqlite3.dll")));
    }
}