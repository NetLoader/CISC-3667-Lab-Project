using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinProjectile : MonoBehaviour
{
    [SerializeField] private AudioSource BalloonPopSFX; 
    public float speed = 5;
    private Rigidbody2D rb;
    PlayerMovement pm;
    SpriteRenderer sr;
    private ScoreKeeper sk;

    void Start()
    {
        pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sk = GameObject.FindObjectOfType<ScoreKeeper>();
        if (pm.isFacingRight)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else 
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Balloon"))
        {
            float currentSize = collision.transform.localScale.x;
            Debug.Log("Balloon hit!");
            BalloonPopSFX.Play();
            DynamicScore(currentSize);
            Destroy(collision.gameObject);
            StartCoroutine(DestroyAfterDelay(1f));
        }
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Balloon"))
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator DestroyAfterDelay(float delay)
    {
        sr.enabled = false;
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
    private void DynamicScore(float cSize)
    {
        int score;
        if (cSize <= 6)
        {
            score = 3;
        }
        else if (cSize > 6 && cSize <=10)
        {
            score = 2;
        }
        else{
            score = 1;
        }
        ScoreKeeper scorekeeper = FindObjectOfType<ScoreKeeper>();
        if (scorekeeper != null)
        {
            scorekeeper.AddScore(score);
        }
    }
}
