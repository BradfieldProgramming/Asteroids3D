
using UnityEngine;

public class MediumAsteroidScript : MonoBehaviour
{
    public GameObject mediumAsteriod;
    public GameObject smallAsteroid;

    PointsAI points = null;

    public GameObject explosion;

    public AudioSource source;

    public Transform spawn0;
    public Transform spawn1;

    public int mediumAsteriod_Health;
    [SerializeField]private int counter = 0;

    void Start()
    {
        mediumAsteriod.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward) * Random.Range(12,20);
        points = GameObject.Find("Scene").GetComponent<PointsAI>();
    }

    void OnCollisionEnter(Collision collisonInfo)
    {
        if (collisonInfo.collider.tag == "Missile")
        {
            counter++;
        }
        if (counter == mediumAsteriod_Health)
        {
            mediumAsteriod.tag = "Untagged";
            points.score += 50;
            Instantiate(explosion, transform.position, transform.rotation);
            source.Play();

            mediumAsteriod.GetComponent<Renderer>().enabled = false;
            mediumAsteriod.GetComponent<Collider>().enabled = false;
            mediumAsteriod.GetComponent<Rigidbody>().detectCollisions = false;

            Instantiate(smallAsteroid, spawn0.position, spawn0.rotation * Quaternion.Euler(Random.Range(0, 180),Random.Range(0, 180),Random.Range(0, 180)));
            Instantiate(smallAsteroid, spawn1.position, spawn1.rotation * Quaternion.Euler(Random.Range(0, 180),Random.Range(0, 180),Random.Range(0, 180)));

            Destroy(mediumAsteriod, 3.5f);
        }
    }
}
