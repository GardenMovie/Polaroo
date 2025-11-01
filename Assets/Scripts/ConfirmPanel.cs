using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPanel : MonoBehaviour
{
    public static ConfirmPanel Instance { get; private set; }

    public GameObject panel;
    public TMP_Text messageText;
    public Button confirmButton;
    public Button closeButton;

    private string currentUrl;

    void Awake()
    {
/*         if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);  */

        Instance = this;
        panel.SetActive(false);
        confirmButton.onClick.AddListener(OnConfirm);
        closeButton.onClick.AddListener(Hide);
    }

    public void Show(string message, string url)
    {
        messageText.text = message;
        currentUrl = url;
        panel.SetActive(true);
    }

    private void OnConfirm()
    {
        if (!string.IsNullOrEmpty(currentUrl))
            if (currentUrl.ToLower() == "quit")
            {
                Debug.Log("quitting");
                Application.Quit();
            }
        if (currentUrl.ToLower() == "mainmenu")
        {
            GameManager.Instance.ChangeScene(currentUrl);
        }
        else
        {
            Application.OpenURL(currentUrl);
        }
        Hide();
    }

    private void Hide()
    {
        panel.SetActive(false);
    }
}
