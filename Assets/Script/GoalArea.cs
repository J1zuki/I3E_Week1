using UnityEngine;

public class GoalAreaScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.instance.AddScore(1);
            Destroy(other.gameObject);
        }
    }
}