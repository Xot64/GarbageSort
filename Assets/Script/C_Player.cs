using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Player : MonoBehaviour
{
    GameObject stick;

    // Start is called before the first frame update
    void Start()
    {
        stick = null;
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
                if (hit.collider.GetComponent<C_Stick>().canTake() == null)
                {
                    stick = hit.collider.gameObject;
                    stick.GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }
        if ((Input.GetButton("Fire1")) && (stick != null))
        {
            float height = 1.5f;
            Vector3 d = gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).direction;
            Vector3 p = gameObject.GetComponent<Transform>().position;
            float k = (height - p.y)/d.y;
            stick.GetComponent<Transform>().position = gameObject.GetComponent<Transform>().position + d * k;

        }
        if (Input.GetButtonUp("Fire1"))
        {
            stick.GetComponent<Rigidbody>().useGravity = true;
            stick = null;
        }
    }
}
