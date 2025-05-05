using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SegmentGenerator : MonoBehaviour
{
    [SerializeField] private GameObject segment;
    [SerializeField] private GameObject player;
    
    private List<GameObject> spawnedSegments = new List<GameObject>();
    private bool generateSegments = true;
    private int segmentCount = 0;
    private float zPos = 0;
    private float segmentLength = 50f; // Segment uzunluğunu buraya ayarlayın
    
    void Update()
    {
        if (generateSegments && segment != null)
        {
            StartCoroutine(SegmentGen());
        }
    }
    
    IEnumerator SegmentGen()
    {
        generateSegments = false;
        
        // Segment prefab'ının null olup olmadığını kontrol et
        if (segment != null)
        {
            GameObject newSegment = Instantiate(segment, new Vector3(0, 0, zPos), Quaternion.identity);
            spawnedSegments.Add(newSegment);
            zPos += segmentLength;
            segmentCount++;
        }
        else
        {
            Debug.LogError("Segment prefabı atanmamış! Lütfen Inspector'dan prefab atayın.");
        }
        
        // Oyuncunun hızına göre bekleme süresini ayarlayabilirsiniz
        yield return new WaitForSeconds(5); 
        
        generateSegments = true;
    }
    
    public void ResetGenerator()
    {
        // Oluşturulan tüm segmentleri temizle
        foreach (GameObject segment in spawnedSegments)
        {
            if (segment != null)
            {
                Destroy(segment);
            }
        }
        
        // Listeyi temizle
        spawnedSegments.Clear();
        
        // Değişkenleri sıfırla
        zPos = 0;
        segmentCount = 0;
        generateSegments = true;
        
        // İlk segmenti oluşturmak için Update tetiklenecek
    }
}