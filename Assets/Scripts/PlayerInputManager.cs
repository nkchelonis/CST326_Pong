using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    //[SerializeField] private Transform[] spawnPoint;
    void Start()
    {
        var player1 = PlayerInput.Instantiate(playerPrefab, controlScheme: "WASD", pairWithDevice: Keyboard.current);
        player1.transform.position = new Vector3(-10, 0, 0);
        
        var player2 =  PlayerInput.Instantiate(playerPrefab, controlScheme: "ARROWS",  pairWithDevice: Keyboard.current);
        player2.transform.position = new Vector3(10, 0, 0);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
