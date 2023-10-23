using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemyHP = 10f;
    public void HitEnemy(float damage)
    {
        if (enemyHP > 0) enemyHP -= damage;
    }
}
