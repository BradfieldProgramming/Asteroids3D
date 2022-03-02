
using UnityEngine;

public class MOAAScript : MonoBehaviour
{
    public GameObject MOAA;
    public GameObject largeAsteroid;
    public GameObject scene;

    public GameObject explosion;

    PointsAI points = null;

    public AudioSource source;

    //referencing spawn points of large asteroids
    public Transform spawn0;
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    public Transform spawn5;
    public Transform spawn6;

    public int MOAA_Health;

    //how many missles have struck the MOAA
    [SerializeField]private int counter = 0;

    void Start()
    {
        transform.Rotate(Random.Range(0, 180),Random.Range(0, 180),Random.Range(0, 180));
        MOAA.GetComponent<Rigidbody>().velocity = transform.forward * Random.Range(3,5);
        source = GetComponent<AudioSource>();

        points = GameObject.Find("Scene").GetComponent<PointsAI>();
    }
    
    void OnCollisionEnter(Collision collisonInfo)
    {
        if (collisonInfo.collider.tag == "Missile")
        {
            counter++;
        }
        if (counter == MOAA_Health)
        {
            MOAA.tag = "Untagged";
            points.score += 10;
            Instantiate(explosion, transform.position, transform.rotation);
            source.Play();
            MOAA.GetComponent<Renderer>().enabled = false;
            MOAA.GetComponent<Collider>().enabled = false;
            MOAA.GetComponent<Rigidbody>().detectCollisions = false;
            Instantiate(largeAsteroid, spawn0.position, spawn0.rotation * Quaternion.Euler(Random.Range(0,180),Random.Range(0,180),Random.Range(0,180)));
            Instantiate(largeAsteroid, spawn1.position, spawn1.rotation * Quaternion.Euler(Random.Range(0,180),Random.Range(0,180),Random.Range(0,180)));
            Instantiate(largeAsteroid, spawn2.position, spawn2.rotation * Quaternion.Euler(Random.Range(0,180),Random.Range(0,180),Random.Range(0,180)));
            Instantiate(largeAsteroid, spawn3.position, spawn3.rotation * Quaternion.Euler(Random.Range(0,180),Random.Range(0,180),Random.Range(0,180)));
            Instantiate(largeAsteroid, spawn4.position, spawn4.rotation * Quaternion.Euler(Random.Range(0,180),Random.Range(0,180),Random.Range(0,180)));
            Instantiate(largeAsteroid, spawn5.position, spawn5.rotation * Quaternion.Euler(Random.Range(0,180),Random.Range(0,180),Random.Range(0,180)));
            Instantiate(largeAsteroid, spawn6.position, spawn6.rotation * Quaternion.Euler(Random.Range(0,180),Random.Range(0,180),Random.Range(0,180)));
            Destroy(MOAA, 6f);
        }
    }
}
