using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

namespace Pinbattlers.Match
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private IntVariable m_fixedScoreModifier;
        [SerializeField] private IntVariable m_temporaryScoreModifier;
        private float m_temporaryMultiplierRemainingTime;
        public static int Score { get; private set; }

        private TMP_Text m_scoreText;

        private void Start()
        {
            m_scoreText = GetComponent<TMP_Text>();
            AddScore(0);
        }

        public void AddScore(int score)
        {
            Score += score * m_fixedScoreModifier.Value * m_temporaryScoreModifier.Value;
            m_scoreText.text = "Pontuação: " + Score.ToString();
        }

        public void AddTemporaryMultiplier(int multiplierBonus, float timeToEnd)
        {
            if (m_temporaryScoreModifier < 5)
            {
                m_temporaryScoreModifier.Value = Mathf.Clamp(m_temporaryScoreModifier + multiplierBonus, 0, 5);
                m_temporaryMultiplierRemainingTime += timeToEnd;
            }
        }

        private void Update()
        {
            if (m_temporaryMultiplierRemainingTime > 0) m_temporaryMultiplierRemainingTime -= Time.deltaTime;
        }
    }
}