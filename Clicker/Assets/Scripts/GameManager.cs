using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    private float spawnRate = 1f;

    public Button menuButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public List<GameObject> targets;
    public bool isGameActive;
    public GameObject difficultyScreen;
    public GameObject gameScreen;

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
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        menuButton.gameObject.SetActive(true);
    }
    public void goToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public void StartGame(int difficulty)
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        isGameActive = true;
        spawnRate /= difficulty;
        difficultyScreen.gameObject.SetActive(false);
        gameScreen.gameObject.SetActive(true);
    }
}
