using UnityEngine;

[CreateAssetMenu(fileName = "NewUnitData", menuName = "Turn-Based/Unit Data")]
public class UnitData : ScriptableObject
{
    public string unitName;
    public int maxHP;
    public float attackStrength;
    public float attackDamageRange;
    public float heavyDamageMult;
    public float magicStrength;
    public float magicDamageRange;
    public float defense;
    public bool isMagicCharged;
}
