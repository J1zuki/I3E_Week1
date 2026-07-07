using UnityEngine;
using UnityEngine.InputSystem;

public class GiftBoxScript : MonoBehaviour
{
    public GameObject ballObject;

    private int pressCount = 0;
    private bool playerNear = false;

    private void Start()
    {
        ballObject.SetActive(false);
    }

    private void Update()
    {
        if (playerNear && Keyboard.current.eKey.wasPressedThisFrame)
        {
            pressCount++;
            Debug.Log("GiftBox Pressed: " + pressCount);

            if (pressCount >= 3)
            {
                ballObject.SetActive(true);
                Destroy(gameObject);

                Debug.Log("GiftBox destroyed. Ball spawned.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
            Debug.Log("Press E 3 times to destroy GiftBox.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
        }
    }
}