using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Movement speed

    void Update()
    {
        
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        
        Vector3 move = new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;

        
        transform.Translate(move);
    }
}
