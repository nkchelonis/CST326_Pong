using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //private PlayerInput playerInput;
    private CharacterController characterController;
    private Vector2 moveDirection;
    
    
    private float maxSpeed = 10;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    
    
    public void Move(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(0, 0, moveDirection.x);
        move *= maxSpeed;
        move.y = Mathf.Clamp(move.y, -.1f, .1f);
        characterController.Move(move * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        
    }
    
}
