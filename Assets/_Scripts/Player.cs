using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour 
{

     public float moveSpeed;
     public float jumpSpeed;
     bool isGrounded;
    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        isGrounded = true;
    }
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        transform.Translate(moveSpeed*moveHorizontal*Time.deltaTime,0f,moveSpeed*moveVertical*Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, 1, 0) * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        isGrounded = true;
    }
}
