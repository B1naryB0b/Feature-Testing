using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

  /*  public Transform playerTransform;
    public GameObject deathCharacter;
    public SwitchScript sw;
    public bool canRespawn;
    AudioSource[] sounds;
    AudioSource respSound;
    AudioSource backgroundMusic;


    [Range(0f, 0.1f)]
    public float fixedDeltaTimeScaler;

    [Range(0f, 10f)]
    public float delay;

    [Range(0f, 3f)]
    public float respawnTime;

    [Range(0f, 1f)]
    public float slowMoTime;

    [Range(0f, 1f)]
    public float slowMo;

    public Vector3 startPos;

    Rigidbody rb;
    Collider col;
    Renderer rend;
    PlayerMovement playerMov;

    bool isActive;

    GameObject destroyObj;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        isActive = true;
        canRespawn = true;

        rb = gameObject.GetComponent<Rigidbody>();
        col = gameObject.GetComponent<BoxCollider>();
        rend = gameObject.GetComponent<MeshRenderer>();
        playerMov = gameObject.GetComponent<PlayerMovement>();

        sounds = gameObject.GetComponents<AudioSource>();
        respSound = sounds[0];
        backgroundMusic = sounds[1];
  
    }


    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(DeathEnumerator());

        Instantiate(deathCharacter, playerTransform.position, Quaternion.identity);
        backgroundMusic.Stop();

        Time.timeScale = slowMo;
        Time.fixedDeltaTime = fixedDeltaTimeScaler * Time.timeScale;

        respSound.Play();

        StartCoroutine(Respawn());
        

    }

    IEnumerator DeathEnumerator()
    {
        yield return new WaitForSeconds(delay);
        isActive = false;
        PlayerComponents();
    }

    IEnumerator Respawn()
    {
        if (canRespawn != false)
        {
            yield return new WaitForSeconds(slowMoTime);

            Time.timeScale = 1;

            yield return new WaitForSeconds(respawnTime);

            // sw.activeSet = true;

            destroyObj = GameObject.Find("PlayerDead(Clone)");

            Destroy(destroyObj);

            gameObject.transform.position = new Vector3(startPos.x, startPos.y, startPos.z);
            isActive = true;
            PlayerComponents();
            backgroundMusic.Play();
        }
    }

    void PlayerComponents()
    {
        rb.useGravity = isActive;
        rb.isKinematic = !isActive;

        col.enabled = isActive;
        rend.enabled = isActive;
        playerMov.enabled = isActive;
    }*/

}
