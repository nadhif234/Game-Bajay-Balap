using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;

    private float timer;
    private bool isRunning = true;

    void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime;

            timerText.text = "Timer: " + timer.ToString("F2") + " s";
        }
    }

    public void StopTimer()
    {
        isRunning = false;
    }
}