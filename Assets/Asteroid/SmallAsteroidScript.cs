
using UnityEngine;

public class SmallAsteroidScript : MonoBehaviour
{
    public GameObject smallAsteroid;

    public AudioSource source;

    public GameObject scene;

    public GameObject explosion;

    PointsAI points = null;

    void Start()
    {
        smallAsteroid.GetComponent<Rigidbody>().velocity = transform.forward * Random.Range(25, 50);
        points = GameObject.Find("Scene").GetComponent<PointsAI>();
    }

    void OnCollisionEnter(Collision collisonInfo)
    {
        if (collisonInfo.collider.tag == "Missile")
        {
            smallAsteroid.tag = "Untagged";
            points.score += 100;

            Instantiate(explosion, transform.position, transform.rotation);
            source.Play();

            smallAsteroid.GetComponent<Renderer>().enabled = false;
            smallAsteroid.GetComponent<Collider>().enabled = false;
            smallAsteroid.GetComponent<Rigidbody>().detectCollisions = false;

            Destroy(smallAsteroid, 3f);
        }
    }
}
