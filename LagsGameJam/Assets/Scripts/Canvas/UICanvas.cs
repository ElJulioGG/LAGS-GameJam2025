using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TMP_Text playerHealth;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth.text = GameManager.instance.playerHealth.ToString();
    }
}
