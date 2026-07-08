using UnityEngine;

[CreateAssetMenu(fileName = "NewUnitData", menuName = "Turn-Based/Unit Data")]
public class UnitData : ScriptableObject
{
    public string unitName;
    public int maxHP;
    public int attackStrength;
    public int attackDamageRange;
    public int heavyDamageMult;
    public int magicStrength;
    public int magicDamageRange;
    public int defense;
}
