using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    public int playerOneBall = 1;
    public float speed = 5f;
    public float xMove = 5f;
    public float zMove = 5f;
    private int p1Score = 0;
    private int p2Score = 0;
    
    //sound things
    public AudioClip pop1;
    public AudioClip pop2;
    public AudioClip pop3;
    private AudioSource audioSource;

    //score things
    public TextMeshProUGUI scoreBoard;
    public TextMeshProUGUI winText;
    
    //power up things
    public GameObject speedPower;
    public GameObject sizePower;
    
    //background things
    public GameObject background;
    public Material tieBackground;
    public Material p1Background;
    public Material p2Background;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        winText.enabled = false;
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
            
            //play sound
            PlaySound();
            
            
            //increase speed
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
            xMove = speed;
            zMove = speed;
            
            p2Score += 1;
            //Debug.Log("Player 2 score!\nCurrent Score:\nPlayer 1: " + p1Score + "\nPlayer 2: " + p2Score);
            scoreBoard.text = $"{p1Score}  ||  {p2Score}";
            if (p2Score == 11)
            {
                //Debug.Log("Game Over, Player 2 won!");
                p1Score = 0;
                p2Score = 0;
                winText.text = "Player 2 won!";
                winText.enabled = true;
                Invoke("HideWinText", 3f);
            }
            
            //power up trigger
            if (p1Score%3 == 0 || p2Score%3 == 0)
            {
                //spawn speed power up on losing side
                if (p1Score > p2Score)
                {
                    Instantiate(speedPower, new Vector3(10,0,3), Quaternion.Euler(0,0,0));
                }
                else if (p2Score > p1Score)
                {
                    Instantiate(speedPower, new Vector3(-10,0,3), Quaternion.Euler(0,0,0));
                }
            }
            else if (p1Score % 2 == 0 || p2Score % 2 == 0)
            {
                //spawn size power up on losing side
                if (p1Score > p2Score)
                {
                    Instantiate(sizePower, new Vector3(10,0,3), Quaternion.Euler(0,0,0));
                }
                else if (p2Score > p1Score)
                {
                    Instantiate(sizePower, new Vector3(-10,0,3), Quaternion.Euler(0,0,0));
                }
            }
        }
        else if (other.CompareTag("P2Goal"))
        {
            transform.position = new Vector3(0, 0, Random.Range(-5,0));
            xMove = speed;
            zMove = speed;
            
            p1Score += 1;
            //Debug.Log("Player 1 score!\nCurrent Score:\nPlayer 1: " + p1Score + "\nPlayer 2: " + p2Score);
            scoreBoard.text = $"{p1Score}  ||  {p2Score}";
            if (p1Score == 11)
            {
                //Debug.Log("Game Over, Player 1 won!");
                p1Score = 0;
                p2Score = 0;
                winText.text = "Player 1 won!";
                winText.enabled = true;
                Invoke("HideWinText", 3f);
            }
            
            //power up trigger
            PowerUp();
            
        }

        UpdateUI();
    }

    void HideWinText()
    {
        winText.enabled = false;
        UpdateUI();
    }

    void PlaySound()
    {
        int popDecision = Random.Range(1, 3);
        if (Math.Abs(xMove) < 10)
        {
            if (popDecision == 1)
            {
                audioSource.PlayOneShot(pop1);
            }
            else if (popDecision == 2)
            {
                //lowest pitch pop
                audioSource.PlayOneShot(pop2);
            }
        }
        else
        {
            //pitch options are the higher two at faster speed 
            if (popDecision == 1)
            {
                audioSource.PlayOneShot(pop1);
            }
            else if (popDecision == 2)
            {
                audioSource.PlayOneShot(pop3);
            }
        }
    }

    void PowerUp()
    {
        if (p1Score%3 == 0 || p2Score%3 == 0)
        {
            //spawn speed power up on losing side
            if (p1Score > p2Score)
            {
                Instantiate(speedPower, new Vector3(10,0,3), Quaternion.Euler(0,0,0));
            }
            else if (p2Score > p1Score)
            {
                Instantiate(speedPower, new Vector3(-10,0,3), Quaternion.Euler(0,0,0));
            }
        }
        else if (p1Score % 2 == 0 || p2Score % 2 == 0)
        {
            //spawn size power up on losing side
            if (p1Score > p2Score)
            {
                Instantiate(sizePower, new Vector3(10,0,3), Quaternion.Euler(0,0,0));
            }
            else if (p2Score > p1Score)
            {
                Instantiate(sizePower, new Vector3(-10,0,3), Quaternion.Euler(0,0,0));
            }
        }
    }

    void UpdateUI()
    {
        if (p1Score > p2Score)
        {
            //Player 1 ahead
            scoreBoard.color = Color.hotPink;
            background.GetComponent<Renderer>().material = p1Background;
        }
        else if(p2Score > p1Score)
        {
            //Player 2 ahead
            scoreBoard.color = Color.mediumPurple;
            background.GetComponent<Renderer>().material = p2Background;
        }
        else
        {
            //Tie
            scoreBoard.color = Color.white;
            background.GetComponent<Renderer>().material = tieBackground;
        }
    }
    
}
