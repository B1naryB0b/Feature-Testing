using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    float force;

    public float warpDrive;
    public float standardForce;

    public GameObject pointer;

    public float distFromMouse;

    [HideInInspector]
    public bool isWarp;

    [HideInInspector]
    public bool isMoving;
    [HideInInspector]
    public bool playerMovementEnabled;

    Rigidbody2D rb;
    Vector2 direction;

    void Start()
    {
        isWarp = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FaceMouse();
        Controls();

    }

    void FaceMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        //pointer.transform.rotation = new Quaternion(pointer.transform.rotation.x, pointer.transform.rotation.y, )
    }

    void Controls()
    {
        if (Input.GetMouseButton(1))
        {
            isWarp = true;
        }
        else
        {
            isWarp = false;
        }


        if ((direction.magnitude < distFromMouse) || !(Input.GetMouseButton(0) || Input.GetMouseButton(1)))
        {
            force = 0;
            isMoving = false;
        }
        else
        {
            force = isWarp ? warpDrive : standardForce;
            isMoving = true;
        }

        rb.AddForce(force * direction.normalized);
    }

}
