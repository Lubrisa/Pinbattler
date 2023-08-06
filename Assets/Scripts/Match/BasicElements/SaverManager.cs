using ScriptableObjectArchitecture;
using UnityEngine;

public class SaverManager : MonoBehaviour
{
    [SerializeField] private FloatVariable m_saverTimer;
    private SpriteRenderer m_saverDisplay;

    [SerializeField] private float m_saverIncrease;

    private void Start()
    {
        m_saverDisplay = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        m_saverTimer.AddListener(OnSaverTimerValueChanged);
    }

    private void OnSaverTimerValueChanged()
    {
        if (m_saverTimer.Value > 0 && !m_saverDisplay.enabled) m_saverDisplay.enabled = true;
        else if (m_saverTimer.Value <= 0 && m_saverDisplay.enabled) m_saverDisplay.enabled = false;
    }

    private void OnDisable()
    {
        m_saverTimer.RemoveListener(OnSaverTimerValueChanged);
    }

    [ContextMenu("IncreaseSaver")]
    private void IncreaseSaver() => m_saverTimer.Value += m_saverIncrease;
}