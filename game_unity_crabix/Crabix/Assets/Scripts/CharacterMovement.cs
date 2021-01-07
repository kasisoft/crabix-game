using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterMovement : MonoBehaviour
{
    

    public float speed;
    public float gravity;
    public CharacterController characterController;
    
    
    private float currentGravity = 0f;
    private void grantrange(float value, float min, float max, string name)

    {
        bool ismin = value >= min;
        bool ismax = value <= max;
        bool valid = ismin && ismax;
        if (!valid)
        {

            throw new IndexOutOfRangeException($"bullshit {name}: {value} [{min}..{max}]");

        }
    }


    // Start is called before the first frame update
    void Start()
    {   
        grantrange(speed, 0, 100, "speed");
        grantrange(gravity, 40, 100, "gravity");
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 finalMovement = Movement() + ApplyGravity();
        characterController.Move(finalMovement * Time.deltaTime);
        
    }

    // Gravitation
    Vector3 ApplyGravity()
    
    {
        Vector3 gravityMovement = new Vector3(0, -currentGravity, 0);
        currentGravity += gravity * Time.deltaTime;

        if (characterController.isGrounded)
        {
            if (currentGravity > 1f)
            {
                currentGravity = 1f;
            }
                
        }

        return gravityMovement;

    }




    
    
    // Movement Methode Move
    Vector3 Movement()
    {
        Vector3 moveVector = Vector3.zero;

       
       // moveVector += transform.forward * Input.GetAxis("Vertical");
        moveVector += transform.right * Input.GetAxis("Horizontal");

        moveVector *= speed;

        return moveVector; 

    }

}
