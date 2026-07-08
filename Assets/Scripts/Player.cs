using UnityEngine;

public class Player : MonoBehaviour
{
    private int playerStrength;
    private float damageRange;
    private int magicDamage;
    private int magicStrength;
    private float magicDamageRange;
    public float playerDefense;
    public int playerHealth;

    void Awake()
    {
        playerHealth = 100;

        if (GameManager.Instance.battleStance == 0)
        {
            // Sets player stats for Martial stance
            playerStrength = 17;
            damageRange = 0.15f;
            magicStrength = 20;
            magicDamageRange = 0.5f;
            playerDefense = 0.8f;
        }
        else if (GameManager.Instance.battleStance == 1)
        {
            // Sets player stats for Balanced stance
            playerStrength = 12;
            damageRange = 0.25f;
            magicStrength = 23;
            magicDamageRange = 0.4f;
            playerDefense = 0.9f;
        }
        else if (GameManager.Instance.battleStance == 2)
        {
            // Sets player stats for Magic stance
            playerStrength = 8;
            damageRange = 0.3f;
            magicStrength = 30;
            magicDamageRange = 0.3f;
            playerDefense = 0.95f;
        }
        else
        {
            Debug.Log("Invalid battle stance");
        }
    }
}
