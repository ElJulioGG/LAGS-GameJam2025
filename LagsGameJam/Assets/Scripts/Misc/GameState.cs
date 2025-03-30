using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject deathCanvas;
    private bool playerDied = false;
    void Start()
    {
        GameManager.instance.playerHealth = 2;
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
        playerDied = true;
    }
}
