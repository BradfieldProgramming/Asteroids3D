
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public GameObject enemyShip;
    public GameObject playerTarget;
    public float speed;

    public GameObject scene;

    public AudioSource source;
    public AudioClip beep;
    public AudioClip closeBeep;
    public AudioClip closerBeep;

    private bool oneIsPlaying = false;
    private bool twoIsPlaying = false;
    private bool threeIsPlaying = false;

    public GameObject explodeEffect;
    public int lives;

    PointsAI points = null;

    public bool gameOver = false;

    void Start()
    {
        points = GameObject.Find("Scene").GetComponent<PointsAI>();
    }

    // Update is called once per frame
    void Update()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector3.Distance(transform.position, playerTarget.transform.position);
        if (distance > 300 && !oneIsPlaying)
        {
            source.PlayOneShot(beep);
            oneIsPlaying = true;
        }
        
        else if (distance <= 300 && distance > 150 && !twoIsPlaying)
        {
            beep = null;
            source.PlayOneShot(closeBeep);
            twoIsPlaying = true;
        }
        
        else if (distance <= 150 && !threeIsPlaying)
        {
            closeBeep = null;
            source.PlayOneShot(closerBeep);
            threeIsPlaying = true;
        }
        if (distance < 5)
        {
            gameOver = true;
        }
        transform.position = Vector3.MoveTowards(transform.position, playerTarget.transform.position, speed*Time.deltaTime);
        transform.right = playerTarget.transform.position - transform.position;
    }

    void OnCollisionEnter(Collision collisonInfo)
    {
        if (collisonInfo.collider.tag == "Missile")
        {
            lives--;
        }
        if (lives == 0)
        {
            points.score += 200;

            Instantiate(explodeEffect, transform.position, transform.rotation);

            enemyShip.GetComponent<Collider>().enabled = false;
            enemyShip.GetComponent<Renderer>().enabled = false;
            enemyShip.GetComponent<Rigidbody>().detectCollisions = false;
            enemyShip.GetComponent<AudioSource>().enabled = false;

            Destroy(enemyShip, 2f);
        }
    }
}
