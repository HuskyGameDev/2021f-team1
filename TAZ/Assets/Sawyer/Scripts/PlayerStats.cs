using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //PLAYER STATS
    public int maxSpeed = 12;           // movement speed
    public int ap = 10;             // attack power
    public int maxHp = 100;         // max health - might change
    public int curHp = 100;         // current health - might change
    public int jumpForce = 10;
    public bool doubleJump = false; // can double jump?
    public int specialCd = 10;      // special ability cooldown
    public int ultCharge = 0;       // ultimate ability charge
    public bool ultReady = false;   // ultimate ready?
    public int score = 0;           // total current score - might change

}
