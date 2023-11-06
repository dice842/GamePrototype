using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGOAP : MonoBehaviour
{
    float alertness = 0f;
    bool hasThreat;

    bool isEnemyVisible;
    GameObject enemy;
    Vector2 lastEnemyPosition;

    bool isHurt;

    GameObject nearDevice;

    bool canMove;
    bool canShoot;
    bool canSee;


}
