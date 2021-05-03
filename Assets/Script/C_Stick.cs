using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Stick : MonoBehaviour
{
    // Start is called before the first frame update
    public Material[] materials = new Material[6];
    public int type; //0 - wood / 1 - plastic / 2 - glass / 3 - metal
    public Transform dot;

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

    public string canTake()
    {
        
        int myLayer = gameObject.layer;
        gameObject.layer = 2;
        Vector3Int s = new Vector3Int(3, 2, 11);
        int ss = s.x * s.y * s.z;
        Vector3[] dots = new Vector3[ss];
        int n = 0;
        //dots = gameObject.GetComponent<MeshFilter>().mesh.vertices;
        for (float y = 0; y < s.y; y++)
        {
            for (float z = 0; z < s.z; z++)
            {
                for (float x = 0; x < s.x; x++)
                {
                    Vector3 d = new Vector3(x / ((float)s.x - 1f), y / ((float)s.y - 1f), z / ((float)s.z - 1f));


                    dots[n] = new Vector3(-0.5f + d.x, -0.5f + d.y, -0.5f + d.z);
                    n++;
                }
            }
        }
        string collide = null;
        for (int i = 0; i < dots.Length; i++)
        {
            dot.localPosition = dots[i];
            Vector3 b = dot.position + Vector3.up / 10f;
            Vector3 d = dot.position + Vector3.up * 10f;
            Ray ray = new Ray(dot.position, 2*Vector3.up);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if (hit.collider != null)
            {
                collide = hit.collider.name;
            }
        }
        gameObject.layer = myLayer;
        return collide;
    }
}
