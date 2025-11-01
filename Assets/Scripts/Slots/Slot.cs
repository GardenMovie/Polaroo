using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Slot : MonoBehaviour, IDropHandler
{
    public bool inventory = false;
    private bool SlotFill = false;
    public int slotValue;

    void Update()
    {
        SlotFill = (transform.childCount == 0) ? false : true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableitem = dropped.GetComponent<DraggableItem>();
        if (transform.childCount == 0 || inventory == true)
        {
            draggableitem.parentAfterDrag = transform;
        }
        else
        {
            DraggableItem existingItem = GetComponentInChildren<DraggableItem>();
/*             gameManager.Instance.listIDs.Remove(existingItem.idImg); */
            existingItem.parentAfterDrag = draggableitem.parentAfterDrag;
            draggableitem.parentAfterDrag = transform;
            existingItem.OnEndDrag(eventData);
        }
        slotValue = draggableitem.addScore;
        if (inventory == false)
        {
/*             gameManager.Instance.listIDs.Add(draggableitem.idImg); */
        }
    }
}
