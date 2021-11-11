using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    //  List of Power Ups:
    //      Attack up
    //      Speed up
    //      Health up
    //      Additional Jump
    //      Special Ability Cooldown Reduction

    // PowerUp Variables
    public int NumberOfPowerUps = 5;
    public int attackBuff = 5;
    public int speedBuff = 3;
    public int healthBuff = 1;
    public int jumpBuff = 1;
    public int specialCooldownBuff = 1;

    public PlayerStats stats;

    public void AttackUp()
    {
        stats.attackPower += attackBuff;
    }

    public void SpeedUp()
    {
        stats.maxSpeed += speedBuff;
    }

    public void HealthUp()
    {
        stats.maxHp += healthBuff;
    }

    public void AdditionalJump()
    {
        stats.extraJumps += jumpBuff;
    }

    public void SpecialCooldownReduction()
    {
        stats.specialCooldown -= specialCooldownBuff;
    }
}
