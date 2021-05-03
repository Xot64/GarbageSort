using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Stick : MonoBehaviour
{
    // Start is called before the first frame update
    public Material[] materials = new Material[6];
    int type; //0 - wood / 1 - plastic / 2 - glass / 3 - metal

    void Start()
    {
        type = Mathf.FloorToInt(Random.Range(0, 4));    
        switch (type)
        {
            case 0:
                //gameObject.GetComponent<MeshRenderer>().materials[0] = materials[Mathf.FloorToInt(Random.Range(0, 2))];
                gameObject.GetComponent<Renderer>().material = materials[Mathf.FloorToInt(Random.Range(0, 2))];
                break;
            case 1:
                //gameObject.GetComponent<MeshRenderer>().materials[0] = materials[Mathf.FloorToInt(Random.Range(2, 4))];
                gameObject.GetComponent<Renderer>().material = materials[Mathf.FloorToInt(Random.Range(2, 4))];
                break;
            case 2:
                //gameObject.GetComponent<MeshRenderer>().materials[0] = materials[4];
                gameObject.GetComponent<Renderer>().material = materials[4];
                break;
            case 3:
                //gameObject.GetComponent<MeshRenderer>().materials[0] = materials[5];
                gameObject.GetComponent<Renderer>().material = materials[5];
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
