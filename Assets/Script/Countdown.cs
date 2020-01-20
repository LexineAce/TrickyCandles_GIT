using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{

    public float timeLeft = 12.0f;
    public Text startText;
    public Text rText;
    public Text lostText;

    public AudioSource loseSource;
    public AudioClip musicLose;

    void Start()
    {
        loseSource.clip = musicLose;
        loseSource.PlayDelayed(12.4f);
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 10)
        {
            startText.text = timeLeft.ToString("0");
        }
        if (timeLeft < 0)
        {
            Destroy(GameObject.FindWithTag("Player"));
            lostText.text = "You Lose!";
            rText.text = "Press 'R' To Restart Or 'ESC' To Exit.";
            startText.text = "0";
        }
    }
}