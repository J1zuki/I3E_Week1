using UnityEngine;

public class GiftBox : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform ballSpawnPoint;

    private int pressCount = 0;
    private bool playerNear = false;

    private void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            pressCount++;
            Debug.Log("Pressed E: " + pressCount);

            if (pressCount >= 3)
            {
                SpawnBall();
                Destroy(gameObject);
            }
        }
    }

    private void SpawnBall()
    {
        Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
            Debug.Log("Press E 3 times to open the GiftBox.");
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