using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    public GameObject imagePrefab;     // Prefab de imagen
    public Transform pilaBase;         // Base para posicionar cada pila

    private int currentCount = 0;
    private int sortingOrder = 0;

    private int maxImagesPerPila = 10;
    private int imageIndexInPila = 0;
    private int pilaIndex = 0;

    void Update()
    {
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
            pilaBase.position.x + (pilaIndex * 5f),
            pilaBase.position.y + (imageIndexInPila * .9f),
            pilaBase.position.z
        );

        // Instanciar imagen
        GameObject newImage = Instantiate(imagePrefab, spawnPosition, Quaternion.identity);
        SpriteRenderer sr = newImage.GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            sr.sortingOrder = sortingOrder;
            sortingOrder += 2;
        }

        imageIndexInPila++;
        Debug.Log($"Imagen generada en Pila {pilaIndex}, posición Y: {spawnPosition.y}, orden: {sortingOrder}");
    }
}


