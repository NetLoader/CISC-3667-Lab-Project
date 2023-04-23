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
            Debug.Log("Balloon hit!");
            BalloonPopSFX.Play();
            Destroy(collision.gameObject);
            sk.IncrementScore();
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
}
