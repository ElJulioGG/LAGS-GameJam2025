using System.Collections;
using UnityEngine;

public class RopeBot : MonoBehaviour
{
    public float pullInterval = 0.4f; // cada cuánto jala el bot

    void Start()
    {
        StartCoroutine(PullRoutine());
    }

    IEnumerator PullRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(pullInterval);

            if (RopeManager.instance.gameStarted)
            {
                RopeManager.instance.Pull(true); // tira hacia la izquierda
            }
        }
    }
}
