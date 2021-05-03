using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Spawn : MonoBehaviour
{
    public GameObject stick;
    public int firstSpawnNum = 15;
    float lastSpawn;
    float delaySpawn = 0.2f;
    int sticks;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((sticks < firstSpawnNum) && (Time.time > lastSpawn + delaySpawn))
        {
            lastSpawn = Time.time;
            sticks++;
            spawn();
        }
    }

    public void spawn()
    {

        Vector3 pos = GetComponent<Transform>().position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        Quaternion angle = Quaternion.Euler(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));
        GameObject newStick = Instantiate(stick, pos, angle);
        newStick.name = string.Format("Stick_{0}", sticks);
    }
}
