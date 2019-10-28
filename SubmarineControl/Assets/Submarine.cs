using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class Submarine : MonoBehaviour {
    Rigidbody rb;
    public float speed = 1f;
    public float steerSpeed = 5f;
    public float movementThreshold = 10f;
    public float movementFactor;
    public float steeringFactor;

    public float waterLevel = 0f;
    public float floatTreshold = 2f;
    public float waterDensity = .125f;
    public float downForce = 1.5f;

    public float forceFactor;
    public Vector3 floatForce;  

	// Use this for initialization
	void Start () {
       rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	
    void Update()
    {
     //   rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y, Input.GetAxisRaw("Vertical")*speed);
    }

    void FixedUpdate()
    {
        Float();
    }
    
    void Float()
    {
        forceFactor = 1f - ((transform.position.y -waterLevel)/floatTreshold);
        if(forceFactor>0)
        {
            floatForce = -Physics.gravity *GetComponent<Rigidbody>().mass* (forceFactor - GetComponent<Rigidbody>().velocity.y * waterDensity);
            floatForce += new Vector3(0f, -downForce*GetComponent<Rigidbody>().mass, 0f);
            GetComponent<Rigidbody>().AddForceAtPosition(floatForce, transform.position);
        }
    }
    
}
