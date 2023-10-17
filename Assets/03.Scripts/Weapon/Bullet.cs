using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 bir;
    private float speed = 1f;
    //private float damage;
    //private float range;
    //private float pener;

    private BulletTypes types;
    private WeaponControl control;
    private void Start()
    {
        //types = GetComponentInParent<BulletTypes>();
        control = GetComponentInParent<WeaponControl>();
        //speed = types.BulletSpeed;
        //damage = types.BulletDamage;
        //range = types.BulletRange;
        //pener = types.BulletPener;
    }
    private void Update()
    {
        transform.Translate(bir.normalized * speed * Time.deltaTime);
    }
}
