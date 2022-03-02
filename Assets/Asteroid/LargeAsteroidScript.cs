
using UnityEngine;

public class LargeAsteroidScript : MonoBehaviour
{
    public GameObject largeAsteroid;
    public GameObject mediumAsteriod;

    public GameObject explosion;

    PointsAI points = null;

    public GameObject scene;

    public AudioSource source;

    public Transform spawn0;
    public Transform spawn1;

    public int largeAsteroid_Health;
    [SerializeField]private int counter = 0;

    void Start()
    {
        largeAsteroid.GetComponent<Rigidbody>().velocity = transform.forward * Random.Range(4,7);
        points = GameObject.Find("Scene").GetComponent<PointsAI>();
    }

    void OnCollisionEnter(Collision collisonInfo)
    {
        if (collisonInfo.collider.tag == "Missile")
        {
            counter++;
        }
        if (counter == largeAsteroid_Health)
        {
            largeAsteroid.tag = "Untagged";
            points.score += 20;
            Instantiate(explosion, transform.position, transform.rotation);

            source.Play();
            largeAsteroid.GetComponent<Renderer>().enabled = false;
            largeAsteroid.GetComponent<Collider>().enabled = false;
            largeAsteroid.GetComponent<Rigidbody>().detectCollisions = false;

            Instantiate(mediumAsteriod, spawn0.position, spawn0.rotation * Quaternion.Euler(Random.Range(0,180),Random.Range(0,180),Random.Range(0,180)));
            Instantiate(mediumAsteriod, spawn1.position, spawn1.rotation * Quaternion.Euler(Random.Range(0,180),Random.Range(0,180),Random.Range(0,180)));

            Destroy(largeAsteroid, 4f);
        }
    }
}
