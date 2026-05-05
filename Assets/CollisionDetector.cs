using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    int score = 0;
    int totalItemsToCollect = 2;

    // TASK 1: Touching the Coins
    void OnCollisionEnter(Collision collision)
    {
        // Check if we hit a coin
        if (collision.gameObject.name == "Coin")
        {
            score++;
            print($"Current Score: {score}");

            Destroy(collision.gameObject); 
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
}