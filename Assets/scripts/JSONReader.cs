/*using UnityEngine;
using System.IO;

[System.Serializable]
public class GameData
{
    public PlayerData player_data;
    public PulpitData pulpit_data;
}

[System.Serializable]
public class PlayerData
{
    public float speed;
}

[System.Serializable]
public class PulpitData
{
    public float min_pulpit_destroy_time;
    public float max_pulpit_destroy_time;
    public float pulpit_spawn_time;
}

public class JSONReader : MonoBehaviour
{
    public static JSONReader instance;
    public GameData gameData;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadGameData();
    }

    private void LoadGameData()
    {
        string filePath = Path.Combine();

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(dataAsJson);
        }
        else
        {
            Debug.LogError("Cannot find game data file!");
        }
    }
}*/

using UnityEngine;
using System.IO;

[System.Serializable]
public class DoofusDairy
{
    public float moveSpeed;
    public float minSpawnTime;
    public float maxSpawnTime;
}

public class GameSettingsLoader : MonoBehaviour
{
    public DoofusDairy gameSettings;

    private void Awake()
    {
        LoadGameSettings();
    }

    void LoadGameSettings()
    {
        string jsonText = File.ReadAllText(Application.streamingAssetsPath + "/DoofusDiary.json");
        gameSettings = JsonUtility.FromJson<DoofusDairy>(jsonText);

        // Apply settings to the game
        // Example: FindObjectOfType<PlayerMovement>().moveSpeed = gameSettings.moveSpeed;
    }
}

