using TMPro;
using UnityEngine;

public class QualityDropdownController : MonoBehaviour
{
    private void Start()
    {
        TMP_Dropdown qualityDropdown = GetComponent<TMP_Dropdown>();

        qualityDropdown.value = QualitySettings.GetQualityLevel();
        qualityDropdown.RefreshShownValue();
    }

    public void SetNewQualityLevel(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);

        PlayerPrefs.SetInt("GraphicsQuality", qualityIndex);
    }
}