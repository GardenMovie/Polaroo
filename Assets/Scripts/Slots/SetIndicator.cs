using UnityEngine;
using UnityEngine.UI;

public class SetIndicator : MonoBehaviour
{
    public Image Indicator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetIndicatorColor(Color color)
    {
        Indicator.color = color;
    }
}
