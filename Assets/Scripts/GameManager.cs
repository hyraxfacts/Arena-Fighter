using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int battleStance;
    public int stagesCleared;

    public int currentStage;
    public string[] currentOpponentName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateCurrentStage()
    {
        currentStage = stagesCleared + 1;
    }
}
