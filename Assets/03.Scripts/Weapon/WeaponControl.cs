using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject shootPos;

    PlayerControl playerControl;
    private void Start()
    {
        playerControl = GetComponentInParent<PlayerControl>();
        shootPos = transform.GetChild(0).gameObject;
    }
    private void Update()
    {
        GunPosUpdate(playerControl.LookAtMouse());
    }
    public void GunPosUpdate(Vector3 lookBir)
    {
        float angle = Mathf.Atan2(lookBir.y, lookBir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    public void ShootBullet(Vector3 shootBir)
    {
        GameObject bulletGO = Instantiate(bullet);
        bulletGO.GetComponent<Bullet>().bir = shootBir;
        bulletGO.transform.position = shootPos.transform.position;
    }
}
