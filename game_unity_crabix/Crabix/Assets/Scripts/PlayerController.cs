using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    private Vector3 movementVector;

    private Rigidbody rBody;
    private Animator anim;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        movementVector = new Vector3(h, 0, v);

        if (movementVector != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementVector), rotationSpeed);
        }
        
        

        Move();
    }

    private void Move()
    {
        movementVector = movementVector.normalized * moveSpeed * Time.deltaTime;
        rBody.MovePosition(transform.position + movementVector);

        bool isWalking = movementVector.x != 0f || movementVector.z != 0f;
        anim.SetBool("isWalking", isWalking);



    }

}
