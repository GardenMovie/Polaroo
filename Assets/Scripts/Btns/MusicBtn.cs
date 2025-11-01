using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MusicBtn : MonoBehaviour
{
    public int MusicMute = 0;
    public float DefaultVolume = 0.4f;
    public GameObject Bar;

    public AudioClip ClickSound;
    public Texture2D MusicOn;
    public Texture2D MusicOff;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MusicMute = GameManager.Instance.MusicMute;
        gameObject.transform.GetChild(2).GetComponent<RawImage>().texture = (MusicMute == 0) ? MusicOn : MusicOff;
        GameManager.Instance.MusicSource.volume = (MusicMute == 0) ? DefaultVolume : 0;
    }
    public void OnClicked()
    {
        GameManager.Instance.PlaySFX(ClickSound);
        MusicMute = GameManager.Instance.MusicMute;
        if (MusicMute == 0)
        {
            //Bar.SetActive(true);
            gameObject.transform.GetChild(2).GetComponent<RawImage>().texture = MusicOff;
            GameManager.Instance.MusicMute = 1;
            GameManager.Instance.MusicSource.volume = 0;
        }
        else
        {
            //Bar.SetActive(false);
            GameManager.Instance.MusicMute = 0;
            GameManager.Instance.MusicSource.volume = DefaultVolume;
            gameObject.transform.GetChild(2).GetComponent<RawImage>().texture = MusicOn;
        }
    }
}
