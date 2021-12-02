using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public int health = 20;
    public int attackPower = 5;

    public void takeDamage(int damage) {
        health -= damage;

        if (health <= 0)
            Destroy(gameObject);
    }
}
