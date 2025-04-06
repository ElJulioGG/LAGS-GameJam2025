using UnityEngine;
using TMPro;

public class CountdownTimerTMP : MonoBehaviour
{
    public TextMeshPro timerText; // Arrastra el componente TMP aquí
    public float timeRemaining = 60f; // 1 minuto en segundos
    private bool timerRunning = true;

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timerRunning = false;
                timeRemaining = 0;
                UpdateTimerDisplay(timeRemaining);
                Debug.Log("¡Tiempo terminado!");
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
