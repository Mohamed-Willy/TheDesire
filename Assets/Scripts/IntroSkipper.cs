using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSkipper : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(skip), 5);
    }
    void skip()
    {
        SceneManager.LoadScene("RoomOne");
    }
}
