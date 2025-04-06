using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
   // public ParticleSystem explosio;
    public CameraShake cameraShake;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
 //           explosio.Play();
            StartCoroutine(cameraShake.Shake(.15f, .4f));
        }
    }
}
