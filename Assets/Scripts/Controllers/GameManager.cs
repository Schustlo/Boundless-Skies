using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int goal;
    [SerializeField]
    private float GameTimerLimit = 60;
    [SerializeField]
    private UItext score, timer;
    [SerializeField]
    private AudioClip _music;
    private AudioSource audioSource;

    private int highScore = 0, gamescore = 0;

    void Awake()
    {
        if (Instance == null) 
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();

        StartGame();
    }
    

    public void StartGame()
    {
        gamescore = 0;
        score.UpdateText(gamescore.ToString());
        timer.UpdateText(GameTimerLimit.ToString());

        if (_music)
        {
            audioSource.clip = _music;
            audioSource.Play();
            audioSource.loop = true;
        }

        StartCoroutine(Countdown());
    }

    public void EndGame()
    {
        StopCoroutine(Countdown());
        if (gamescore > highScore)
            highScore = gamescore;
        audioSource.Stop();
        SceneManager.LoadScene(0);
    }

    public void UpdateScore(int amount)
    {
        gamescore += amount;
        score.UpdateText(gamescore.ToString());
        if (gamescore == goal)
        {
            EndGame();
        }
    }

    IEnumerator Countdown()
    {
        while (GameTimerLimit >= 0f)
        {
            yield return new WaitForSeconds(1f);
            GameTimerLimit--;
            timer.UpdateText(GameTimerLimit.ToString());
        }

        GameTimerLimit = 0f;
        timer.UpdateText(GameTimerLimit.ToString());
        EndGame();
    }
}