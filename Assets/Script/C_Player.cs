using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Player : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if (hit.collider.tag == "Stick")
            {
                C_Stick stick = hit.collider.GetComponent<C_Stick>();
                Debug.Log(string.Format("name: {0} : {1}",stick.name,stick.canTake() != null? stick.canTake() : "NONE"));
            }
            
        }
    }
}
