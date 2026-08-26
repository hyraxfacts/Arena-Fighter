using JetBrains.Annotations;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int battleStance;
    public int stagesCleared;

    public int currentStage;

    public UnitData[] opponentData;
    public string opponentDescription;

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

        opponentDescription = opponentData[stagesCleared].unitDescription;
    }

    [System.Serializable]
    class SaveData
    {
        public int stagesCleared;
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData();
        data.stagesCleared = stagesCleared;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            stagesCleared = data.stagesCleared;
        }
    }
}
