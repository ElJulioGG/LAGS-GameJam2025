using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telon : MonoBehaviour
{
    [SerializeField]private bool isRight = true;
    [SerializeField] private float XOffset = 10;
    // Start is called before the first frame update
    void Start()
    {
        if (isRight)
        {
            transform.DOMoveX(transform.position.x + XOffset, 1f);
        }
        else
        {
            transform.DOMoveX(transform.position.x - XOffset, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
