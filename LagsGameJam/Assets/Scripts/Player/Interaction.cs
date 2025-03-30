using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
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
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("spotlight"))
        {
            GameManager.instance.underLigth = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("spotlight"))
        {
            GameManager.instance.underLigth = true;
        }
        else
        {
            GameManager.instance.underLigth = false;
        }
    }
}
