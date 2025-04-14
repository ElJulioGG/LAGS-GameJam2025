using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RopeManager : MonoBehaviour
{
    public static RopeManager instance;

    public Transform ropeObject;
    public float moveSpeed = 0.05f; // velocidad de cambio
    public float moveRange = 5f;    // cuanto se mueve horizontalmente

    private float ropeValue = 0f;   // -1 (izq) a 1 (der)

    public bool gameStarted = false;


    public AudioSource musicBefore;
    public AudioSource musicDuring;
    public AudioSource musicAfter;
    public Animator ropeAnimator;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.D))
        {
            gameStarted = true;
            musicBefore.Stop();
            musicDuring.Play();
            Debug.Log("¡Juego iniciado! Presiona D para jalar.");
        }

        UpdateRopePosition();

        if (ropeAnimator != null)
        {
            ropeAnimator.SetFloat("ropeValue", ropeValue);
        }

        if (gameStarted)
        {
            if (ropeValue >= 1f)
                EndGame("der");
            else if (ropeValue <= -1f)
                EndGame("izq");
        }
    }



    public void Pull(bool isLeft)
    {
        if (!gameStarted) return;

        float direction = isLeft ? -1f : 1f;
        ropeValue += direction * moveSpeed;
        ropeValue = Mathf.Clamp(ropeValue, -1f, 1f);
    }

    void UpdateRopePosition()
    {
        float xPos = Mathf.Lerp(-moveRange, moveRange, (ropeValue + 1f) / 2f);
        var pos = ropeObject.position;
        pos.x = xPos;
        ropeObject.position = pos;
    }


    public void EndGame(string winner)
    {
        if (!gameStarted) return;

        gameStarted = false;

        musicDuring.Stop();
        musicAfter.Play();

        if (ropeAnimator != null)
        {
            ropeAnimator.SetBool("gameEnded", true);

            if (winner == "der")
                ropeAnimator.SetTrigger("rightWon");
            else if (winner == "izq")
                ropeAnimator.SetTrigger("leftWon");
        }

        Debug.Log("¡Ganó: " + winner + "!");

        StartCoroutine(WaitAndLoadScene());
    }



    public float GetRopeValue()
    {
        return ropeValue;
    }
    private IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("NombreDeTuSiguienteEscena");
    }

}
