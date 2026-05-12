using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int score = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Collect()
    {
        Destroy(gameObject);
    }
}
