using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class gameManager : MonoBehaviour
{
    public bool isGameActive;
    private int score;
    public GameObject titleScreen;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    public int health = 3;
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private HealthBar _healthBar;
    
    void Start()
    {
        _healthBar=GameObject.Find("HealthBar").GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameOver();
        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
           
        }
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        scoreText.gameObject.SetActive(true);
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
    }
    
}
