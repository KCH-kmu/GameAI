using UnityEngine;

public class SimplePlayerControl : MonoBehaviour
{
    public float speed = 1000;
    private Rigidbody rigidBody;
    private Vector3 newVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float zMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        newVelocity = new Vector3(xMove, 0, zMove);
    }

    void FixedUpdate()
    {
        rigidBody.linearVelocity = newVelocity;
    }
}
