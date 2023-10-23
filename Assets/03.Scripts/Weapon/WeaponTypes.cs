using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTypes : MonoBehaviour
{
    [SerializeField] string weaponType;
    [SerializeField] string weaponName;
    [SerializeField] float shootSpeed;
    [SerializeField] float shootRange;
    [SerializeField] float accuracy;
    [SerializeField] float weight;
    [SerializeField] float reloadSpeed;
    [SerializeField] int magazine;
    [SerializeField] float weaponChange;
    public string WeaponType { get { return weaponType; } }
    public string WeaponName { get {  return weaponName; } }
    public float ShootSpeed { get {  return shootSpeed; } }
    public float ShootRange { get {  return shootRange; } }
    public float WeaponAccuracy { get {  return accuracy; } }
    public float WeaponWeight { get {  return weight; } }
    public float ReloadSpeed { get { return reloadSpeed; } }
    public int WeaponMagazine { get {  return magazine; } }
    public float WeaponChange { get {  return weaponChange; } }
}
