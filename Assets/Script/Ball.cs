using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float pushForce = 8f;

    private bool playerNear = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            Vector3 pushDirection = transform.position - Camera.main.transform.position;
            pushDirection.y = 0f;

            rb.AddForce(pushDirection.normalized * pushForce, ForceMode.Impulse);
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