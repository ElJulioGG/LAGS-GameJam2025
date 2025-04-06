using UnityEngine;
using TMPro;

public class CountdownTimerTMP : MonoBehaviour
{
    public TextMeshPro timerText;
    public float timeRemaining = 60f;
    private bool timerRunning = true;
    public GameObject Messi;
    public MinigameController minigameController; // arrástralo en el Inspector
    private bool messiShown = false;
    private bool messiHidden = false;

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

                    // Mostrar a Messi en el segundo 30
                    if (!messiShown && timeRemaining <= 30f)
                    {
                        Messi.SetActive(true);
                        messiShown = true;
                    }

                    // Ocultar a Messi en el segundo 28
                    if (!messiHidden && timeRemaining <= 28f)
                    {
                        Messi.SetActive(false);
                        messiHidden = true;
                    }
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
