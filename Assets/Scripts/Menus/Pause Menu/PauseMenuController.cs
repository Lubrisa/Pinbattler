using Pinbattlers.Match;
using Pinbattlers.Scriptables;
using TMPro;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject m_missionTextHolder;
    [SerializeField] private Transform m_content;

    private void Start()
    {
        SetMissions();
    }

    public void SetMissions()
    {
        TMP_Text text;

        if (MatchManager.Instance.Challenges != null)
        {
            foreach (BaseChallenge c in MatchManager.Instance.Challenges)
            {
                text = Instantiate(m_missionTextHolder, m_content).GetComponentInChildren<TMP_Text>();
                text.text = c.Description;
            }
        }

        if (MatchManager.Instance.Modifiers != null)
        {
            foreach (BaseDifficultyModifier dm in MatchManager.Instance.Modifiers)
            {
                text = Instantiate(m_missionTextHolder, m_content).GetComponentInChildren<TMP_Text>();
                text.text = dm.Description;
            }
        }
    }
}