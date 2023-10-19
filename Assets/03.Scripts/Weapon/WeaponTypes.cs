using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTypes : MonoBehaviour
{
    [SerializeField] string weaponType;
    [SerializeField] string weaponName;
    [SerializeField] float shootSpeed = 0.2f;
    [SerializeField] float shootRange = 5;
    [SerializeField] float accuracy;
    [SerializeField] float weight;
    [SerializeField] float magazine;
    public string WeaponType { get { return weaponType; } }
    public string WeaponName { get {  return weaponName; } }
    public float ShootSpeed { get {  return shootSpeed; } }
    public float ShootRange { get {  return shootRange; } }
    public float WeaponAccuracy { get {  return accuracy; } }
    public float WeaponWeight { get {  return weight; } }
    public float WeaponMagazine { get {  return magazine; } }
}
