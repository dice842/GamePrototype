using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownWeapons : MonoBehaviour
{
    [SerializeField] float maxThrowForce = 10f; // 던질 때의 힘
    [SerializeField] float throwForce = 0f;
    [SerializeField] float explosionRadius = 2f; // 폭발 범위
    [SerializeField] float explosionForce = 10f; // 폭발 힘
    [SerializeField] float explosionDelay = 2f; // 폭발 지연 시간
    [SerializeField] int throwCount = 3; //투척 횟수
    [SerializeField] GameObject explosionPrefab; // 폭발 효과 프리팹

    private bool isThrown = false; // 투척 여부

    private Rigidbody2D rb;

    PlayerControl playerControl;
    private void Start()
    {
        playerControl = GetComponentInParent<PlayerControl>();
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // 초기에 물리 효과 비활성화
    }
    public void ChargingWeapon()
    {
        if (throwCount > 0)
        {
            if (throwForce < maxThrowForce)
                throwForce += Time.deltaTime;
            else if (throwForce >= maxThrowForce) throwForce = maxThrowForce;
            //else if (Input.GetMouseButtonDown(1))
            //{
            //    throwForce = 0f;
            //    playerControl.useItemColldown(1);
            //    return;
            //}
        }

    }
    public void Thrown(Vector3 throwBir)
    {
        if (throwForce > 1)
        {
            GameObject throwingGO = Instantiate(gameObject);
            throwingGO.transform.position = gameObject.transform.position;
            Rigidbody2D cloneRB = throwingGO.GetComponent<Rigidbody2D>();
            cloneRB.isKinematic = false; // 물리 효과 활성화
            cloneRB.AddForce(throwBir * throwForce, ForceMode2D.Impulse);

            throwForce = 0f;
            throwCount--;
            playerControl.useItemColldown(1);
            if (throwCount == 0) Destroy(gameObject);
        }
    }
}
