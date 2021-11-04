using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //PLAYER STATS
    public int maxSpeed = 12;               // movement speed
    public int attackPower = 10;            // attack power
    public int maxHp = 100;                 // max health
    public int currentHp;                   // current health
    public int jumpForce = 10;              // vertical force applied to player when jumping
    public int extraJumps = 0;              // number of current extra jumps
    public int specialCooldown = 5;         // special ability cooldown
    public float specialCooldownTimer;      // keeps track of time before special ability is off of cooldown
    public bool specialReady = true;        // flag for keeping track of special ability status
    public int ultCharge = 0;               // current ultimate ability charge value
    public int ultChargeRate = 10;          // number of seconds before ultimate is ready
    public float ultChargeSpeed = 1.0f;     // time in seconds between incrementing ultimate charge
    private float ultChargeTime = 0f;       // keeps track of time when ultimate charge should be increased next
    public bool ultReady = false;           // flag for keeping track of ultimate ability status
    public int score = 0;                   // total current score - might change
	public int type = 0;					//This is the stat for which character is being played

    private void Start()
    {
        currentHp = maxHp;
        specialCooldownTimer = specialCooldown;
    }
    private void Update()
    {
        if(Time.time > ultChargeTime && !ultReady)
            ChargeUltimate();

        if (specialCooldownTimer > 0 && !specialReady)
            RunSpecialCooldown();
    }

    void ChargeUltimate() {
        ultChargeTime = Time.time + ultChargeSpeed;
        ultCharge += ultChargeRate;
        if (ultCharge >= 100)
        {
            ultReady = true;
            Debug.Log("Ultimate Ready");
        }
        else
            Debug.Log("ult charge: " + ultCharge);
    }

    public void resetUlt() {
        ultCharge = 0;
        ultReady = false;
        ultChargeTime = 0f;
    }

    private void RunSpecialCooldown() {
        specialCooldownTimer -= Time.deltaTime;
        Debug.Log("Special Cooldown: " + specialCooldownTimer);
        if (specialCooldownTimer < 0f)
        {
            specialCooldownTimer = 0f;
            specialReady = true;
            Debug.Log("Special Ability Ready");
        }
    }

    public void resetSpecial() {
        specialCooldownTimer = specialCooldown;
        specialReady = false;
    }
}
