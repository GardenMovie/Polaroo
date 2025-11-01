using Unity.VisualScripting;
using UnityEngine;

public class navButton : MonoBehaviour
{
    public int globalTargetSet;
    public int addNextSet;
    public string sceneSet;
    public AudioClip click;

    public void OnButtonClicked()
    {
        GameManager.Instance.PlaySFX(click);
        if (sceneSet == "Quit" || sceneSet == "quit")
        {
            ConfirmPanel.Instance.Show("Tem certeza que deseja sair?", "quit");
            return;
        }
        if (sceneSet == "MainMenu")
        {
            ConfirmPanel.Instance.Show("Tem certeza que deseja sair?", "MainMenu");
            return;
        }
        if (sceneSet == "")
        {
            return;
        }
        GameManager.Instance.ChangeScene(sceneSet);
    }
}