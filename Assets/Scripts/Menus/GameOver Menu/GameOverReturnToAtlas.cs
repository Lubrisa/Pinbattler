using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverReturnToAtlas : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene(2);
    }
}