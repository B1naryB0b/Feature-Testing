using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBehaviour : MonoBehaviour
{
    //setting the initial velocity of the gameobject
    public Vector2 initialVel;
    //Gravitational constant is used as one of the multipliers for gravitational field strength
    float gravitationalConstant;
    //All entities that exert a force on the object
    public GameObject[] entities;

    //Transform of all entities that are exerting a force on this gameobject
    Vector3[] entityTransform;
    //Magnitude of the force applied
    float forceMagnitude;
    //Direction of the force applied
    Vector2 forceDirection;

    //Rigidbody2D of the gameobject
    Rigidbody2D rb;
    //Rigidbody2D of other entities that aply a force on this object
    Rigidbody2D[] rbEntity;

    //The displacement of all other entities relative to this gameobject
    float[] displacement;
    //The size of the entities array
    int entityArrayLength;

    MassScalingScript massScaling;
    GameManagerScript gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gravitationalConstant = gameManager.GetComponent<GameManagerScript>().gravitationalConstant;

        //Calls a void function to initialise all of the entities
        InitialisationForEachEntity();

        //Sets the entityArrayLength to the length of the array of entities (Variable is used below)
        entityArrayLength = entities.Length;
        //Uses the entityArrayLength to determine the length of the arrays containing:
        //entity transforms
        //entity rigidbodies
        //entity displacements
        entityTransform = new Vector3[entityArrayLength];
        rbEntity = new Rigidbody2D[entityArrayLength];
        displacement = new float[entityArrayLength];

        //Initialises the Rigidbody2D of the gameobject
        rb = gameObject.GetComponent<Rigidbody2D>();

        //sets the initial velicity of the gameobject
        rb.velocity = initialVel;
      
        //Calls a void function to apply a force on the gameobject
        ForceForEachEntity();
       
    }

    // Update is called once per frame
    void Update()
    {
        ForceForEachEntity();
    }

    //Used to initialise the entities array
    void InitialisationForEachEntity()
    {
        //Finds the number of gameobjects in the scene
        int numberOfObjects = GameObject.FindObjectsOfType(typeof(GameObject)).Length;
        //Sets the size of the entities array to the number of gameobjects in the scene
        entities = new GameObject[numberOfObjects];
        //Assigns all of the gameobjects in the scene to a space within the entities array
        entities = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
    }
    
    //USed to calculate the direction and magnitude of the force applied
    //NOTE: THE MORE ENTITIES IN THE SCENE THE MORE CALCULATIONS NEED TO BE DONE
    //      THE INCREASE IN PERFORMANCE COST IS EXPONENTIAL
    void ForceForEachEntity()
    {
        //Sets the index for the entities to 0
        int i = 0;
        //Loops through every entity within the entities array
        foreach (GameObject entity in entities)
        {
            //Check to see if the gameobject in the entities array is in the entities layer
            if (entity.layer.Equals(9))
            {
                //Sets the position and rigidbody component of the entity at the point in the array index i
                entityTransform[i] = entity.transform.position;

                displacement[i] = (entityTransform[i] - gameObject.transform.position).magnitude;

                massScaling = entity.GetComponent<MassScalingScript>();

                if (displacement[i] < massScaling.negligibilityDistance)
                {
                    if (entity.GetComponent<Rigidbody2D>() != null)
                        rbEntity[i] = entity.GetComponent<Rigidbody2D>();

                    //Calculates the displacement from the entity by finding the magnitude of the difference of 2 vectors:
                    //Its current transform and the transform of the other entity
                    //Calculates the direction of the force
                    forceDirection = entityTransform[i] - gameObject.transform.position;

                    //Calculates the magnitude of the force using the equation Gm1m2/d^2
                    //Where: 
                    //m1 is the gameobject mass
                    //m2 is the mass of the other entity
                    //d is displacement
                    //and G is the gravitational constant that can be tweaked to adjust the strength of the gravitational field
                    forceMagnitude = gravitationalConstant * ((rb.mass * rbEntity[i].mass) / Mathf.Pow(displacement[i], 2));

                    //This condition is used to prevent NaN errors cuased by dividing by 0
                    //Checks to see if the displacement is not zero
                    //if the displacement is zero then the magnitude of the force is set to 0
                    if (displacement[i] == 0)
                        forceMagnitude = 0;

                    //Applies the for on the gameobjects rigidbody as a normalised direction multiplied by the magnitude of the force
                    rb.AddForce(forceDirection.normalized * forceMagnitude);
                    Debug.Log("Force Frame: " + Time.frameCount + " Force Acting: " + (forceDirection.normalized * forceMagnitude));

                    //increments the index
                    i += 1;
                }
               
            }
        }

    }

}
