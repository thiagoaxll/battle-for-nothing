using System;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpType type;

    public float shootDamage;
    public float takeDamage;
    public float knockBack;
    public float jump;
    public float speed;
    public float scenario;


    public enum PowerUpType
    {
        PlusDamage,
        MinusDamage,
        NoKnockBack,
        PlusJump,
        PlusSpeed,
        ImmuneScenario,
    }
    
}
