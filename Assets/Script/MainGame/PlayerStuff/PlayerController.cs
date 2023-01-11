using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public float jumpForce;

    private Rigidbody2D rigidBodyPlayer;

    
    // Start is called before the first frame update
    void Start()
    {
        rigidBodyPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBodyPlayer.velocity = new Vector2(moveSpeed, rigidBodyPlayer.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rigidBodyPlayer.velocity = new Vector2(rigidBodyPlayer.velocity.x, jumpForce);
        }
    }
    
}
