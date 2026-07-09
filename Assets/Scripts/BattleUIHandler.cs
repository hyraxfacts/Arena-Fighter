using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleUIHandler : MonoBehaviour
{
    public TextMeshProUGUI battleCounterText;
    public TextMeshProUGUI opponentNameText;
    public TextMeshProUGUI playerHealthUI;
    public TextMeshProUGUI opponentHealthUI;

    private BattleManager battleManager;
    private Unit playerUnit;
    private Unit enemyUnit;

    private void Start()
    {
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        playerUnit = battleManager.playerCurrentStance.GetComponent<Unit>();
        enemyUnit = battleManager.currentOpponent.GetComponent<Unit>();

        battleCounterText.text = ("Round " + GameManager.Instance.currentStage);
        opponentNameText.text = (enemyUnit.name);
    }

    private void Update()
    {
        playerHealthUI.text = (playerUnit.currentHP + " / 100");
        opponentHealthUI.text = (enemyUnit.currentHP + " / 100");
    }

    public void Continue()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
