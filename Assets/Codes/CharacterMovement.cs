using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed;
    private float horizontal;
    private float vertical;
    
    

    
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            Vector3 move = new Vector3(horizontal, 0 , vertical);
            transform.position += move * moveSpeed * Time.deltaTime;
        }
    }
}
