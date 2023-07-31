using Pinbattlers.Menus;
using Pinbattlers.Player;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Localization.Settings;
using Zenject;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SavingManager : MonoBehaviour
{
    public static SavingManager Instance { get; private set; }

    [SerializeField] private PlayerData m_playerData;
    [SerializeField] private PlayerData m_freshPlayerData;

    [SerializeField] private MapsData[] m_mapsData;
    [SerializeField] private MapsData[] m_freshMapsData;

    [SerializeField] private LocalizationSettings m_localizationSettings;

    [Inject]
    private AudioMixer m_audioMixer;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(this);

        DontDestroyOnLoad(Instance);
    }

    private void Start()
    {
        LoadPlayerInfo();
        LoadMapsInfo();

        if (PlayerPrefs.GetInt("Initialized") == 0)
        {
            PlayerPrefs.SetInt("Initialized", 1);
            ResetSave();
        }

        LoadOptionsInfo();
    }

    [ContextMenu("SavePlayerData")]
    public void SavePlayerInfo()
    {
        string path = Application.persistentDataPath + "/PlayerData";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        path += "/player_data.txt";

        if (File.Exists(path))
        {
            Debug.Log("Dados existentes, apagando antigos");
            File.Delete(path);
        }
        Debug.Log("Salvando Arquivos");
        FileStream file = File.Create(path);
        new BinaryFormatter().Serialize(file, JsonUtility.ToJson(m_playerData));
        file.Close();
    }

    [ContextMenu("SaveMapsData")]
    public void SaveMapsInfo()
    {
        string path = Application.persistentDataPath + "/MapsData";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        foreach (MapsData md in m_mapsData)
        {
            string filePath = path + $"/{md.MapName}.txt";

            if (File.Exists(filePath))
            {
                Debug.Log("Dados existentes, apagando antigos");
                File.Delete(filePath);
            }
            Debug.Log("Salvando Arquivos");
            FileStream file = File.Create(filePath);
            new BinaryFormatter().Serialize(file, JsonUtility.ToJson(md));
            file.Close();
        }
    }

    public void GeneralSave()
    {
        SavePlayerInfo();
        SaveMapsInfo();
    }

    [ContextMenu("LoadInfo")]
    private void LoadPlayerInfo()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/PlayerData")) SavePlayerInfo();
        else if (File.Exists(Application.persistentDataPath + "/PlayerData/player_data.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/PlayerData/player_data.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)new BinaryFormatter().Deserialize(file), m_playerData);
            file.Close();
        }
    }

    private void LoadMapsInfo()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/MapsData")) SaveMapsInfo();
        else
        {
            string path = Application.persistentDataPath + "/MapsData";
            for (int i = 0; i < m_mapsData.Length; i++)
            {
                string filePath = path + $"/{m_mapsData[i].MapName}.txt";

                if (!File.Exists(filePath)) SaveMapsInfo();

                FileStream file = File.Open(filePath, FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)new BinaryFormatter().Deserialize(file), m_mapsData[i]);
            }
        }
    }

    private void LoadOptionsInfo()
    {
        m_localizationSettings.SetSelectedLocale(m_localizationSettings.GetAvailableLocales().Locales[PlayerPrefs.GetInt("Language")]);

        Screen.SetResolution(PlayerPrefs.GetInt("ResolutionWidth"), PlayerPrefs.GetInt("ResolutionHeight"), Screen.fullScreen);

        Screen.fullScreen = PlayerPrefs.GetInt("Fullscreen") == 0 ? true : false;

        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("GraphicsQuality"));

        m_audioMixer.SetFloat("Master", PlayerPrefs.GetFloat("MasterVolume"));
        m_audioMixer.SetFloat("Music", PlayerPrefs.GetFloat("MusicVolume"));
        m_audioMixer.SetFloat("SFX", PlayerPrefs.GetFloat("SFXVolume"));
    }

    public void ResetSave()
    {
        // Erase player file.
        if (Directory.Exists(Application.persistentDataPath + "/PlayerData") &&
            File.Exists(Application.persistentDataPath + " /PlayerData/player_data.text"))
        {
            File.Delete(Application.persistentDataPath + "/PlayerData/player_data.text");
        }

        // Erase maps file.
        if (Directory.Exists(Application.persistentDataPath + "/MapsData"))
        {
            for (int i = m_mapsData.Length - 1; i >= 0; i--)
            {
                if (File.Exists(Application.persistentDataPath + $"/MapsData/{m_mapsData[i].MapName}.text"))
                    File.Delete(Application.persistentDataPath + $"/MapsData/{m_mapsData[i].MapName}.text");
            }
        }

        // Set player prefs to its default values.
        PlayerPrefs.SetInt("Language", 0);
        PlayerPrefs.SetInt("ResolutionWidth", Display.main.systemWidth);
        PlayerPrefs.SetInt("ResolutionHeight", Display.main.systemHeight);
        PlayerPrefs.SetInt("Fullscreen", 0);
        PlayerPrefs.SetFloat("MasterVolume", 0);
        PlayerPrefs.SetFloat("MusicVolume", 0);
        PlayerPrefs.SetFloat("SFXVolume", 0);

        // Sets the options as the default values.
        LoadOptionsInfo();

        // Resets the player data and the maps data.
        m_playerData = m_freshPlayerData;
        FileStream playerFile = File.Create(Application.persistentDataPath + "/PlayerData/player_data.txt");
        new BinaryFormatter().Serialize(playerFile, JsonUtility.ToJson(m_playerData));
        playerFile.Close();

        for (int i = 0; i < m_mapsData.Length; i++)
        {
            m_mapsData[i] = m_freshMapsData[i];
            FileStream mapFile = File.Create(Application.persistentDataPath + $"/MapsData/{m_mapsData[i].MapName}.text");
            new BinaryFormatter().Serialize(mapFile, JsonUtility.ToJson(m_mapsData[i]));
            mapFile.Close();
        }

        // Reload the scene.
        SceneManager.LoadScene(0);
    }

    [ContextMenu("ForceDataReset")]
    private void ForceReset()
    {
        PlayerPrefs.SetInt("Initialized", 0);
    }
}