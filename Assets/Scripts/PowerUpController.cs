using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotateAngle = 30*Time.deltaTime;
        transform.Rotate(rotateAngle,0,0);
    }
}
