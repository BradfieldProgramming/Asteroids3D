using System.Threading.Tasks;
using UnityEngine;

public class MissileCollision : MonoBehaviour
{
    public GameObject missile;
    public GameObject explosionEffect;

    public AudioSource source;
    public AudioClip enemyExplosion;

    public float missileRange;
    float countdown;
    bool hasExploded = false;

    void Start()
    {
        countdown = missileRange;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Destroy(missile);
            hasExploded = true;
        }
    }

    void OnCollisionEnter(Collision collisonInfo)
    {
        if (!hasExploded)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            source.Play();

            if (collisonInfo.collider.tag == "EnemyShip")
            {
                source.PlayOneShot(enemyExplosion);
            }

            //makes missile invisible and disables rigidbody & box colliders
            foreach (var rend in GetComponentsInChildren<Renderer>())
            {
                rend.enabled = false;
            }
            hasExploded = true;
            Destroy(missile, 3f);

            //this allows the sound to be played before object is destroyed
        }
    }
}
