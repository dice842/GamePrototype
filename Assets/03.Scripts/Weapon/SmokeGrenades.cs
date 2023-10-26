using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeGrenades : MonoBehaviour
{
    [SerializeField] float explosionDelay = 2f;
    GameObject smokePrefab;
    // Start is called before the first frame update
    void Start()
    {
        smokePrefab = transform.GetChild(0).gameObject;
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
        GameObject smoke = Instantiate(smokePrefab, transform.position, Quaternion.identity);
        smoke.SetActive(true);
        Destroy(gameObject);
    }
}
