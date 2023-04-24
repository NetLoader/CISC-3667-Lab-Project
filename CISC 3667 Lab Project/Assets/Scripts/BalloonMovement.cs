using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    private float speed = 5f;
    private float growthRate = 0.5f;
    private float maxSize = 15f;
    private Rigidbody2D rb;
    private float currentSize;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSize = transform.localScale.x;
    }

    void FixedUpdate()
    {
        if (currentSize >= maxSize)
        {
            Destroy(gameObject);
        }
        BalloonGrowth();
        rb.velocity = new Vector2(0, speed);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            speed = -speed;
        }
    }
    private void BalloonGrowth()
    {
        currentSize += growthRate * Time.deltaTime;
        currentSize = Mathf.Clamp(currentSize, 0, maxSize);
        transform.localScale = new Vector3(currentSize, currentSize, currentSize);
    }
}
