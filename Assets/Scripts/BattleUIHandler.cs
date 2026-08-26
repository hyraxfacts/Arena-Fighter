using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleUIHandler : MonoBehaviour
{
    public TextMeshProUGUI battleCounterText;
    public TextMeshProUGUI opponentNameText;
    public TextMeshProUGUI playerHealthUI;
    public TextMeshProUGUI opponentHealthUI;
    public TextMeshProUGUI playerStanceText;

    private BattleManager battleManager;
    private Unit playerUnit;
    private Unit enemyUnit;

    private void Start()
    {
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        playerUnit = battleManager.playerUnit;
        enemyUnit = battleManager.enemyUnit;

        battleCounterText.text = ("Round " + GameManager.Instance.currentStage);
        opponentNameText.text = (GameManager.Instance.opponentDescription);
        playerStanceText.text = (playerUnit.name);
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
