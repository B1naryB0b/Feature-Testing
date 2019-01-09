using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] verticies;
    int[] triangles;
    public EntityProperties[] entityProperties;

    public int xSize = 20;
    public int zSize = 20;
    public float resolution;
    float y;


    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        /*StartCoroutine(*/
        CreateShape();//);
    }

    /*IEnumerator*/void CreateShape()
    {
        verticies = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                foreach (EntityProperties entity in entityProperties)
                {
                    y = entity.mass / Mathf.Pow((new Vector3(entity.Entity.transform.position.x, 0, entity.Entity.transform.position.z) - new Vector3(x * (1 / resolution), 0, z * (1 / resolution))).magnitude * entity.spread, 2) + 1;  
                }
                verticies[i] = new Vector3(x * (1 / resolution), -y, z * (1 / resolution));
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;

                //yield return new WaitForSeconds(.001f);
            }
            vert++;
        }

       
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = verticies;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    /*private void OnDrawGizmos()
    {

        if (verticies == null)
            return;
        for (int i = 0; i < verticies.Length; i++)
        {
            Gizmos.DrawSphere(verticies[i], .1f);
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        CreateShape();
        UpdateMesh();

    }
}
