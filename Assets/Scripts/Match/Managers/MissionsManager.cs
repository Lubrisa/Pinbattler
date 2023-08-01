using Pinbattlers.Menus;
using Pinbattlers.Player.Resouces;
using Pinbattlers.Scriptables;
using System.Collections.Generic;
using UnityEngine;

public class MissionsManager : MonoBehaviour
{
    [field: SerializeField] public MapsData MapData { get; private set; }

    [field: SerializeField] public List<BaseChallenge> Challenges { get; private set; }

    [field: SerializeField] public List<BaseDifficultyModifier> Modifiers { get; private set; }

    private void Start()
    {
        foreach (BaseChallenge c in MapData.MapChallenges)
        {
            if (!c.Concluded) Challenges.Add(c);
        }

        foreach (BaseDifficultyModifier m in MapData.MapModifiers)
        {
            if (m.IsEnabled) Modifiers.Add(m);
            m.Effect();
        }
    }

    private void Update()
    {
        if (Challenges != null)
        {
            for (int i = 0; i < Challenges.Count; i++)
            {
                if (Challenges[i].ConclusionVerification()) Challenges.Remove(Challenges[i]);
            }
        }

        if (Modifiers != null)
        {
            for (int i = 0; i < Modifiers.Count; i++)
            {
                if (Modifiers[i].MissionVerification())
                {
                    foreach (Consumable c in Modifiers[i].Rewards)
                    {
                        GameOverMenuController.Instance.Consumables.Add(c);
                    }
                    Modifiers.Remove(Modifiers[i]);
                }
            }
        }
    }
}