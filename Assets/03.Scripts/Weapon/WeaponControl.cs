using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{

    PlayerControl playerControl;
    private void Start()
    {
        playerControl = GetComponentInParent<PlayerControl>();
    }
    public void Operate(Vector3 shootBir)
    {
        Weapon weapon = GetComponentInChildren<Weapon>();
        weapon.ShootBullet(shootBir);
    }
}
