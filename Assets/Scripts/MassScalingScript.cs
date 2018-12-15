using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassScalingScript : MonoBehaviour
{
    public float forceThreshold;

    Rigidbody2D rb;
    [HideInInspector]
    public float negligibilityDistance;

    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        negligibilityDistance = Mathf.Sqrt(rb.mass / forceThreshold);
    }

}
