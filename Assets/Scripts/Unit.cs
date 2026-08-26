using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Unit : MonoBehaviour
{
    public UnitData unitData; // Assign unit data in the Inspector

    public float attackStrength { get; private set; }
    public float attackDamageRange { get; private set; }
    public float heavyDamageMult { get; private set; }
    public float magicStrength { get; private set; }
    public float magicDamageRange { get; private set; }
    public float defense { get; private set; }
    public float defendingDefense { get; private set; }
    public string enemyBehavior { get; private set; }
    public string unitName { get; private set; }
    public string unitDescription { get; private set; }

    public bool isDefending;
    public bool isMagicCharged { get; private set; }

    public bool isTurnDone;

    public int currentHP;
    public int damageToDeal;

    [SerializeField]
    private TextMeshProUGUI battleConsole;

    void Start()
    {
        // Configure variables based on ScriptableObject data
        currentHP = unitData.maxHP;
        gameObject.name = unitData.unitName;
        unitName = unitData.unitName;
        unitDescription = unitData.unitDescription;
        attackStrength = unitData.attackStrength;
        attackDamageRange = unitData.attackDamageRange;
        heavyDamageMult = unitData.heavyDamageMult;
        magicStrength = unitData.magicStrength;
        magicDamageRange = unitData.magicDamageRange;
        defense = unitData.defense;
        defendingDefense = defense / 2;
        enemyBehavior = unitData.enemyBehavior;
        isMagicCharged = unitData.isMagicCharged;
        isTurnDone = false;

        battleConsole = GameObject.Find("Battle Console Text").GetComponent<TextMeshProUGUI>();
    }

    public void Attack(Unit target)
    {
        float tempDamage;

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

        battleConsole.text = ($"{name} attacks {target.name} for {damageToDeal} damage!");

        Debug.Log($"{name} attacks {target.name} for {damageToDeal} damage!");

        // Prevents the player from taking more than one action per turn
        isTurnDone = true;
    }

    // This command is for enemy units only
    public void HeavyAttack(Unit target)
    {
        float tempDamage;

        // Calculates random damage based on attack strength and range
        RandomDamage();

        // Multiplies damage by heavy damage multiplier
        tempDamage = damageToDeal * heavyDamageMult;

        // Multiplies damage by increased defense if target is defending
        if (target.isDefending)
        {
            tempDamage = tempDamage * target.defendingDefense;
        }
        else
        {
            tempDamage = tempDamage * target.defense;
        }

        damageToDeal = Mathf.RoundToInt(tempDamage);

        // Deals damage to target
        target.currentHP -= damageToDeal;

        battleConsole.text = ($"{name} attacks with a strong attack for {damageToDeal} damage!");

        Debug.Log($"{name} attacks {target.name} for {damageToDeal} damage!");
    }

    public void Defend()
    {
        battleConsole.text = ($"{name} is defending!");
        Debug.Log($"{name} is defending!");

        // Unit takes half damage during this turn
        isDefending = true;

        // Prevents the player from taking more than one action per turn
        isTurnDone = true;
    }

    public void Charge()
    {
        battleConsole.text = ($"{name} is charging their attack!");
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

            battleConsole.text = ($"{name} attacks {target.name} with a magic attack for {damageToDeal} damage!");

            // Resets magic charge
            isMagicCharged = false;

            // Prevents the player from taking more than one action per turn
            isTurnDone = true;
        }
        else
        {
            battleConsole.text = ("Magic is not charged!");
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
