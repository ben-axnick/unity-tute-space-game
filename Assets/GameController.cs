using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject hazard;
    public GameObject player;
    public Text scoreText;
    public Text gameOverText;

    public float spawnValues;
    public float startWait;
    public float spawnWait;
    private bool gameOver;
    private int score;
   

	// Use this for initialization
	void Start () {
        score = 0;
        gameOver = false;
        StartCoroutine (SpawnWaves ());
	}

    private void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    public void NotifyAstroidDestroyed()
    {
        score++;
        RefreshUI();
    }

    public void NotifyPlayerDestroyed()
    {
        gameOver = true;
        RefreshUI();
    }

    void RefreshUI()
    {

        scoreText.text = "Score: " + score;

        gameOverText.text = gameOver ? "Game Over (R to restart)" : "";
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(startWait);

            for (int i = 0; i < 3; i++)
            {
                SpawnAsteroid();
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }

    void SpawnAsteroid()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues, spawnValues), 0.0f, 13.0f);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(hazard, spawnPosition, spawnRotation);
    }
}
