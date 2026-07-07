using UnityEngine;
using UnityEngine.InputSystem;

public class BallScript : MonoBehaviour
{
    public Rigidbody ballRigidbody;
    public float pushForce = 8f;

    private bool playerNear = false;

    private void Update()
    {
        if (playerNear && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Vector3 direction = transform.parent.position - Camera.main.transform.position;
            direction.y = 0;

            ballRigidbody.AddForce(direction.normalized * pushForce, ForceMode.Impulse);

            Debug.Log("Ball pushed.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
            Debug.Log("Press E to push the Ball.");
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