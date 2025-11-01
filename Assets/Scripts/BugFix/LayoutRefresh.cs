using UnityEngine;
using UnityEngine.UI;

public class LayoutRefresh : MonoBehaviour
{
public VerticalLayoutGroup layoutGroup;

    void Update()
    {
        layoutGroup.enabled = false;
}

}
