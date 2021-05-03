using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_NewMesh : MonoBehaviour
{
    public Mesh stickMesh;
    Vector3Int vS = new Vector3Int(3, 2, 10);
    Vector3 lS = new Vector3(1f, 0.2f, 0.05f);
    // Start is called before the first frame update
    void Start()
    {
        int N = vS.x * vS.y * vS.z;
        Vector3[] newVert = new Vector3[N];
        Vector3[] newNorm = new Vector3[N];
        Vector2[] newUV = new Vector2[N];

        //create Verticles
        int i = 0;
        Vector3 lines = new Vector3(lS.x / (vS.x - 1), lS.y / (vS.y - 1), lS.z / (vS.z - 1));
        int[] newTriangles = new int[N];
        for (int y = 0; y < vS.y; y++)
        {
            for (int z = 0; z < vS.z; z++)
            {
                for (int x = 0; x < vS.x; x++)
                {
                    newVert[i] = new Vector3((-lS.x / 2 + x * lines.x), (-lS.y / 2 + y * lines.y), (-lS.z / 2 + z * lines.z));
                    newNorm[i] = y == 0 ? Vector3.up : -Vector3.up;
                    i++;
                }
            }
        }

        //create Triangles
        i = 0;
        int s = vS.x * vS.z;
        for (int z = 0; z < vS.z - 1; z++)
        {
            for (int x = 0; x < vS.x - 1; x++)
            {
                newTriangles[i + 0] = vS.z * x + z;
                newTriangles[i + 1] = newTriangles[i + 0] + 1;
                newTriangles[i + 2] = newTriangles[i + 0] + vS.z;
                i += 3;
                newTriangles[i + 0] = newTriangles[i - 2];
                newTriangles[i + 1] = newTriangles[i - 1];
                newTriangles[i + 2] = newTriangles[i + 1] + 1;
                i += 3;
                newTriangles[i + 0] = (vS.x * vS.z) + newTriangles[i - 6];
                newTriangles[i + 1] = newTriangles[i + 0] + 1;
                newTriangles[i + 2] = newTriangles[i + 0] + vS.x;
                i += 3;
                newTriangles[i + 0] = newTriangles[i - 2];
                newTriangles[i + 1] = newTriangles[i - 1];
                newTriangles[i + 2] = newTriangles[i + 1] + 1;
                i += 3;
            }
        }
        for (int z = 0; z < vS.z - 1; z++)
        {
            newTriangles[i + 0] = z;
            newTriangles[i + 1] = newTriangles[i + 0] + s;
            newTriangles[i + 2] = newTriangles[i + 1] + 1;
            i += 3;
            newTriangles[i + 0] = newTriangles[i - 3] + 1;
            newTriangles[i + 1] = newTriangles[i + 0] - 1 + s;
            newTriangles[i + 2] = newTriangles[i + 1] + 1;
            i += 3;
            newTriangles[i + 0] = newTriangles[i - 6] + (vS.x - 1) * vS.z;
            newTriangles[i + 1] = newTriangles[i + 0] + s;
            newTriangles[i + 2] = newTriangles[i + 1] + 1;
            i += 3;
            newTriangles[i + 0] = newTriangles[i - 3] + 1;
            newTriangles[i + 1] = newTriangles[i + 0] - 1 + s;
            newTriangles[i + 2] = newTriangles[i + 1] + 1;
            i += 3;
        }
        for (int x = 0; x < vS.x - 1; x++)
        {
            newTriangles[i + 0] = x * vS.z;
            newTriangles[i + 1] = newTriangles[i + 0] + s;
            newTriangles[i + 2] = newTriangles[i + 1] + 1;
            i += 3;
            newTriangles[i + 0] = newTriangles[i - 3] + 1;
            newTriangles[i + 1] = newTriangles[i + 0] - 1 + s;
            newTriangles[i + 2] = newTriangles[i + 1] + 1;
            i += 3;
            newTriangles[i + 0] = newTriangles[i - 6] + (vS.z - 1) * vS.x;
            newTriangles[i + 1] = newTriangles[i + 0] + s;
            newTriangles[i + 2] = newTriangles[i + 1] + 1;
            i += 3;
            newTriangles[i + 0] = newTriangles[i - 3] + 1;
            newTriangles[i + 1] = newTriangles[i + 0] - 1 + s;
            newTriangles[i + 2] = newTriangles[i + 1] + 1;
            i += 3;
        }
    }
}
