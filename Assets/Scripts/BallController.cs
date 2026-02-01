using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    public int playerOneBall = 1;
    public float speed = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerOneBall == 1)
        {
            Vector3 movement = new Vector3(speed, 0f, speed);
            rb.AddForce(movement*Time.deltaTime,ForceMode.VelocityChange);
        }
        else
        {
            Vector3 movement = new Vector3(-speed, 0f, -speed);
            rb.AddForce(movement*Time.deltaTime,ForceMode.VelocityChange);
        }
    }
}
