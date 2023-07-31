using Pinbattlers.Menus;
using Pinbattlers.Player.Resouces;
using Pinbattlers.Scriptables;
using ScriptableObjectArchitecture;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Pinbattlers.Match
{
    public class MatchManager : MonoBehaviour
    {
        #region Properties

        public static MatchManager Instance { get; private set; }

        [field: SerializeField] public MapsData MapData { get; private set; }

        [field: SerializeField] public List<BaseChallenge> Challenges { get; private set; }

        [field: SerializeField] public List<BaseDifficultyModifier> Modifiers { get; private set; }

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

        [SerializeField] private UnityEvent m_gameOver;

        [SerializeField] private GameObject[] m_remainingBalls;

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
                if (!c.Concluded) Challenges.Add(c);
            }

            foreach (BaseDifficultyModifier m in MapData.MapModifiers)
            {
                if (m.IsEnabled) Modifiers.Add(m);
                m.Effect();
            }

            ChangeRemainingBallsShowing(2);
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

        public void ChangeRemainingBallsShowing(int remainingBalls)
        {
            for (int i = m_remainingBalls.Length - 1; i >= 0; i--)
            {
                if (i >= remainingBalls) m_remainingBalls[i].SetActive(false);
                else if (!m_remainingBalls[i].activeSelf) m_remainingBalls[i].SetActive(true);
            }
        }

        public void GameOver()
        {
            m_gameOver.Invoke();
            GameOverMenuController.Instance.FeedPlayerInventory();
        }
    }
}