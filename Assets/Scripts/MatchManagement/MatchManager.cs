using Pinbattlers.Menus;
using Pinbattlers.Player.Resouces;
using Pinbattlers.Scriptables;
using ScriptableObjectArchitecture;
using System.Collections.Generic;
using UnityEngine;

namespace Pinbattlers.Match
{
    public class MatchManager : MonoBehaviour
    {
        #region Properties

        public static MatchManager Instance { get; private set; }

        [field: SerializeField] public MapsData MapData { get; private set; }

        [Header("Challenges & Modifiers")]
        [SerializeField] private List<BaseChallenge> m_challenges;

        [SerializeField] private List<BaseDifficultyModifier> m_modifiers;

        [Header("Events")]
        private BaseMatchEvent m_event;

        [SerializeField] private BaseMatchEvent m_modifierEvent;

        public BaseMatchEvent ModifierEvent
        {
            get
            {
                return m_modifierEvent;
            }
            set
            {
                if (m_modifierEvent == null) m_modifierEvent = value;
            }
        }

        [Header("Score")]
        [SerializeField] private IntVariable m_fixedScoreModifier;

        [SerializeField] private IntVariable m_temporaryScoreModifier;

        [field: SerializeField] public int Score { get; private set; }
        [SerializeField] private StringEvent m_scoreTextUpdate;

        [SerializeField] private GameOverMenuController m_gameOverController;

        #endregion Properties

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else if (Instance != this) Destroy(this);
        }

        private void Start()
        {
            foreach (BaseChallenge c in MapData.MapChallenges)
            {
                if (!c.Concluded) m_challenges.Add(c);
            }

            foreach (BaseDifficultyModifier m in MapData.MapModifiers)
            {
                if (m.IsEnabled) m_modifiers.Add(m);
                m.Effect();
            }
        }

        private void Update()
        {
            for (int i = 0; i < m_challenges.Count; i++)
            {
                if (m_challenges[i].ConclusionVerification()) m_challenges.Remove(m_challenges[i]);
            }

            for (int i = 0; i < m_modifiers.Count; i++)
            {
                if (m_modifiers[i].MissionVerification())
                {
                    foreach (Consumable c in m_modifiers[i].Rewards)
                    {
                        GameOverMenuController.Instance.Consumables.Add(c);
                    }
                    m_modifiers.Remove(m_modifiers[i]);
                }
            }

            m_event?.Effect();
            m_modifierEvent?.Effect();
        }

        public void AddScore(int score)
        {
            Score += score * m_fixedScoreModifier.Value * m_temporaryScoreModifier.Value;
            m_scoreTextUpdate.Invoke("Pontuação: " + Score.ToString());
        }

        public void SwitchMatchEvent(BaseMatchEvent matchEvent)
        {
            m_event?.Exit();
            matchEvent.Enter();
            m_event = matchEvent;
        }

        public void EndMatch()
        {
            m_gameOverController.gameObject.SetActive(true);
            m_gameOverController.FeedPlayerInventory();
        }
    }
}