using UnityEngine;

public class PaddleTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ball hit paddle");
        if (other.CompareTag("Ball"))
        {
            BallController ballController = other.GetComponent<BallController>();
            ballController.speed += 1;
            ballController.playerOneBall *= -1;
        }
    }
}
