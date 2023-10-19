using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTypes : MonoBehaviour
{
    [SerializeField] string bulletType;
    [SerializeField] float bulletDamage; 
    [SerializeField] float bulletRange = 1; 
    [SerializeField] float bulletPener; 
    public string BulletType { get { return bulletType; } }
    public float BulletDamage { get {  return bulletDamage; } }
    public float BulletRange { get {  return bulletRange; } }
    public float BulletPener { get {  return bulletPener; } }
}
