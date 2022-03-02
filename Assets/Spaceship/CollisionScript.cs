using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    Rigidbody rb;
    public int lives;
    public GameObject playerObject;

    MusicPlayer soundVolume = null;

    public GameObject playerDeath;

    public AudioSource source;
    public AudioClip collideSound;
    public AudioClip playerDestruction;

    public bool gameHasEnded = false;

    EnemyShip gameOver = null;

    public float timeElapsed = 0f;
    //referencing playerObject to be destroyed

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        soundVolume = GameObject.Find("Scene").GetComponent<MusicPlayer>();
    }

    void Update()
    {
        try
        {
            gameOver = GameObject.FindGameObjectWithTag("EnemyShip").GetComponent<EnemyShip>();
        }
        catch (NullReferenceException ex)
        {
            //do nothing and try again next update
        }
        
        if (gameOver != null)
        {
            if (gameOver.gameOver == true && !gameHasEnded)
            {
                DeathSequence();
            }
        }
        if (gameHasEnded)
        {
            timeElapsed += Time.deltaTime;
            
            if (timeElapsed > 4)
            {   
                soundVolume.source.volume -= Time.deltaTime/3;
            }
        }
        
    }

    void OnCollisionEnter(Collision collisonInfo)//method is called when collsion occurs
    {
        source.PlayOneShot(collideSound);
        lives--;
        if (lives == 0)
        {   
            DeathSequence();
        }   
    }
    void DeathSequence()
    {
        playerObject.GetComponent<InputControls>().enabled = false;
        rb.detectCollisions = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        playerObject.GetComponent<Collider>().enabled = false;
        playerObject.GetComponent<Renderer>().enabled = false;
        Instantiate(playerDeath, transform.position, transform.rotation);
        source.PlayOneShot(playerDestruction);
        gameHasEnded = true;
    }
}
