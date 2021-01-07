using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Test : MonoBehaviour
{

    public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(1 * Time.deltaTime, 0, 0);

    }
}
