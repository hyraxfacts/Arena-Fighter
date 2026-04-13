using UnityEngine;

public class Unit : MonoBehaviour
{
    public void Attack(Unit target)
    {
        Debug.Log($"{name} attacks {target.name}!");

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
}
