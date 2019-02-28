using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollectionScript : MonoBehaviour
{

    public float collectionRate;

    GravityBehaviour gravity;

    public EntityResources player;
    public EntityResources[] resources;

    [HideInInspector]
    public GameObject playerObj;

    // Start is called before the first frame update
    void Awake()
    {
        //resources = GetComponent<EntityResources>();
        //player = GameObject.FindGameObjectWithTag("Player");

        playerObj = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(playerObj);
    }

    public void CollisionDetected(CollisionDetectionScript collision, EntityResources entityResources, GameObject resourceObject)
    {
        //resourceObject.
        Debug.Log("collected");
        Debug.Log(entityResources.entity);
        Destroy(resourceObject);
        gravity.Initialisation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
