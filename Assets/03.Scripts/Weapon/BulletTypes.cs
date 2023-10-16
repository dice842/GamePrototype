using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTypes : MonoBehaviour
{
    [SerializeField] string bulletType; //탄종류(권총,라이플)
    [SerializeField] float bulletSpeed; //탄속
    [SerializeField] float bulletDamage; //데미지
    [SerializeField] float bulletRange; //사거리
    [SerializeField] float bulletPener; //관통력
    public string BulletType { get { return bulletType; } }
    public float BulletSpeed { get {  return bulletSpeed; } }
    public float BulletDamage { get {  return bulletDamage; } }
    public float BulletRange { get {  return bulletRange; } }
    public float BulletPener { get {  return bulletPener; } }
}
