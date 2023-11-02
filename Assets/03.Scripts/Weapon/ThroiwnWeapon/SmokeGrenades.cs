using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeGrenades : MonoBehaviour
{
    [SerializeField] float duration = 30f;
    [SerializeField] float explosionDelay = 2f;
    GameObject smoke;
    // Start is called before the first frame update
    void Start()
    {
        smoke = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent == null)
        {
            StartCoroutine(SmokeExplode());
        }
    }
    IEnumerator SmokeExplode()
    {
        yield return new WaitForSeconds(explosionDelay);
        smoke.SetActive(true);
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
