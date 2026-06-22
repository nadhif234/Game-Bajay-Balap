using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class RaceManager : MonoBehaviour
{
    [Header("Player")]
    public Transform player;
    public Transform finish;

    [Header("UI")]
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI countdownText;
    public GameObject finishText;
    public TextMeshProUGUI bestTimeText;

    private float timer = 0f;
    private bool raceStarted = false;
    private bool raceFinished = false;

    void Start()
    {
        finishText.SetActive(false);

        StartCoroutine(StartCountdown());

        float bestTime = PlayerPrefs.GetFloat("BestTime", 9999f);

        if (bestTime < 9999f)
        {
            bestTimeText.text = "Best Time: " + bestTime.ToString("F2") + " s";
        }
    }

    void Update()
    {
        if (raceStarted && !raceFinished)
        {
            // TIMER
            timer += Time.deltaTime;

            timerText.text = "Timer: " + timer.ToString("F2") + " s";

            // DISTANCE
            float distance = Vector3.Distance(player.position, finish.position);

            distanceText.text = "Jarak: " + distance.ToString("F1") + " M";
        }
    }

    IEnumerator StartCountdown()
    {
        raceStarted = false;

        countdownText.gameObject.SetActive(true);

        countdownText.text = "3";
        yield return new WaitForSeconds(1);

        countdownText.text = "2";
        yield return new WaitForSeconds(1);

        countdownText.text = "1";
        yield return new WaitForSeconds(1);

        countdownText.text = "GO!";
        raceStarted = true;

        yield return new WaitForSeconds(1);

        countdownText.gameObject.SetActive(false);
    }

    public void FinishRace()
{
    Debug.Log("FINISH BERHASIL");

    if (raceFinished) return;

    raceFinished = true;

    finishText.SetActive(true);

    float bestTime = PlayerPrefs.GetFloat("BestTime", 9999f);

    if (timer < bestTime)
    {
        PlayerPrefs.SetFloat("BestTime", timer);

        bestTimeText.text = "Best Time: " + timer.ToString("F2") + " s";
    }

    Invoke("RestartGame", 5f);
}
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}