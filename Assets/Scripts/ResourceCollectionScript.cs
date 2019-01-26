using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollectionScript : MonoBehaviour
{
    PlayerResources resources;

    // Start is called before the first frame update
    void Start()
    {
        resources = GetComponent<PlayerResources>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
