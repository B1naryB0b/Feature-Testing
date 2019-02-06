using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollectionScript : MonoBehaviour
{

    public float collectionRate;

    public EntityResources player;
    public EntityResources[] resources;

    [HideInInspector]
    public GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        //resources = GetComponent<EntityResources>();
        //player = GameObject.FindGameObjectWithTag("Player");

        playerObj = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(playerObj);
    }

    public void CollisionDetected(CollisionDetectionScript collision, EntityResources resourceObject)
    {
        //resourceObject.
        Debug.Log("collected");
        Destroy(resourceObject.entity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
