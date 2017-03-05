using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public TimerView timerView;
    public SpawnFlag spawner;

    public float time;

    bool gameOver;

    public bool disableUserInput { get; set; }

    Dictionary<string, int> player2Score;

    void Start()
    {
        spawner.SpawnNextFlag();

        player2Score = new Dictionary<string, int>();

        foreach (string player in Tag.Players)
        {
            player2Score.Add(player, 0);
        }
    }

	// Update is called once per frame
	void Update ()
    {
        if(!gameOver)
        {
            UpdateTimer();
        }
    }

    void UpdateTimer()
    {
        time -= Time.deltaTime;

        if (time < 0)
        {
            EndGame();
        }
        else
        {
            timerView.UpdateTimer(time);
        }
    }

    public void FlagTaken(string player)
    {
        player2Score[player] += 1; 
        spawner.SpawnNextFlag();
    }

    void EndGame()
    {
        gameOver = true;
        disableUserInput = true;
        Time.timeScale = 0;

        // Show a message when you win with the total points
    }

    void ResetGame()
    {
        // Fai un restart della scena
    }
}
