using UnityEngine;

public class CollectibleRotate : MonoBehaviour
{
    [SerializeField] private int rotatespeed = 1;
    void Update()
    {
        transform.Rotate(0, rotatespeed, 0,Space.World);
    }
}
