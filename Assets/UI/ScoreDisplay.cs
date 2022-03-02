
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    PointsAI points = null;
    PointsAI levelsCleared = null;
    CollisionScript lives = null;
    CollisionScript gameHasEnded = null;

    public Text scoreText;
    public Text asteroidNumber;
    public Text levelsPassed;
    public Text livesLeft;
    public Text gameOverEndScreen;

    public GameObject[] numberOfAsteroids;

    // Start is called before the first frame update
    void Start()
    {
        gameOverEndScreen.enabled = false;
        points = GameObject.Find("Scene").GetComponent<PointsAI>();
        levelsCleared = GameObject.Find("Scene").GetComponent<PointsAI>();
        lives = GameObject.Find("PlayerObject").GetComponent<CollisionScript>();
        gameHasEnded = GameObject.Find("PlayerObject").GetComponent<CollisionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        numberOfAsteroids = GameObject.FindGameObjectsWithTag("Asteroid");

        scoreText.text = points.score.ToString();
        levelsPassed.text = $"Levels Complete: {levelsCleared.levelsCleared.ToString()}";
        asteroidNumber.text = $"Asteroids Left: {numberOfAsteroids.Length.ToString()}";
        livesLeft.text = $"Health: {lives.lives.ToString()}";

        if (gameHasEnded.gameHasEnded == true)
        {
            gameOverEndScreen.enabled = true;
        }
    }
}
