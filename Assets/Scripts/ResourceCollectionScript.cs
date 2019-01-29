using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollectionScript : MonoBehaviour
{
    EntityResources resources;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        resources = GetComponent<EntityResources>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void CollisionDetected(CollisionDetectionScript collision)
    {
        if (collision.gameObject == player)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
