using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionScript : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        transform.parent.GetComponent<ResourceCollectionScript>().CollisionDetected(this);
    }

}
