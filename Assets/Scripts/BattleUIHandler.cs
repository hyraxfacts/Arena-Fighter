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

    private void Start()
    {
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();

        battleCounterText.text = ("Round " + GameManager.Instance.currentStage);
        opponentNameText.text = (GameManager.Instance.currentOpponentName[GameManager.Instance.stagesCleared]);
    }

    private void Update()
    {
        //playerHealthUI.text = (battleManager.playerHealth + " / 100");
        //opponentHealthUI.text = (battleManager.enemyHealth + " / 100");
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
