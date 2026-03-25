using TMPro;
using UnityEngine;

public class BattleUIHandler : MonoBehaviour
{
    public TextMeshProUGUI battleCounterText;
    public TextMeshProUGUI opponentNameText;
    public TextMeshProUGUI playerHealthUI;
    public TextMeshProUGUI opponentHealthUI;

    private BattleManager battleManager;

    private void Start()
    {
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();

        battleCounterText.text = ("Round " + GameManager.Instance.currentStage);
        opponentNameText.text = (GameManager.Instance.currentOpponent[GameManager.Instance.stagesCleared]);
    }

    private void Update()
    {
        playerHealthUI.text = (battleManager.playerHealth + " / 100");
    }
}
