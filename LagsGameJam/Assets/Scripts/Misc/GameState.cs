using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject deathCanvas;
    [SerializeField] private GameObject spotlightManager;
    private bool playerDied = false;
    void Start()
    {
        AudioManager.instance.PlayMusic("Level1");
        GameManager.instance.playerHealth = 1;
        GameManager.instance.playerAlive = true;
        GameManager.instance.playerCanMove = true;
        GameManager.instance.underLigth = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.playerHealth <= 0 && playerDied == false)
        {
            PlayerDied();
        }
    }

    void PlayerDied()
    {
        GameManager.instance.playerAlive = false;
        deathCanvas.SetActive(true);
        spotlightManager.SetActive(false);
        playerDied = true;
    }

    //public IEnumerator
}
