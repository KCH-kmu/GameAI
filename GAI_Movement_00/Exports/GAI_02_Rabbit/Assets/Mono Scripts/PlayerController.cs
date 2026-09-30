using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxDistance = 0.7f;
    public float maxWaitTime = 0.3f;
    public float turnAngle = 30.0f;
    Rigidbody rb;

    float timer = 0.0f;
    float waitTime = 0.0f;
    void Start()
    {
        // Initialize the timer
        timer = 0.0f;
        waitTime = Random.Range(0.1f, maxWaitTime);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        if (timer > waitTime)
        {

            waitTime = Random.Range(0.1f, maxWaitTime);
            float stepDistance = Random.Range(0.1f, maxDistance);
            float randomTurn = Random.Range(-turnAngle, turnAngle);
            transform.Rotate(0, randomTurn, 0);

            //transform.Translate(0, 0, stepDistance);
            rb.MovePosition(transform.position + transform.forward * stepDistance);
            timer = 0.0f;

            if (transform.position.x > 15.0f || transform.position.x < -15.0f || transform.position.z > 15.0f || transform.position.z < -15.0f)
            {
                // If the player is out of bounds, move back to the center
                transform.position = new Vector3(0, transform.position.y, 0);
            }
        }
    }

}
