using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CloseCourtains : MonoBehaviour
{
    public Transform cortinaIzq;
    public Transform cortinaDer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            CloseCortain();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            OpenCortain();
        }
    }
    void CloseCortain() {
        cortinaDer.transform.DOMoveX(6f, 1.5f).SetEase(Ease.OutExpo);
        cortinaIzq.transform.DOMoveX(-6f, 1.5f).SetEase(Ease.OutExpo);
    }
    void OpenCortain() {
        cortinaDer.transform.DOMoveX(16f, 1.5f).SetEase(Ease.OutExpo);
        cortinaIzq.transform.DOMoveX(-16f, 1.5f).SetEase(Ease.OutExpo);
    }


}
