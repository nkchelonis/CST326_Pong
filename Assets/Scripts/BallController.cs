using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    public int playerOneBall = 1;
    public float speed = 5f;
    public float xMove = 5f;
    public float zMove = 5f;
    private int p1Score = 0;
    private int p2Score = 0;
    
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
            Vector3 movement = transform.position + new Vector3(xMove, 0f, zMove)*Time.deltaTime;
            transform.position = movement;
            
        }
        else
        {
            Vector3 movement = transform.position + new Vector3(-xMove, 0f, -zMove)*Time.deltaTime;
            transform.position = movement;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOneBall *= -1;
            if (xMove > 0)
            {
                xMove += 1;
            }
            else
            {
                xMove -= 1;
            }
            
            if (zMove > 0)
            {
                zMove += 1;
            }
            else
            {
                zMove -= 1;
            }
            
        }

        if (other.CompareTag("Top Wall") || other.CompareTag("Bottom Wall"))
        {
            zMove *= -1;
        }

        if (other.CompareTag("P1Goal"))
        {
            transform.position = new Vector3(0, 0, Random.Range(0,5));
            xMove = 2;
            zMove = 2;
            
            p2Score += 1;
            Debug.Log("Player 2 score!\nCurrent Score:\nPlayer 1: " + p1Score + "\nPlayer 2: " + p2Score);
            if (p2Score == 11)
            {
                Debug.Log("Game Over, Player 2 won!");
                p1Score = 0;
                p2Score = 0;
            }
        }
        else if (other.CompareTag("P2Goal"))
        {
            transform.position = new Vector3(0, 0, Random.Range(-5,0));
            xMove = 2;
            zMove = 2;
            
            p1Score += 1;
            Debug.Log("Player 1 score!\nCurrent Score:\nPlayer 1: " + p1Score + "\nPlayer 2: " + p2Score);
            if (p1Score == 11)
            {
                Debug.Log("Game Over, Player 1 won!");
                p1Score = 0;
                p2Score = 0;
            }
        }
        
    }

    
}
