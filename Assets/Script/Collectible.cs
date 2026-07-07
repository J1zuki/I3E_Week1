using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int score = 1;
    bool collected = false;

    public int Interact()
    {
        if (collected)
        {
            return 0;
        }

        collected = true;

        // Get the AudioSource attached to this coin
        var audio = GetComponent<AudioSource>();

        if (audio != null)
        {
            audio.Play();
        }

        var renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.enabled = false;
        }

        var collider = GetComponent<Collider>();

        if (collider != null)
        {
            collider.enabled = false;
        }

        // Remove the coin
        Destroy(gameObject, 1);

        return score;
    }
}