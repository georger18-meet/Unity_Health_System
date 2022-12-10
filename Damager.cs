using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Who can get Damaged
enum CanAffect
{
    Player,
    Enemy,
    Both
}

// What kind of Damage
enum DamagerType
{
    OneHit,
    OverTime,
    InstaDeath
}


public class Damager : MonoBehaviour
{
    // Variables
    // --------------------
    [SerializeField] private CanAffect _canAffect;
    [SerializeField] private DamagerType _damagerType;
    [SerializeField] private int _lightDamageAmount;
    [SerializeField] private int _heavyDamageAmount;
    public bool UsingHeavy = false;
    public bool CanDamage = false;


    // Properties
    // --------------------
    internal CanAffect CanAffect { get { return _canAffect; } }
    internal DamagerType DamagerType { get { return _damagerType; } }
    public int LightDamageAmount { get { return _lightDamageAmount; } }
    public int HeavyDamageAmount { get { return _heavyDamageAmount; } }
}
