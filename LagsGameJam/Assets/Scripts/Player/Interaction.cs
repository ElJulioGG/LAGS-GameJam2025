using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathHitbox"))
        {
            if (!GameManager.instance.underLigth)
            {
                GameManager.instance.playerHealth =  GameManager.instance.playerHealth -1;
                GameManager.instance.playerCanMove = false;
                AudioManager.instance.musicSource.Stop();
                AudioManager.instance.PlaySfx("Boo");
            }
        }
        if (collision.CompareTag("spotlight"))
        {
            GameManager.instance.underLigth = true;
            GameManager.instance.playerCanMove = false;
            playerAnim.SetBool("Vow", true);
            Celebrar[] audiencia = FindObjectsOfType<Celebrar>();
            foreach (Celebrar c in audiencia)
            {
                c.moverAudiencia();
            }

            // Si el audio no ha sido reproducido antes, lo reproducimos
            if (!hasPlayedAudio)
            {
                hasPlayedAudio = true; // Marcar que ya se reprodujo el audio

                // Aquí seleccionamos un audio aleatorio 50/50
                if (Random.Range(0, 2) == 0)
                {
                    AudioManager.instance.PlaySfx("AplauseShort1");
                }
                else
                {
                    AudioManager.instance.PlaySfx("AplauseShort2");
                }
            }

            // Llamamos la corrutina para esperar 0.5 segundos
            StartCoroutine(AllowMovementAfterDelay(0.5f));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("spotlight"))
        {
            GameManager.instance.underLigth = false;
          
            playerAnim.SetBool("Vow", false);
        }
    }
    private bool hasPlayedAudio = false; // Variable para controlar la ejecución del audio

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    private IEnumerator AllowMovementAfterDelay(float delay)
    {
        // Espera el tiempo dado
        yield return new WaitForSeconds(delay);

        // Deja que el jugador se mueva después de 0.5 segundos
        GameManager.instance.playerCanMove = true;
        playerAnim.SetBool("Vow", false); // Si quieres detener la animación

        // Reiniciamos la variable para permitir que se reproduzca audio nuevamente si es necesario
        hasPlayedAudio = false;
    }



}
