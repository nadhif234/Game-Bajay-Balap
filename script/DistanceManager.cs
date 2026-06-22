using UnityEngine;
using TMPro;

public class DistanceManager : MonoBehaviour
{
    public Transform player;
    public Transform finish;
    public TextMeshProUGUI distanceText;

    void Update()
    {
        float distance = Vector3.Distance(player.position, finish.position);

        distanceText.text = "Jarak: " + distance.ToString("F1") + " M";
    }
}