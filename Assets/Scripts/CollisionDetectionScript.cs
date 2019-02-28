using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionScript : MonoBehaviour
{
    ResourceCollectionScript resourceCollection;
    [HideInInspector]
    public EntityResources entityResource;

    void Start()
    {
        resourceCollection = GameObject.FindGameObjectWithTag("GameController").GetComponent<ResourceCollectionScript>();

        for (int j = 0; j < resourceCollection.resources.Length; j++)
        {
            if (resourceCollection.resources[j].entity.name == gameObject.name)
            {
                entityResource = resourceCollection.resources[j];
            }
        }

        Debug.Log(entityResource);
        Debug.Log(resourceCollection);
        Debug.Log(resourceCollection.playerObj);

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == resourceCollection.playerObj)
        {
            resourceCollection.CollisionDetected(this, entityResource, gameObject);
        }
    }

}
