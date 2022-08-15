using UnityEngine;
using UnityEngine.EventSystems;

public class RightButton : MonoBehaviour,
    IPointerClickHandler,
    IPointerDownHandler,
    IPointerUpHandler
{
    public GameManager gameManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        gameManager.MoveCurrentBlockRight();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }
}