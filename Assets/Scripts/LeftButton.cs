using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButton : MonoBehaviour,
    IPointerClickHandler,
    IPointerDownHandler,
    IPointerUpHandler
{
    public GameManager gameManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        gameManager.MoveCurrentBlockLeft();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }
}