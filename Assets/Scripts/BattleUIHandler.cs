using TMPro;
using UnityEngine;

public class BattleUIHandler : MonoBehaviour
{
    public TextMeshProUGUI battleCounterText;
    public TextMeshProUGUI opponentNameText;

    private void Start()
    {
        battleCounterText.text = ("Round " + GameManager.Instance.currentStage);
        opponentNameText.text = (GameManager.Instance.currentOpponent[GameManager.Instance.stagesCleared]);
    }
}
