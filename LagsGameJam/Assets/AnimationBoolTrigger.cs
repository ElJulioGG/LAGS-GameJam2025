using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBoolTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public bool animationFinished = false;
    public MinigameController minigame;

    // Este m�todo se llamar� al final de la animaci�n
    public void OnAnimationEnd()
    {
        animationFinished = true;
        minigame.canPlayMinigame = true;
        Debug.Log("�La animaci�n ha terminado!");
    }
}
