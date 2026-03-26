using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleUIHandler : MonoBehaviour
{
    public TextMeshProUGUI battleCounterText;
    public TextMeshProUGUI opponentNameText;

    private void Start()
    {
        battleCounterText.text = ("Round " + GameManager.Instance.currentStage);
        opponentNameText.text = (GameManager.Instance.currentOpponentName[GameManager.Instance.stagesCleared]);
    }
<<<<<<< Updated upstream
=======

    private void Update()
    {
        playerHealthUI.text = (battleManager.playerHealth + " / 100");
        opponentHealthUI.text = (battleManager.enemyHealth + " / 100");
    }

    public void Continue()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
>>>>>>> Stashed changes
}
