using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Door : MonoBehaviour
{
    public bool left;
    public float force;
    // Update is called once per frame
    void Update()
    {
        float ang = Mathf.Clamp(transform.eulerAngles.z, left ? -90 : 0, left ? 0 : 90);
        transform.eulerAngles = new Vector3(0, 0, ang);
        GetComponent<Rigidbody>().AddTorque(0, 0, force);    
    }
}
