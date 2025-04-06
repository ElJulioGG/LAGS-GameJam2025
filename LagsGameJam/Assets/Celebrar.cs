using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Celebrar : MonoBehaviour
{
    public float duracion = 0.5f;    // tiempo de subida/bajada
    public float tiempoTotal = 2f;   // cuánto dura el efecto

    private Tween movimiento;
    private bool estaMoviendo = false;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && !estaMoviendo)
        //{
        //    moverAudiencia();
        //}
    }
    public void moverAudiencia()
    {
        estaMoviendo = true;

        // Altura aleatoria entre 0.3 y 1.3
        float alturaRandom = Random.Range(0.3f, 1.3f);

        // Inicia el movimiento arriba/abajo
        movimiento = transform.DOMoveY(transform.position.y + alturaRandom, duracion)
                              .SetLoops(-1, LoopType.Yoyo)
                              .SetEase(Ease.InOutSine);

        // Lo detiene después de tiempoTotal segundos
        DOVirtual.DelayedCall(tiempoTotal, () =>
        {
            if (movimiento.IsActive())
            {
                movimiento.Kill(); // detiene el loop
                estaMoviendo = false;
            }
        });
    }
}
