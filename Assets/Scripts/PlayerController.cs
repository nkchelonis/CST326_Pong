using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //private PlayerInput playerInput;
    private CharacterController characterController;
    private Vector2 moveDirection;
    
    private float maxZ = 3.5f;
    private float minZ = -3.5f;
    public float speed = 10;

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
        move *= speed;
        move.z = Mathf.Clamp(move.z, minZ, maxZ);
        characterController.Move(move * Time.deltaTime);
    }

    
    
}
