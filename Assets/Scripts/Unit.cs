using UnityEngine;
using UnityEngine.UIElements;

public class Unit : MonoBehaviour
{
    public UnitData unitData; // Assign unit data in the Inspector

    private float attackStrength;
    public float attackDamageRange { get; private set; }
    public float heavyDamageMult { get; private set; }
    public float magicStrength { get; private set; }
    public float magicDamageRange { get; private set; }
    public float defense { get; private set; }
    public float defendingDefense { get; private set; }

    public bool isDefending;
    public bool isMagicCharged { get; private set; }

    public bool isTurnDone;

    public int currentHP;
    public int damageToDeal;

    void Start()
    {
        // Configure variables based on ScriptableObject data
        currentHP = unitData.maxHP;
        gameObject.name = unitData.unitName;
        attackStrength = unitData.attackStrength;
        attackDamageRange = unitData.attackDamageRange;
        heavyDamageMult = unitData.heavyDamageMult;
        magicStrength = unitData.magicStrength;
        magicDamageRange = unitData.magicDamageRange;
        defense = unitData.defense;
        defendingDefense = defense / 2;
        isMagicCharged = unitData.isMagicCharged;
        isTurnDone = false;

        Debug.Log($"Unit {name} has {attackStrength} attack and {currentHP} health!");
    }

    public void Attack(Unit target)
    {
        float tempDamage;

        Debug.Log($"Unit {name} has {attackStrength} attack and {currentHP} health!");

        // Calculates random damage based on attack strength and range
        RandomDamage();

        // Multiplies damage by increased defense if target is defending
        if (target.isDefending)
        {
            tempDamage = damageToDeal * target.defendingDefense;
        }
        else
        {
            tempDamage = damageToDeal * target.defense;
        }

        damageToDeal = Mathf.RoundToInt(tempDamage);

        // Deals damage to target
        target.currentHP -= damageToDeal;

        Debug.Log($"{name} attacks {target.name} for {damageToDeal} damage!");

        // Prevents the player from taking more than one action per turn
        isTurnDone = true;
    }

    public void Defend()
    {
        Debug.Log($"{name} is defending!");

        // Unit takes half damage during this turn
        isDefending = true;

        // Prevents the player from taking more than one action per turn
        isTurnDone = true;
    }

    public void Charge()
    {
        Debug.Log($"{name} is charging their attack!");

        // Allows magic to be used next turn
        isMagicCharged = true;

        // Prevents the player from taking more than one action per turn
        isTurnDone = true;
    }

    public void MagicAttack(Unit target)
    {
        if (isMagicCharged)
        {
            Debug.Log($"{name} attacks {target.name} with a magic attack for {damageToDeal} damage!");

            float tempDamage;

            // Calculates random damage based on magic strength and range
            RandomMagicDamage();

            // Multiplies damage by increased defense if target is defending
            if (target.isDefending)
            {
                tempDamage = damageToDeal * target.defendingDefense;
            }
            else
            {
                tempDamage = damageToDeal * target.defense;
            }

            damageToDeal = Mathf.RoundToInt(tempDamage);

            // Deals damage to target
            target.currentHP -= damageToDeal;

            // Resets magic charge
            isMagicCharged = false;

            // Prevents the player from taking more than one action per turn
            isTurnDone = true;
        }
        else
        {
            Debug.Log("Magic is not charged!");
        }

    }

    // Calculates random damage based on attacker's strength and damage range
    private void RandomDamage()
    {
        int damageMin = Mathf.RoundToInt(attackStrength - (attackStrength * attackDamageRange));
        int damageMax = Mathf.RoundToInt(attackStrength + (attackStrength * attackDamageRange));
        Debug.Log("Damage range is from " + damageMin + " to " + damageMax);

        damageToDeal = Random.Range(damageMin, damageMax);
    }

    // Calculates random damage based on attacker's magic and magic damage range
    private void RandomMagicDamage()
    {
        int damageMin = Mathf.RoundToInt(magicStrength - (magicStrength * magicDamageRange));
        int damageMax = Mathf.RoundToInt(magicStrength + (magicStrength * magicDamageRange));

        damageToDeal = Random.Range(damageMin, damageMax);
    }
}
