using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //private PlayerInput playerInput;
    private CharacterController characterController;
    private Vector2 moveDirection;
    
    
    private float maxSpeed = 10;
    private Vector3 size;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        size = transform.localScale;
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
        if (other.CompareTag("SpeedPower"))
        {
            maxSpeed += 2;
        }
        else if (other.CompareTag("SizePower"))
        {
            size = new Vector3(size.x, size.y, size.z + 1);
            if (size.z > 5)
            {
                size.z = 5;
            }
            transform.localScale = size;
        }
    }
    
}
