using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassScalingScript : MonoBehaviour
{
    public float forceThreshold;

    Rigidbody2D rb;
    float negligibilityDistance;

    // Start is called before the first frame update
    void Awake()
    {
        negligibilityDistance = Mathf.Sqrt(rb.mass / forceThreshold);
    }

}
