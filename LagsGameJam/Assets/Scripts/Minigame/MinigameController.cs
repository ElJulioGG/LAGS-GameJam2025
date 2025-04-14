using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MinigameController : MonoBehaviour
{
    public GameObject imagePrefab;     // Prefab de imagen
    public Transform pilaBase;         // Base para posicionar cada pila

    private int currentCount = 0;
    private int sortingOrder = 0;

    private int maxImagesPerPila = 10;
    private int imageIndexInPila = 0;
    private int pilaIndex = 0;
    public int PAPA = 0;
    public TextMeshPro counter;
    public bool canPlayMinigame=false;

    public AudioSource esperaMusic;
    public GameObject musicMinigame;
    [Header("Rivales")]
    public TextMeshPro rival1Counter;
    public TextMeshPro rival2Counter;

    public int rival1Puntaje = 0;
    public int rival2Puntaje = 0;
    private float rival1Timer = 0f;
    private float rival2Timer = 0f;

    [Header("Final del juego")]
    public AudioSource firstPlaceMusic;
    public AudioSource secondPlaceMusic;
    public AudioSource thirdPlaceMusic;

    private bool gameFinished = false;
    private List<(string name, int score)> ranking = new List<(string, int)>();

    [Header("Pilas de cada jugador")]
    public Transform pilaBaseJugador;
    public Transform pilaBaseRival1;
    public Transform pilaBaseRival2;

    [Header("Imagen Prefab para los bots")]
    public GameObject imagePrefabRival1;
    public GameObject imagePrefabRival2;

    // Estado pila rival1
    private int imageIndexRival1 = 0;
    private int pilaIndexRival1 = 0;
    private int sortingOrderRival1 = 0;

    // Estado pila rival2
    private int imageIndexRival2 = 0;
    private int pilaIndexRival2 = 0;
    private int sortingOrderRival2 = 0;

    public bool peru;
    public bool argentina;
    public bool colombia;

    public GameObject peruCondition;
    public GameObject argentinauCondition;
    public GameObject colombiauCondition;

    public CloseCourtains closeCourtains;

    public Animator animation;

    //public GameObject Gamep;
    private void Start()
    {
        //Gamep.SetActive(false);
        esperaMusic.Play();
    }

    void Update()
    {
        if (canPlayMinigame && !gameFinished)
        {
            esperaMusic.Stop();
            musicMinigame.SetActive(true);

            // Jugador
            if (Input.GetKeyDown(KeyCode.A))
            {
                currentCount++;
                Debug.Log("Contador: " + currentCount);

                if (currentCount == 5)
                {
                    currentCount = 0;
                    GenerateImage();
                }
            }

            // Rival 1
            rival1Timer += Time.deltaTime;
            if (rival1Timer >= Random.Range(0.5f, 1.5f) && rival1Puntaje < 60)
            {
                rival1Puntaje++;
                rival1Counter.text = rival1Puntaje + "/60";
                rival1Timer = 0f;
                GenerateImageForRival(pilaBaseRival1, ref imageIndexRival1, ref pilaIndexRival1, ref sortingOrderRival1);
                if (rival1Puntaje >= 10)
                {
                    animation.SetBool("isEa1", true);
                }
                if (rival1Puntaje >= 30)
                {
                    animation.SetBool("isEa2", true);
                }
                if (rival1Puntaje >= 45)
                {
                    animation.SetBool("isEa3", true);
                }
            }

            // Rival 2
            rival2Timer += Time.deltaTime;
            if (rival2Timer >= Random.Range(0.6f, 1.8f) && rival2Puntaje < 60)
            {
                rival2Puntaje++;
                rival2Counter.text = rival2Puntaje + "/60";
                rival2Timer = 0f;
                GenerateImageForRival(pilaBaseRival2, ref imageIndexRival2, ref pilaIndexRival2, ref sortingOrderRival2);
            }

            // Revisar si terminó el juego
            CheckIfGameFinished();
        }
    }

    void GenerateImage()
    {
        if (imagePrefab == null || pilaBase == null)
        {
            Debug.LogWarning("Falta asignar imagePrefab o pilaBase en el Inspector.");
            return;
        }

        // Si ya se generaron 15 en esta pila, iniciar una nueva
        if (imageIndexInPila >= maxImagesPerPila)
        {
            imageIndexInPila = 0;
            pilaIndex++;
        }

        // Calcular posición:
        // - X se desplaza 5 unidades por cada pila nueva
        // - Y se desplaza 4 unidades por imagen en la pila
        Vector3 spawnPosition = new Vector3(
            pilaBase.position.x + (pilaIndex * -.3f),
            pilaBase.position.y + (imageIndexInPila * .2f),
            pilaBase.position.z
        );

        // Instanciar imagen
        GameObject newImage = Instantiate(imagePrefab, spawnPosition, Quaternion.identity);
        SpriteRenderer sr = newImage.GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            sr.sortingOrder = sortingOrder;
            sortingOrder -= 2;
        }

        imageIndexInPila++;
        PAPA++;
        counter.text = PAPA + "/60";
        Debug.Log($"Imagen generada en Pila {pilaIndex}, posición Y: {spawnPosition.y}, orden: {sortingOrder}");
    }

    void CheckIfGameFinished()
    {
        if (PAPA >= 60 || rival1Puntaje >= 60 || rival2Puntaje >= 60)
        {
            gameFinished = true;
            canPlayMinigame = false;
            closeCourtains.CloseCortain();
            closeCourtains.PaisGano();
            // Llenar ranking
            ranking.Add(("Jugador", PAPA));
            ranking.Add(("Rival1", rival1Puntaje));
            ranking.Add(("Rival2", rival2Puntaje));

            // Ordenar por puntaje descendente
            ranking.Sort((a, b) => b.score.CompareTo(a.score));

            if (rival1Puntaje == 60) {
                peru = true;
                peruCondition.SetActive(true);
            }
            if (rival2Puntaje == 60)
            {
                colombia = true;
                colombiauCondition.SetActive(true);
            }
            if (PAPA == 60) {
                argentina = true;
                argentinauCondition.SetActive(true);
            }

            StartCoroutine(EsperarYCargar());

            // Buscar tu puesto
            for (int i = 0; i < ranking.Count; i++)
            {
                if (ranking[i].name == "Jugador")
                {
                    int posicion = i + 1;
                    Debug.Log("Terminaste en posición: " + posicion);

                    switch (posicion)
                    {
                        case 1:
                            firstPlaceMusic.Play();
                           // Gamep.SetActive(true);

                            break;
                        case 2:
                            secondPlaceMusic.Play();
                           // Gamep.SetActive(true);

                            break;
                        case 3:
                            thirdPlaceMusic.Play();
                           // Gamep.SetActive(true);

                            break;
                    }

                    break;
                }
            }


        }
    }
    IEnumerator EsperarYCargar()
    {
        yield return new WaitForSeconds(8f); // Espera 7 segundos
        SceneManager.LoadScene("IlanScene"); // Carga la escena por nombre
    }
    void GenerateImageForRival(Transform basePila, ref int indexInPila, ref int pilaIndex, ref int sortingOrder)
    {
        if (imagePrefab == null || basePila == null)
        {
            Debug.LogWarning("Falta prefab o pila para rival.");
            return;
        }

        if (indexInPila >= maxImagesPerPila)
        {
            indexInPila = 0;
            pilaIndex++;
        }

        Vector3 spawnPosition = new Vector3(
            basePila.position.x + (pilaIndex * -0.3f),
            basePila.position.y + (indexInPila * 0.2f),
            basePila.position.z
        );

        GameObject newImage = Instantiate(imagePrefab, spawnPosition, Quaternion.identity);
        SpriteRenderer sr = newImage.GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            sr.sortingOrder = sortingOrder;
            sortingOrder -= 2;
        }

        indexInPila++;
    }
    public bool IsGameFinished()
    {
        return gameFinished;
    }

    public void FinishGameDueToTime()
    {
        Debug.Log("Juego terminado por tiempo.");
        gameFinished = true;
        canPlayMinigame = false;
     

        // Agregar al ranking actual
        ranking.Add(("Jugador", PAPA));
        ranking.Add(("Rival1", rival1Puntaje));
        ranking.Add(("Rival2", rival2Puntaje));

        // Ordenar y reproducir música
        ranking.Sort((a, b) => b.score.CompareTo(a.score));
        for (int i = 0; i < ranking.Count; i++)
        {
            if (ranking[i].name == "Jugador")
            {
                int posicion = i + 1;
                switch (posicion)
                {
                    case 1:
                        firstPlaceMusic.Play();
                      //  Gamep.SetActive(true);
                        break;
                    case 2:
                        secondPlaceMusic.Play();
                     //   Gamep.SetActive(true);
                        break;
                    case 3:
                        thirdPlaceMusic.Play();
                     //   Gamep.SetActive(true);
                        break;
                }
                break;
            }
        }



        

    }


}


