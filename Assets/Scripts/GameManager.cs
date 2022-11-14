using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance => instance;
    public GameObject endCard;
    public TextMeshProUGUI scoreText;

    public int score;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        if(score < 0)
        {
            score = 0;
        }
    }

    public void ShowEndUI()
    {
        scoreText.text = "Score : " + score.ToString();
        endCard.SetActive(true);
    }

    public void LoadScene(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
