using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public GameObject continueButton;

    public void ContinueSave()
    {
        // Save file loading goes here

        SceneManager.LoadScene(1);
    }

    public void NewGame()
    {
        // If save data is found, save file gets cleared here

        GameManager.Instance.stagesCleared = 0;

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode(); // Quits application in editor
#else
        Application.Quit(); // Quits application in build
#endif
    }
}
