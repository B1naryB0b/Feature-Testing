using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;

    public float movementDrainRate = 5;
    public float warpDrainRate = 20;

    PlayerMovement playerMovement;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        slider.value = slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.isMoving)
        {
            slider.value -= movementDrainRate * Time.deltaTime;
        }

        if (playerMovement.isWarp)
        {
            slider.value -= warpDrainRate * Time.deltaTime;
        }
    }
}
