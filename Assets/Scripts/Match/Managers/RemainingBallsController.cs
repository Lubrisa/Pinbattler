using UnityEngine;

namespace Pinbattlers.Match
{
    public class RemainingBallsController : MonoBehaviour
    {
        [SerializeField] private GameObject[] m_remainingBalls;

        private void Start()
        {
            m_remainingBalls = new GameObject[transform.childCount];

            for (int i = 0; i < m_remainingBalls.Length; i++)
            {
                m_remainingBalls[i] = transform.GetChild(i).gameObject;
            }
        }

        public void ChangeRemainingBallsShowing(int remainingBalls)
        {
            for (int i = m_remainingBalls.Length - 1; i >= 0; i--)
            {
                if (i >= remainingBalls) m_remainingBalls[i].SetActive(false);
                else if (!m_remainingBalls[i].activeSelf) m_remainingBalls[i].SetActive(true);
            }
        }
    }
}