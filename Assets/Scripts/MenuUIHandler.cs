using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject continueButton;

    private void Start()
    {
        // Shows continue button only if save data is found
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            continueButton.SetActive(true);
        }
    }

    public void ContinueSave()
    {
        GameManager.Instance.LoadData();

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
