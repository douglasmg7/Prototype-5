using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnRate = 1f;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive = true;
    public GameObject titleScreen;

    private int score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(targets[Random.Range(0, targets.Count)]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        textScore.text = "Score: " + score;
    }

    public void gameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int dificulty)
    {
        Debug.Log("dificulty: " + dificulty);
        spawnRate /= dificulty;
        Debug.Log("spawnRate: " + spawnRate);
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        score = 0;
        restartButton.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

}
