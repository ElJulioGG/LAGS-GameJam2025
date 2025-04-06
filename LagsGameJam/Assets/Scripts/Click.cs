using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] public int pullValue = 10;
    [SerializeField] public bool isAi = false;
    [SerializeField] public bool isLeftSide = false; // true = A / izquierda, false = D / derecha
    [SerializeField] public KeyCode activationKey;   // A o D

    private bool isSelected = false;

    void Start()
    {
        if (isAi)
        {
            isSelected = true; // IA empieza automáticamente
            StartCoroutine(Autoclick());
        }
    }

    void Update()
    {
        // Jugador selecciona su lado presionando A o D
        if (!isAi && Input.GetKeyDown(activationKey))
        {
            isSelected = true;
            Debug.Log($"Jugador del lado {(isLeftSide ? "izquierdo" : "derecho")} ha comenzado a jugar.");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isSelected || isAi)
            return;

    }


    IEnumerator Autoclick()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
        }
    }
}
