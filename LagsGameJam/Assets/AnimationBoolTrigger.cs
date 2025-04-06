using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBoolTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public bool animationFinished = false;
    public MinigameController minigame;

    // Este método se llamará al final de la animación
    public void OnAnimationEnd()
    {
        animationFinished = true;
        minigame.canPlayMinigame = true;
        Debug.Log("¡La animación ha terminado!");
    }
}
