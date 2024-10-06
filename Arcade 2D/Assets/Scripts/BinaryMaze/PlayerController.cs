using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed

    // Start is called before the first frame update
    void Start()
    {
    }


    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical"); 

        Vector2 movement = new Vector2(moveInput, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}


