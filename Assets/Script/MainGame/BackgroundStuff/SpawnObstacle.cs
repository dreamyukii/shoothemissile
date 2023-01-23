using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private ManagerSpawn ms;
    private float timer;
    
    void Start()
    {
        ms = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ManagerSpawn>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 6)
        {
            Destroy(gameObject);
        }
        rb.velocity =Vector2.left*(speed+ms.speedMultiplier);
    }
    
}
