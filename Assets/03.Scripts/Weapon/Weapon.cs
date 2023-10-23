using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] bool canOperate = true;
    [SerializeField] bool canShooting = true;

    private BulletTypes bulletTypes;
    private WeaponTypes weaponTypes;
    private PlayerLever playerLever;

    private Enemy enemy;

    int maxBullet;
    [SerializeField] int currentBullet = 0;

    private float gnuAccuracy;

    float reloadSpeed;
    private void Start()
    {
        weaponTypes = GetComponentInChildren<WeaponTypes>();
        bulletTypes = GetComponentInChildren<BulletTypes>();
        playerLever = GetComponentInParent<PlayerLever>();
        gnuAccuracy = weaponTypes.WeaponAccuracy * (1 - (0.1f * playerLever.Marksmanship));
        maxBullet = weaponTypes.WeaponMagazine;
        currentBullet = maxBullet;

        reloadSpeed = weaponTypes.ReloadSpeed * (1 - (0.1f * playerLever.Marksmanship));
    }
    private void Update()
    {
        if (transform.parent.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.R) && canOperate) StartCoroutine(Reload());
        }
    }
    Vector3 Accuracy(Vector3 dir)
    {
        float randomAngle = Random.Range(-gnuAccuracy, gnuAccuracy);

        float angleInRadians = randomAngle * Mathf.Deg2Rad;

        Vector3 randomDirection = new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians), 0);

        return dir + randomDirection;
    }
    public void Operate(Vector3 shootBir)
    {
        if (canOperate)
        {
            if (currentBullet == 0)
            {
                StartCoroutine(Reload());
            }
            else if (canShooting)
            {
                ShootBullet(shootBir);
            }
        }
    }
    public void ShootBullet(Vector3 bulletBir)
    {
        currentBullet--;
        Vector3 randomBir = Accuracy(bulletBir);
        Debug.DrawRay(transform.position, randomBir.normalized * weaponTypes.ShootRange * bulletTypes.BulletRange, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, randomBir.normalized * weaponTypes.ShootRange * bulletTypes.BulletRange);
        HitBullet(rayHit);
        StartCoroutine(ShootingDelay(weaponTypes.ShootSpeed));
    }

    private void HitBullet(RaycastHit2D rayHit)
    {
        if (rayHit.collider == null)
        {
            if (rayHit.collider.tag == "Enemy")
            {
                enemy = rayHit.collider.GetComponent<Enemy>();
                enemy.HitEnemy(bulletTypes.BulletDamage);
            }
        }
    }

    IEnumerator ShootingDelay(float delay)
    {
        canShooting = false;
        yield return new WaitForSeconds(delay);
        canShooting = true;
        yield break;
    }
    IEnumerator Reload()
    {
        canOperate = false;
        if (currentBullet >= 1)
        {
            currentBullet = 1;
        }
        yield return new WaitForSeconds(reloadSpeed);
        currentBullet += maxBullet;
        canOperate = true;
        yield break;
    }
}
