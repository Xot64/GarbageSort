using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Busket : MonoBehaviour
{
    public Transform spawner;
    private void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "Stick")
        {
            bool type = false; //0 - wood / 1 - plastic / 2 - glass / 3 - metal
            switch (other.GetComponent<C_Stick>().type)
            {
                case 0:
                    type = gameObject.tag == "Wood";
                    break;
                case 1:
                    type = gameObject.tag == "Plastic";
                    break;
                case 2:
                    type = gameObject.tag == "Glass";
                    break;
                case 3:
                    type = gameObject.tag == "Metal";
                    break;
            }
            if (type)
            {
                Debug.Log("OK");
                Destroy(other.gameObject);
            }
            else
            {
                Debug.Log("WRONG");
                other.GetComponent<Transform>().position = spawner.position;
            }

        }
    }
}
