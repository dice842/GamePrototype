using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenades : MonoBehaviour
{
    [SerializeField] float explosionForce = 10f;
    [SerializeField] float explosionDelay = 2f;
    [SerializeField] float explosionRadius = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent == null)
        {
            StartCoroutine(Explode());
        }
    }
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(explosionDelay);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D col in colliders)
        {
            if (col.transform.tag == "Enemy")
            {
                Enemy enemy = col.GetComponent<Enemy>();
                enemy.HitEnemy(5);
            }
            Rigidbody2D targetRb = col.GetComponent<Rigidbody2D>();

            if (targetRb != null)
            {
                Vector2 explosionDir = col.transform.position - transform.position;
                targetRb.AddForce(explosionDir.normalized * explosionForce, ForceMode2D.Impulse);
            }
        }
        Destroy(gameObject);
    }
}
