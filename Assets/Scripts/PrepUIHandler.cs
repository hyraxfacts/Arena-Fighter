using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrepUIHandler : MonoBehaviour
{
    public TextMeshProUGUI roundCounterText;
    public TextMeshProUGUI opponentText;
    public GameObject prepUI;
    public GameObject victoryUI;
    public GameObject pauseMenu;
    public bool isStanceSelected;


    private void Start()
    {
        GameManager.Instance.UpdateCurrentStage();
        isStanceSelected = false;

        // Once all enemies are defeated, the victory screen is displayed
        if (GameManager.Instance.currentStage <= GameManager.Instance.currentOpponentName.Length)
        {
            roundCounterText.text = ("Round " + GameManager.Instance.currentStage);
            opponentText.text = ("Next opponent: " + GameManager.Instance.currentOpponentName[GameManager.Instance.stagesCleared]);
        }
        else
        {
            prepUI.SetActive(false);
            victoryUI.SetActive(true);

            GameManager.Instance.stagesCleared = 0;
        }
       
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            pauseMenu.SetActive(true);

        }
    }

    public void SetMartialStance()
    {
        GameManager.Instance.battleStance = 0;

        isStanceSelected = true;
    }

    public void SetBalancedStance()
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
    
    public void Unpause()
    {
        pauseMenu.SetActive(false);
    }    

    public void SaveAndQuit()
    {
        GameManager.Instance.SaveGameData();
        QuitToMenu();
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
