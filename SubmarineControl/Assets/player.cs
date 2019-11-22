using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
 // public  GameObject camera;
    public LayerMask hitLayers;
   public Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        //   camera = GameObject.Find("SubCamera");
        //    camera.SetActive(false);
      
    }

    void Start()
    {
        
    }

    public void ObjectClicker()
    {
        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 direction = new Vector3(0, 0, yRot) * 5.0f * Time.fixedDeltaTime;
        if (Input.GetMouseButtonDown(0))
        { 
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, hitLayers))
            {
                if (hit.transform != null)
                {
                    if(rb== hit.transform.GetComponent<Rigidbody>())
                    {
                        
                        Rotate(rb, direction);
                    }
                    /*
                    
                    hit.transform.Rotate(new Vector3(0, 0, yRot) *Time.deltaTime * 5);
                    */


                }
            }
        }
    }

    public void Rotate(Rigidbody rb, Vector3 direction)
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(direction));
    }
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))//If the player has left clicked
        {
            Vector3 mouse = Input.mousePosition;//Get the mouse Position
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);//Cast a ray to get where the mouse is pointing at
            RaycastHit hit;//Stores the position where the ray hit.
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, hitLayers))//If the raycast doesnt hit a wall
            {
                this.transform.position = hit.point;//Move the target to the mouse position
            }
        }
        */
        ObjectClicker();

    }
    // Update is called once per frame


    void OnTriggerEnter(Collider other)
    {
        if(other.name== "PeriscopeCol" || other.name == "PeriscopeCol2")
        {
            Debug.Log("Sa atins");
        //    camera.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "PeriscopeCol" || other.name == "PeriscopeCol2")
        {
          //  camera.SetActive(false);
        }
    }
}
