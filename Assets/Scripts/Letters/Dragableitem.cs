using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro; // TextMeshPro

public class DraggableItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public TextMeshProUGUI tmpText;          // Reference to the TMP text component
    public int addScore;
    public int idImg;

    [HideInInspector] public Transform parentAfterDrag;
    public Transform initParent;

    private int index;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    void Start()
    {
        initParent = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        index = transform.GetSiblingIndex();
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(150, 150);

        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        transform.SetSiblingIndex(index);

        canvasGroup.blocksRaycasts = true;
    }
}
