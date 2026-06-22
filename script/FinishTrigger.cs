using UnityEngine;
using TMPro;

public class FinishTrigger : MonoBehaviour
{
    public GameObject finishUI;
    public TextMeshProUGUI bestTimeText;
    public TextMeshProUGUI timerText;

    private bool finished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (finished) return;

        if (other.CompareTag("Player"))
        {
            finished = true;

            // AMBIL WAKTU SEKARANG
            string currentTime = timerText.text;

            // AMBIL ANGKA TIMER
            float time = Time.timeSinceLevelLoad;

            // AMBIL BEST TIME LAMA
            float bestTime = PlayerPrefs.GetFloat("BestTime", 9999f);

            // CEK APAKAH LEBIH BAGUS
            if (time < bestTime)
            {
                bestTime = time;

                PlayerPrefs.SetFloat("BestTime", bestTime);
            }

            // TAMPILKAN BEST TIME
            bestTimeText.text = "Best Time : " + bestTime.ToString("F2") + " s";

            // MUNCULKAN UI
            finishUI.SetActive(true);
            bestTimeText.gameObject.SetActive(true);

            // STOP GAME
            Time.timeScale = 0f;
        }
    }
}