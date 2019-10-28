using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to get the center of mass of any GM create an empty object and attach it to model on the top
public class SubmarineController : MonoBehaviour {
   public Vector3 COM;    //center of mass
    Transform m_COM;
    Submarine sub;
    float verticalInput;
    float horizontalInput;

    void Start()
    {
        sub = new Submarine();
    }
    void Update()
    {
        Balance();
        Movement();
        Steer();
    }

    void Balance()
    {
        //control the balance of the sub
        if(!m_COM)
        {
            m_COM = new GameObject("COM").transform;
            m_COM.SetParent(transform);
            
        }
        m_COM.position = COM;
        GetComponent<Rigidbody>().centerOfMass = m_COM.position;
    }
    void Movement()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        sub.movementFactor = Mathf.Lerp(sub.movementFactor, verticalInput/2, Time.deltaTime / sub.movementThreshold);
        transform.Translate(0f, 0f, sub.movementFactor * sub.speed);
    }
    void Steer()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        sub.steeringFactor = Mathf.Lerp(sub.steeringFactor,horizontalInput/4 , Time.deltaTime / sub.movementThreshold);
        transform.Rotate(0f,sub.steeringFactor * sub.steerSpeed, 0f);
    }
}
