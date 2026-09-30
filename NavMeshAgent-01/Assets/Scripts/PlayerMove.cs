using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float speed = 10.0f;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        
        var movement = new Vector3(x, 0, z);

        //rb.AddForce(movement);
        rb.linearVelocity = movement * speed;
    }
}
