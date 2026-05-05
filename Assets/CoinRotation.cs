using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 0.15f));
    }
}