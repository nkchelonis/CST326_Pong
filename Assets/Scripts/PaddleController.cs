using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Rendering;

public class PaddleController : MonoBehaviour
{

    public int playerId;
    //speed at which the paddle moves
    public float speed = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerId == 1)
        {
            //movement for player 1, uses w and s keys
            if (Keyboard.current.wKey.isPressed)
            {
                //moves forwards
                Vector3 movement = new Vector3(0, 0, speed)*Time.deltaTime;
                this.transform.Translate(movement);
            }
            else if (Keyboard.current.sKey.isPressed)
            {
                //moves backwards
                Vector3 movement = new Vector3(0, 0, -speed)*Time.deltaTime;
                this.transform.Translate(movement);
            }
        }
        else if (playerId == 2)
        {
            //movement for player 2, uses up and down arrows
            if (Keyboard.current.upArrowKey.isPressed)
            {
                //moves forwards
                Vector3 movement = new Vector3(0, 0, speed)*Time.deltaTime;
                this.transform.Translate(movement);
            }
            else if (Keyboard.current.downArrowKey.isPressed)
            {
                //moves backwards
                Vector3 movement = new Vector3(0, 0, -speed)*Time.deltaTime;
                this.transform.Translate(movement);
            }
        }
        
    }
}
