using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrepUIHandler : MonoBehaviour
{
    public TextMeshProUGUI roundCounterText;
    public TextMeshProUGUI opponentText;
    public bool isStanceSelected;


    private void Start()
    {
        GameManager.Instance.UpdateCurrentStage();
        isStanceSelected = false;

        roundCounterText.text = ("Round " + GameManager.Instance.currentStage);
        opponentText.text = ("Next opponent: " + GameManager.Instance.currentOpponentName[GameManager.Instance.stagesCleared]);
    }

    public void SetMartialStance()
    {
        GameManager.Instance.battleStance = 0;

        isStanceSelected = true;
    }

    public void SetAgilityStance()
    {
        GameManager.Instance.battleStance = 1;

        isStanceSelected = true;
    }

    public void SetMagicStance()
    {
        GameManager.Instance.battleStance = 2;

        isStanceSelected = true;
    }

    public void StartBattle()
    {
        // Requires stance selection before battle start
        if (isStanceSelected)
        {
            SceneManager.LoadScene(2);
        }
    }
}
