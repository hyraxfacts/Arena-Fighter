using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitData unitData; // Assign unit data in the Inspector

    public string unitName { get; private set; }
    public float attackStrength { get; private set; }
    public float attackDamageRange { get; private set; }
    public float heavyDamageMult { get; private set; }
    public float magicStrength { get; private set; }
    public float magicDamageRange { get; private set; }
    public float defense { get; private set; }

    public bool isMagicCharged { get; private set; }

    public int currentHP;
    public int damageToDeal;

    void Start()
    {
        // Configure the unit based on the ScriptableObject data
        currentHP = unitData.maxHP;
        gameObject.name = unitData.unitName;
        attackStrength = unitData.attackStrength;
        attackDamageRange = unitData.attackDamageRange;
        heavyDamageMult = unitData.heavyDamageMult;
        magicStrength = unitData.magicStrength;
        magicDamageRange = unitData.magicDamageRange;
        defense = unitData.defense;
        isMagicCharged = unitData.isMagicCharged;
        Debug.Log($"Unit {name} created with {attackStrength} attack!");
    }

    public void Attack(Unit target)
    {
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

        target.currentHP -= damageToDeal;

        Debug.Log($"{name} attacks {target.name} for {damageToDeal} damage!");

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

        isMagicCharged = true;
    }

    public void MagicAttack(Unit target)
    {
        if (isMagicCharged)
        {
            Debug.Log($"{name} attacks {target.name} with a magic attack for {damageToDeal} damage!");

            float tempDamage;

            RandomMagicDamage();
            tempDamage = damageToDeal * target.defense;
            damageToDeal = Mathf.RoundToInt(tempDamage);

            target.currentHP -= damageToDeal;

            // Damage is applied and animations play here
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
