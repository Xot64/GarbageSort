using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Spawn : MonoBehaviour
{
    public GameObject stick;
    public int firstSpawnNum = 15;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < firstSpawnNum; i++)
        {
            spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn()
    {
        Vector3 pos = GetComponent<Transform>().position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
        Quaternion angle = Quaternion.Euler(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));
        GameObject newStick = Instantiate(stick, pos, angle);
    }
}
