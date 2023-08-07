using Pinbattlers.Menus;
using Pinbattlers.Player;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Localization.Settings;
using Zenject;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using Pinbattlers.Enemies;
using Pinbattlers.Scriptables;

public class SavingManager : MonoBehaviour
{
    public static SavingManager Instance { get; private set; }

    [SerializeField] private PlayerData m_playerData;
    [SerializeField] private PlayerData m_freshPlayerData;

    [SerializeField] private MapData[] m_mapsData;

    [SerializeField] private MonsterData[] m_monstersData;

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
        if (PlayerPrefs.GetInt("Initialized") == 0)
        {
            Debug.Log("Primeira Entrada");
            PlayerPrefs.SetInt("Initialized", 1);
            ResetSave();
        }

        LoadPlayerInfo();
        LoadMapsInfo();
        LoadMonstersInfo();
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

        foreach (MapData md in m_mapsData)
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

    [ContextMenu("SaveMonstersData")]
    public void SaveMonstersInfo()
    {
        string path = Application.persistentDataPath + "/MonstersData";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        foreach (MonsterData md in m_monstersData)
        {
            string filePath = path + $"/{md.Name}.txt";

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
        SaveMonstersInfo();
    }

    [ContextMenu("LoadPlayerData")]
    private void LoadPlayerInfo()
    {
        Debug.Log("Carregando info do player");
        if (!Directory.Exists(Application.persistentDataPath + "/PlayerData")) SavePlayerInfo();
        else if (File.Exists(Application.persistentDataPath + "/PlayerData/player_data.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/PlayerData/player_data.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)new BinaryFormatter().Deserialize(file), m_playerData);
            file.Close();
        }
    }

    [ContextMenu("LoadMapsData")]
    private void LoadMapsInfo()
    {
        Debug.Log("Carregando info dos mapas");
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

    [ContextMenu("LoadOptionsData")]
    private void LoadOptionsInfo()
    {
        Debug.Log("Carregando info das opções");

        m_localizationSettings.SetSelectedLocale(m_localizationSettings.GetAvailableLocales().Locales[PlayerPrefs.GetInt("Language")]);

        Screen.SetResolution(PlayerPrefs.GetInt("ResolutionWidth"), PlayerPrefs.GetInt("ResolutionHeight"), Screen.fullScreen);

        Screen.fullScreen = PlayerPrefs.GetInt("Fullscreen") == 0 ? true : false;

        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("GraphicsQuality"));

        m_audioMixer.SetFloat("Master", PlayerPrefs.GetFloat("MasterVolume"));
        m_audioMixer.SetFloat("Music", PlayerPrefs.GetFloat("MusicVolume"));
        m_audioMixer.SetFloat("SFX", PlayerPrefs.GetFloat("SFXVolume"));
    }

    [ContextMenu("LoadMonstersData")]
    private void LoadMonstersInfo()
    {
        Debug.Log("Carregando info dos monstros");
        if (!Directory.Exists(Application.persistentDataPath + "/MonstersData")) SaveMonstersInfo();
        else
        {
            string path = Application.persistentDataPath + "/MonstersData";
            for (int i = 0; i < m_monstersData.Length; i++)
            {
                string filePath = path + $"/{m_monstersData[i].Name}.txt";

                if (!File.Exists(filePath)) SaveMonstersInfo();

                FileStream file = File.Open(filePath, FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)new BinaryFormatter().Deserialize(file), m_monstersData[i]);
            }
        }
    }

    [ContextMenu("ResetSave")]
    public void ResetSave()
    {
        // Set player prefs to its default values.
        ResetOptions();
        // Resets the player data, the maps and the monsters data.
        ResetPlayerData();
        ResetMapsData();
        ResetMonstersData();

        // Reload the scene.
        SceneManager.LoadScene(0);
    }

    private void ResetOptions()
    {
        Debug.Log("Resetando opções");
        PlayerPrefs.SetInt("Language", 0);
        PlayerPrefs.SetInt("ResolutionWidth", Display.main.systemWidth);
        PlayerPrefs.SetInt("ResolutionHeight", Display.main.systemHeight);
        PlayerPrefs.SetInt("Fullscreen", 0);
        PlayerPrefs.SetFloat("MasterVolume", 0);
        PlayerPrefs.SetFloat("MusicVolume", 0);
        PlayerPrefs.SetFloat("SFXVolume", 0);
    }

    private void ResetPlayerData()
    {
        // Erase player file.
        if (Directory.Exists(Application.persistentDataPath + "/PlayerData"))
        {
            if (File.Exists(Application.persistentDataPath + " /PlayerData/player_data.text"))
            {
                File.Delete(Application.persistentDataPath + "/PlayerData/player_data.text");
            }
        }
        else Directory.CreateDirectory(Application.persistentDataPath + "/PlayerData");

        m_playerData = m_freshPlayerData;
        SavePlayerInfo();
    }

    private void ResetMapsData()
    {
        // Erase maps file.
        if (Directory.Exists(Application.persistentDataPath + "/MapsData"))
        {
            for (int i = m_mapsData.Length - 1; i >= 0; i--)
            {
                if (File.Exists(Application.persistentDataPath + $"/MapsData/{m_mapsData[i].MapName}.text"))
                    File.Delete(Application.persistentDataPath + $"/MapsData/{m_mapsData[i].MapName}.text");
            }
        }
        else Directory.CreateDirectory(Application.persistentDataPath + "/MapsData");

        for (int i = 0; i < m_mapsData.Length; i++)
        {
            foreach (BaseChallenge bc in m_mapsData[i].MapChallenges)
            {
                bc.Concluded = false;
            }
            foreach (BaseDifficultyModifier bdm in m_mapsData[i].MapModifiers)
            {
                bdm.Reset();
            }
        }
        SaveMapsInfo();
    }

    private void ResetMonstersData()
    {
        if (Directory.Exists(Application.persistentDataPath + "/MonstersData"))
        {
            for (int i = m_monstersData.Length - 1; i >= 0; i--)
            {
                if (File.Exists(Application.persistentDataPath + $"/MonstersData/{m_monstersData[i].Name}.text"))
                    File.Delete(Application.persistentDataPath + $"/MonstersData/{m_monstersData[i].Name}.text");
            }
        }
        else Directory.CreateDirectory(Application.persistentDataPath + "/MonstersData");

        for (int i = 0; i < m_monstersData.Length; i++)
        {
            m_monstersData[i].QuantityKilled = 0;
        }
        SaveMonstersInfo();
    }

    [ContextMenu("ForceDataReset")]
    private void ForceReset() => PlayerPrefs.SetInt("Initialized", 0);
}