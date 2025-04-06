using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresionarComenzar : MonoBehaviour
{
    public MinigameController minigame;
    public CloseCourtains courtains;
    private PresionarComenzar presionar;
    public GameObject Canvas;
    public GameObject animationLights;
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) {
            courtains.OpenCortain();
            Destroy(presionar);
            Destroy(Canvas);
            Destroy(animationLights);
            minigame.canPlayMinigame = true;
        }
    }
}
