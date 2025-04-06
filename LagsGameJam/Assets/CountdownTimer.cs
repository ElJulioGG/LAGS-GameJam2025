using UnityEngine;
using TMPro;

public class CountdownTimerTMP : MonoBehaviour
{
    public TextMeshPro timerText;
    public float timeRemaining = 60f;
    private bool timerRunning = true;

    public MinigameController minigameController; // arrástralo en el Inspector

    void Update()
    {
        if (minigameController.canPlayMinigame)
        {
            if (timerRunning)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    UpdateTimerDisplay(timeRemaining);

                    // Habilitar el minijuego cuando empiece el contador
                    if (!minigameController.canPlayMinigame)
                        minigameController.canPlayMinigame = true;
                }
                else
                {
                    timeRemaining = 0;
                    timerRunning = false;
                    UpdateTimerDisplay(timeRemaining);
                    Debug.Log("¡Tiempo terminado!");

                    // Forzar fin de juego
                    if (!minigameController.IsGameFinished())
                    {
                        minigameController.FinishGameDueToTime();
                    }
                }
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
