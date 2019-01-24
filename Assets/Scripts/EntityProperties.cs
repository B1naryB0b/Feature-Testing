using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityProperties
{

    public GameObject Entity;
    [Range(0, 10)]
    public float mass;
    [Range(0, 3)]
    public float gravitySpread;
    [HideInInspector]
    public float spread;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = Entity.GetComponent<Rigidbody>();
        rb.mass = mass;
    }
}
