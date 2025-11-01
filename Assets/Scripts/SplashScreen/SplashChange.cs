using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashChange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //GameManager.Instance.ChangeScene("MainMenu");
        SceneManager.LoadScene("MainMenu");
    }
}
