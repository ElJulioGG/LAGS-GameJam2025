using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
    }
}
