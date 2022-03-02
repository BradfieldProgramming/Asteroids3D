using Random = UnityEngine.Random;
using System;
using UnityEngine;

public class PointsAI : MonoBehaviour
{
    public GameObject[] spawns;

    public int score = 0;
    public int levelsCleared = 0;
    public GameObject[] asteroids;

    public GameObject largeAsteroid;
    public GameObject spaceShip;

    public AudioSource source;
    public AudioClip levelUp;

    float elapsedTime = 0f;

    void Start()
    {
        spawns = GameObject.FindGameObjectsWithTag("Spawn");

        score = 0;//temporary
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        
        asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

        if (asteroids.Length == 0)
        {
            source.PlayOneShot(levelUp);
            levelsCleared++;
            LoadNextLevel();
        }
        if (elapsedTime >= 2f)
        {
            elapsedTime = elapsedTime % 2f;
            SpawnSpaceships();
        }
    }
    void SpawnSpaceships()
    {
        int spawnRateVariable = Random.Range(0, 300000);
        if (spawnRateVariable <= score)
        {
            int spawnLocation = Random.Range(0, 8);
            GameObject enemyShip = Instantiate(spaceShip, spawns[spawnLocation].transform.position, transform.rotation*Quaternion.identity);
        } 
    }

    public int lowerBound;
    public int upperBound;
    public Vector3 randomSpawn;
    public Vector3 randomRotation;

    void LoadNextLevel()
    {
        lowerBound = score/1000;
        upperBound = score/700;
        int spawnAsteroids = Random.Range(lowerBound, upperBound);
        for (int x = 0; x < spawnAsteroids; x++)
        {
            randomSpawn = new Vector3(Random.Range(-200, 200), Random.Range(50, 450), Random.Range(-200, 200));
            randomRotation = new Vector3(Random.Range(0, 180), Random.Range(0,180), Random.Range(0,180));
            Instantiate(largeAsteroid, randomSpawn, transform.rotation*Quaternion.Euler(randomRotation));
        }
    }
}
