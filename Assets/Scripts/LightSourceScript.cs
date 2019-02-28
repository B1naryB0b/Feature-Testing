using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourceScript : MonoBehaviour
{
    Mesh mesh;

    float displacement;
    float displacementVector;
    float length;
    float lengthVector;
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

            Vector3 distance = gameObject.transform.position - castingObject.transform.position;
            //displacement = (radius * radius) / (distance).magnitude;

            //float angle = Mathf.Acos(Mathf.Abs((gameObject.transform.position.y - castingObject.transform.position.y)) / distance.magnitude);

            //lengthVector = length * Mathf.Cos(angle) - displacement * Mathf.Sin(angle);
            //displacementVector = length * Mathf.Sin(angle) + displacement * Mathf.Cos(angle);

            float dist = (gameObject.transform.position - castingObject.transform.position).magnitude;

            /*
            length = Mathf.Sqrt((radius * radius) - (displacement * displacement));
            float radiusSqr = Mathf.Pow(radius, 2);
            float distanceSqr = Mathf.Pow(dist, 2);

            lengthVector = Mathf.Sqrt((Mathf.Pow(gameObject.transform.position.x - castingObject.transform.position.x, 2) + Mathf.Pow(gameObject.transform.position.y - castingObject.transform.position.y, 2)
                + radiusSqr - distanceSqr) / (1 + (radiusSqr / distanceSqr))) + castingObject.transform.position.x;

            displacementVector = (radius * (lengthVector - castingObject.transform.position.x) / dist) + castingObject.transform.position.y;*/

            float angle = 2 * Mathf.Asin(radius / dist) * 180/Mathf.PI;
            //Debug.Log(angle);
            lightVerts[i] = new Vector3(lengthVector + castingObject.transform.position.x, displacementVector + castingObject.transform.position.y, 0);
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
