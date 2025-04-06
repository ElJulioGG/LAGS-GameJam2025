using UnityEngine;

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

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        // Comienza el juego si presionas D
        if (!gameStarted && Input.GetKeyDown(KeyCode.D))
        {
            gameStarted = true;
            musicBefore.Stop();
            musicDuring.Play();
            Debug.Log("¡Juego iniciado! Presiona D para jalar.");
        }

        UpdateRopePosition();
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
        musicDuring.Stop();
        musicAfter.Play();
        if (!gameStarted) return;

        gameStarted = false;
        Debug.Log("¡Ganó: " + winner + "!");
    }

    public float GetRopeValue()
    {
        return ropeValue;
    }
}
