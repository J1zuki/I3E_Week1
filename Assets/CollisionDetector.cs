using UnityEngine;
using UnityEngine.InputSystem;

public class CollisionDetector : MonoBehaviour
{
    /// <summary>
    /// Increment score by this value every time a coin is collected.
    /// </summary>
    public int scoreIncrement = 1; // Unity overwrites this value
    int score = 0;
    int totalItemsToCollect = 2;

    GameObject currentCoin;

    public float interactDistance = 5f;

    // TASK 1: Touching the Coins
    void OnCollisionEnter(Collision collision)
    {
        // Check if we hit a coin
        if (collision.gameObject.GetComponent<Collectible>() != null)
        {
            currentCoin = collision.gameObject;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Check if we hit a coin
        if (collision.gameObject.GetComponent<Collectible>() != null)
        {
            currentCoin = null;
        }
    }

    // TASK 2: Stepping on the Finish Plane
    void OnTriggerEnter(Collider other)
    {
        // Check if the trigger we entered is named "FinishPlane"
        if (other.gameObject.name == "FinishPlane")
        {
            if (score >= totalItemsToCollect)
            {
                print("You win!");
            }
            else
            {
                print($"Keep searching! You only have {score}/{totalItemsToCollect}");
            }
        }
    }

    void OnInteract(InputValue value)
    {
        // Stops the interact from running again when you release E
        if (!value.isPressed)
        {
            return;
        }

        GameObject targetObject = currentCoin;

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            targetObject = hit.collider.gameObject;
        }

        if (targetObject != null)
        {
            Collectible collectible = targetObject.GetComponent<Collectible>();

            if (collectible != null)
            {
                score += collectible.score;
                collectible.Interact();
                print($"Score: {score}");
                return;
            }

            Door door = targetObject.GetComponent<Door>(); 
            if (door != null) 
            { 
                door.Interact(); return; 
            }
        }

        // FIX: If raycast cannot hit the door from the other side,
        // check for a nearby door around the player.
        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, interactDistance);

        foreach (Collider nearbyObject in nearbyObjects)
        {
            Door nearbyDoor = nearbyObject.GetComponent<Door>();

            if (nearbyDoor != null)
            {
                nearbyDoor.Interact();
                return;
            }
        }
    }
}