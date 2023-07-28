using Pinbattlers.Match;
using Pinbattlers.Scriptables;
using TMPro;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject m_missionTextHolder;
    [SerializeField] private Transform m_content;

    public void SetMissions()
    {
        TMP_Text text = m_missionTextHolder.GetComponentInChildren<TMP_Text>();

        foreach (BaseChallenge c in MatchManager.Instance.Challenges)
        {
            text.text = c.Description;
        }

        foreach (BaseDifficultyModifier dm in MatchManager.Instance.Modifiers)
        {
            text.text = dm.Description;
        }
    }
}