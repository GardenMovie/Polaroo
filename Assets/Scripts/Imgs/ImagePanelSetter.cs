using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ImagePanelSetter : MonoBehaviour
{
    public Image parentImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parentImage.sprite = GameManager.Instance.selectedImg;
    }
}
