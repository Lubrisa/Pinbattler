using UnityEngine;

public class SaveGame : MonoBehaviour
{
    private enum SaveType
    {
        Player,
        Maps,
        Monsters,
        General
    }

    [SerializeField] private SaveType m_saveType;

    public void Save()
    {
        if (m_saveType == SaveType.Player) SavingManager.Instance.SavePlayerInfo();
        else if (m_saveType == SaveType.Maps) SavingManager.Instance.SaveMapsInfo();
        else if (m_saveType == SaveType.Monsters) SavingManager.Instance.SaveMonstersInfo();
        else SavingManager.Instance.GeneralSave();
    }
}