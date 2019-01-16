using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourceScript : MonoBehaviour
{
    Mesh mesh;

    float displacement;
    float length;
    float/*[]*/ radius;
    Vector3[] lightVerts;

    public GameObject/*[]*/ castingObject;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        radius = castingObject.GetComponent<CircleCollider2D>().radius;
        //castingObject = new GameObject[1];

        /*for (int i = 0; i <= castingObject.Length; i++)
        {
            radius[i] = castingObject[i].GetComponent<CircleCollider2D>().radius;
            Debug.Log(radius[i]);

        }*/
        //GenerateLightMesh();
    }

    void GenerateLightMesh()
    {
        lightVerts = new Vector3[2];

        for (int i = 0; i <= lightVerts.Length - 1; i++)
        {
           
            displacement = (radius * radius) / (gameObject.transform.position - castingObject.transform.position).magnitude;
            length = Mathf.Sqrt((radius * radius) - (displacement * displacement));

            lightVerts[i] = new Vector3(length + castingObject.transform.position.x, displacement + castingObject.transform.position.y, 0);
        }

        
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = lightVerts;

        mesh.RecalculateNormals();

    }

    private void OnDrawGizmos()
    {

        if (lightVerts == null)
            return;
        for (int i = 0; i < lightVerts.Length; i++)
        {
            Gizmos.DrawSphere(lightVerts[i], .1f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        GenerateLightMesh();
        UpdateMesh();
    }
}
