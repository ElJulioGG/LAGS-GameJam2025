using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Diamond : MonoBehaviour
{
    public GameObject gameManager;
    public CloseCourtains closeCourtains;
    public GameObject Chile;
    public GameObject Brasil;
    public bool isChile;
    public bool isBrazil;
    public GoalTrigger goal;
    public GoalTrigger goalDerecho;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("DER"))
        {
            gameManager.SetActive(false);
            closeCourtains.PaisGano();
            closeCourtains.CloseCortain();
            Chile.SetActive(true);
            isChile = true;
            closeCourtains.peru.transform.DOMoveY(1, 1.5f).SetEase(Ease.OutExpo);
            closeCourtains.peru.transform.DOMoveY(-10f, 1.5f).SetEase(Ease.OutExpo).SetDelay(5f);
        }
        if (collision.CompareTag("IZQ")) {
            gameManager.SetActive(false);
            closeCourtains.PaisGano();
            closeCourtains.CloseCortain();
            Brasil.SetActive(true);
            isBrazil = true;
            closeCourtains.colombia.transform.DOMoveY(1, 1.5f).SetEase(Ease.OutExpo);
            closeCourtains.colombia.transform.DOMoveY(-10f, 1.5f).SetEase(Ease.OutExpo).SetDelay(5f);
        }

    }
}
