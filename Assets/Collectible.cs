using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int score = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int Interact()
    {
        // Get the AudioSource attached to this coin
        var audio = GetComponent<AudioSource>();
        audio.Play();

        var renderer = GetComponent<Renderer>();
        renderer.enabled = false;

        // Remove the coin
        Destroy(gameObject, 1);
        return score;
    }
}
