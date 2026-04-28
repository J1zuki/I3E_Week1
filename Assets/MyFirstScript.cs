using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    float moveSpeed = 0.05f;
    float rotateSpeed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print(transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // TASK 2: If object goes beyond limit, reverse direction
        if (transform.position.x > 10f)
        {
            moveSpeed = -0.05f;
            rotateSpeed = -2f;
        }

        if (transform.position.x < -10f)
        {
            moveSpeed = 0.05f;
            rotateSpeed = 2f;
        }

        // TASK 1: Move object continuously on X axis
        transform.position += new Vector3(moveSpeed, 0f, 0f);

        // TASK 3: Rotate object continuously
        transform.Rotate(0f, rotateSpeed, 0f);
    }
}
