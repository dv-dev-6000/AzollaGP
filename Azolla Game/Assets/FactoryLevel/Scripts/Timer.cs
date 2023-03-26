using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public bool timeOn = false;
    public Text timerTxt;

    // Start is called before the first frame update
    void Start()
    {
        timeOn = true;
    }

    // Player dies if time runs out, get an instance of gameover screen
    private void PlayerDied()
    {
        AreaManager.instance.GameOver();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeOn)
        {
            // Subtract timer from delta time for as long as player has above 0 time left
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                timeLeft = 0;
                timeOn = false;
                PlayerDied();
            }

            // Stop the timer once player dies
            if(HeartsSystem.life < 1)
            {
                timeOn = false;
            }
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        // Calculating minutes and seconds to appear in the UI
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
