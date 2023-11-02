using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    [SerializeField]float duration = 30f;
    private void Update()
    {
        if (transform.parent == null)
        {
            StartCoroutine(Smoking());
        }
    }
    IEnumerator Smoking()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
