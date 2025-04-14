using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CloseCourtains : MonoBehaviour
{
    public Transform cortinaIzq;
    public Transform cortinaDer;
    public Transform pais;
    public Transform counter;
    public Transform puntuaProta;
    public Transform puntua1;
    public Transform puntua2;

    public Transform peru;
    public Transform colombia;
    public Transform argentina;

    public MinigameController minigameController;
    public Diamond diamondRight;
    public Diamond diamondLeft;

    public Animator animator;

    private void Update()
    {

       // if (Input.GetKeyDown(KeyCode.D))
       // {
       //     OpenCortain();
       // }
    }
   public  void CloseCortain() {
        cortinaDer.transform.DOMoveX(6f, 1.5f).SetEase(Ease.OutExpo);
        cortinaIzq.transform.DOMoveX(-6f, 1.5f).SetEase(Ease.OutExpo);
        pais.transform.DOMoveY(8f, 1.5f).SetEase(Ease.OutExpo);
        counter.transform.DOMoveY(6f, 1.5f).SetEase(Ease.OutExpo);

        puntuaProta.transform.DOMoveY(-12f, 1.5f).SetEase(Ease.OutExpo);
        puntua1.transform.DOMoveY(-12f, 1.5f).SetEase(Ease.OutExpo);
        puntua2.transform.DOMoveY(-12f, 1.5f).SetEase(Ease.OutExpo);

        animator.SetBool("IsOpen", false);

    }
    public void OpenCortain() {
        cortinaDer.transform.DOMoveX(16f, 1.5f).SetEase(Ease.OutExpo);
        cortinaIzq.transform.DOMoveX(-16f, 1.5f).SetEase(Ease.OutExpo);
        pais.transform.DOMoveY(3f, 1.5f).SetEase(Ease.OutExpo);
        counter.transform.DOMoveY(-0.5f, 1.5f).SetEase(Ease.OutExpo);
        puntuaProta.transform.DOMoveY(-4f, 1.5f).SetEase(Ease.OutExpo);
        puntua1.transform.DOMoveY(-4f, 1.5f).SetEase(Ease.OutExpo);
        puntua2.transform.DOMoveY(-4f, 1.5f).SetEase(Ease.OutExpo);
        animator.SetBool("IsOpen", true);

    }

    public void PaisGano() {

        if (minigameController.rival1Puntaje==60)
        {
            peru.transform.DOMoveY(1f, 1.5f).SetEase(Ease.OutExpo);
            peru.transform.DOMoveY(-10f, 1.5f).SetEase(Ease.OutExpo).SetDelay(5f);

        }
        if (minigameController.rival2Puntaje==60)
        {
            colombia.transform.DOMoveY(1f, 1.5f).SetEase(Ease.OutExpo);
            colombia.transform.DOMoveY(-10f, 1.5f).SetEase(Ease.OutExpo).SetDelay(5f);
        }
        if (minigameController.PAPA==60)
        {
            argentina.transform.DOMoveY(1f, 1.5f).SetEase(Ease.OutExpo);
            argentina.transform.DOMoveY(-10f, 1.5f).SetEase(Ease.OutExpo).SetDelay(5f);

        }
        if (diamondRight.isChile==true) {
            peru.transform.DOMoveY(10f, 1.5f).SetEase(Ease.OutExpo);
            peru.transform.DOMoveY(-10f, 1.5f).SetEase(Ease.OutExpo).SetDelay(5f);
        }
        if (diamondLeft.isBrazil==true) {
            colombia.transform.DOMoveY(10f, 1.5f).SetEase(Ease.OutExpo);
            colombia.transform.DOMoveY(-10f, 1.5f).SetEase(Ease.OutExpo).SetDelay(5f);
        }
    }
}
