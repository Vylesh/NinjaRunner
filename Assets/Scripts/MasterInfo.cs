using UnityEngine;
using TMPro;

public class MasterInfo : MonoBehaviour
{
    public static int coinCount = 0;
    [SerializeField] private GameObject coinDisplay;
    void Update()
    {
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "COINS : " + coinCount;
    }
}
