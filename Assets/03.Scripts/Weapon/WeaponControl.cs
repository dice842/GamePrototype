using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    public void ShootBullet(Vector3 bir, float accuracy, GameObject bullet)
    {
        GameObject bulletGO = Instantiate(bullet);
        bulletGO.GetComponent<Bullet>().Bir = bir;
        bulletGO.transform.position = transform.Find("ShootPos").transform.position;
    }
}
