using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] bool canShooting = true;

    private BulletTypes bulletTypes;
    private WeaponTypes weaponTypes;
    public void ShootBullet(Vector3 bulletBir)
    {
        if (canShooting)
        {
            weaponTypes = GetComponentInChildren<WeaponTypes>();
            bulletTypes = GetComponentInChildren<BulletTypes>();
            RaycastHit2D hit = Physics2D.Raycast(transform.position, bulletBir.normalized * weaponTypes.ShootRange * bulletTypes.BulletRange);
            StartCoroutine(ShootingDelay(weaponTypes.ShootSpeed));
        }
    }
    IEnumerator ShootingDelay(float delay)
    {
        canShooting = false;
        yield return new WaitForSeconds(delay);
        canShooting = true;
        yield break;
    }
}
