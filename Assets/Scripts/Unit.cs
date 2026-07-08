using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitData unitData; // Assign unit data in the Inspector

    public int unitName { get; private set; }
    public int attackStrength { get; private set; }
    public int attackDamageRange { get; private set; }
    public int heavyDamageMult { get; private set; }
    public int magicStrength { get; private set; }
    public int magicDamageRange { get; private set; }
    public int defense { get; private set; }

    private int _currentHP;
    public int damageToDeal;

    void Start()
    {
        // Configure the unit based on the ScriptableObject data
        _currentHP = unitData.maxHP;
        gameObject.name = unitData.unitName;
        attackStrength = unitData.attackStrength;
        attackDamageRange = unitData.attackDamageRange;
        heavyDamageMult = unitData.heavyDamageMult;
        magicStrength = unitData.magicStrength;
        magicDamageRange = unitData.magicDamageRange;
        defense = unitData.defense;
        Debug.Log($"Unit {name} created with {attackStrength} attack!");
    }

    public void Attack(Unit target)
    {
        Debug.Log($"{name} attacks {target.name}!");

        float tempDamage;

        RandomDamage();

        tempDamage = damageToDeal * target.defense;

        damageToDeal = Mathf.RoundToInt(tempDamage);

        // Reduce damage dealt if player is defending
        // will probably just increase defense on that turn
        //if (target.isDefending)
        //{
        //    damageToDeal /= 2;
        //}

        target._currentHP -= damageToDeal;

        // Damage is applied and animations play here
    }

    public void Defend()
    {
        Debug.Log($"{name} is defending!");

        // Defense applied to unit here
    }

    public void Charge()
    {
        Debug.Log($"{name} is charging their attack!");

        // isMagicCharged = true
    }

    public void MagicAttack(Unit target)
    {
        Debug.Log($"{name} attacks {target.name} with a magic attack!");

        // Damage is applied and animations play here
    }

    // Calculates random damage based on attacker's strength and damage range
    private void RandomDamage()
    {
        int damageMin = Mathf.RoundToInt(attackStrength - (attackStrength * attackDamageRange));
        int damageMax = Mathf.RoundToInt(attackStrength + (attackStrength * attackDamageRange));

        damageToDeal = Random.Range(damageMin, damageMax);
    }
}
