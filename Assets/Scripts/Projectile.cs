using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;

    public float detonateTime = 1;
    public float radius = 3;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //StartCoroutine(TickBomb());
        rb = GetComponent<Rigidbody2D>();
        Invoke("Detonate", detonateTime);
        Invoke("EnableCollider", 0.2f);
    }

    IEnumerator TickBomb()
    {
        
        while(true)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }

    }

    public void Initialize(int power)
    {
        rb.AddForce(transform.right * (power / 2), ForceMode2D.Impulse);
    }

    void Detonate()
    {
        TerrainDestroyer.instance.DestroyTerrain(transform.position, radius);
        Destroy(gameObject);
    }

    void EnableCollider()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            TerrainDestroyer.instance.DestroyTerrain(transform.position, radius);
            Destroy(gameObject);
        }
    }
}
