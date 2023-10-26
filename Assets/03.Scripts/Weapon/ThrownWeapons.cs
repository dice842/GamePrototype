using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ThrownWeapons : MonoBehaviour
{
    [SerializeField] float maxThrowForce = 9f;
    [SerializeField] float throwForce = 0f;
    [SerializeField] float explosionRadius = 2f;
    [SerializeField] float explosionForce = 10f;
    [SerializeField] float explosionDelay = 2f;
    [SerializeField] int throwCount = 3;
    [SerializeField] GameObject explosionPrefab;

    GameObject dropPos;

    private bool isThrown = false; // ≈ı√¥ ø©∫Œ

    private Rigidbody2D rb;

    private void Start()
    {
        explosionPrefab = transform.GetChild(0).gameObject;
        dropPos = transform.GetChild(1).gameObject;
        dropPos.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }
    public void ChargingWeapon(Vector3 lookBir)
    {
        if (throwCount > 0)
        {
            if (throwForce < maxThrowForce)
                throwForce += Time.deltaTime;
            else if (throwForce >= maxThrowForce) throwForce = maxThrowForce;
            if (throwForce > 1)
            {
                dropPos.SetActive(true);
                dropPos.transform.position = transform.root.position + (lookBir.normalized * ThrowForce(lookBir));
            }
        }
    }
    public void Thrown(Vector3 throwBir)
    {
        if (throwForce > 1)
        {
            dropPos.SetActive(false);
            GameObject throwingGO = Instantiate(explosionPrefab);
            throwingGO.transform.position = gameObject.transform.position;
            Rigidbody2D cloneRB = throwingGO.GetComponent<Rigidbody2D>();
            cloneRB.AddForce(throwBir.normalized * ThrowForce(throwBir) * 9, ForceMode2D.Impulse);

            throwForce = 0f;
            throwCount--;
            if (throwCount == 0) Destroy(gameObject);
        }
    }
    float ThrowForce(Vector3 length)
    {
        return length.magnitude > throwForce ? throwForce : length.magnitude;
    }
    public void CancelCharging()
    {
        throwForce = 0f;
        dropPos.SetActive(false);
    }
    //    IEnumerator Explode()
    //    {
    //        yield return new WaitForSeconds(explosionDelay);
    //        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
    //        foreach (Collider2D col in colliders)
    //        {
    //            if(col.transform.tag == "Enemy")
    //            {
    //                Enemy enemy = col.GetComponent<Enemy>();
    //                enemy.HitEnemy(5);
    //            }
    //            Rigidbody2D targetRb = col.GetComponent<Rigidbody2D>();

    //            if(targetRb != null)
    //            {
    //                Vector2 explosionDir = col.transform.position - transform.position;
    //                targetRb.AddForce(explosionDir.normalized * explosionForce, ForceMode2D.Impulse);
    //            }
    //        }
    //        Destroy(gameObject);
    //    }
}
