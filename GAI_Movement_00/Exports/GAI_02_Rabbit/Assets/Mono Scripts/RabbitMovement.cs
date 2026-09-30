using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RabbitMovement : MonoBehaviour
{
    public float hopDistance = 1.0f;
    public float hopHeight = 0.5f;
    public float hopDuration = 0.4f;
    public float minWaitTime = 0.5f;
    public float maxWaitTime = 2.0f;
    public float turnAngle = 15.0f;
    public float movementLimit = 15.0f;

    Rigidbody rb;

    float timer = 0.0f;
    float waitTime = 0.0f;
    float hopTimer = 0.0f;

    bool isHopping = false;
    Vector3 hopStartPosition;
    Vector3 hopEndPosition;

    void Start()
    {
        // Initialize the variables in the same style as PlayerController.
        timer = 0.0f;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;

        // Give each rabbit a different starting time. Update() will also
        // generate a random turn immediately before the first hop.
        waitTime = Random.Range(minWaitTime, maxWaitTime);
    }

    void Update()
    {
        if (isHopping)
        {
            UpdateHop();
            return;
        }

        timer = timer + Time.deltaTime;

        if (timer > waitTime)
        {
            // Turn by a random angle before starting the next cycle.
            float randomTurn = Random.Range(-turnAngle, turnAngle);
            transform.Rotate(0.0f, randomTurn, 0.0f);

            timer = 0.0f;
            StartHop();
        }
    }

    void StartHop()
    {
        hopTimer = 0.0f;
        hopStartPosition = rb.position;
        hopEndPosition = hopStartPosition + transform.forward * hopDistance;
        isHopping = true;
    }

    void UpdateHop()
    {
        hopTimer = hopTimer + Time.deltaTime;
        float hopProgress = Mathf.Clamp01(hopTimer / hopDuration);

        Vector3 nextPosition = Vector3.Lerp(
            hopStartPosition,
            hopEndPosition,
            hopProgress);

        // Move upward and downward once while moving forward.
        nextPosition.y = nextPosition.y +
            Mathf.Sin(hopProgress * Mathf.PI) * hopHeight;

        rb.MovePosition(nextPosition);

        if (hopProgress >= 1.0f)
        {
            rb.position = hopEndPosition;
            isHopping = false;

            ReturnToCenterIfOutOfBounds();

            // Generate a new wait time after every completed hop.
            waitTime = Random.Range(minWaitTime, maxWaitTime);
            timer = 0.0f;
        }
    }

    void ReturnToCenterIfOutOfBounds()
    {
        if (rb.position.x > movementLimit ||
            rb.position.x < -movementLimit ||
            rb.position.z > movementLimit ||
            rb.position.z < -movementLimit)
        {
            // If the rabbit is out of bounds, move it back to the center.
            rb.position = new Vector3(0.0f, rb.position.y, 0.0f);
        }
    }
}
