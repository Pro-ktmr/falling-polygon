using UnityEngine;
using UnityEngine.EventSystems;

public class RightButton : MonoBehaviour,
    IPointerClickHandler,
    IPointerDownHandler,
    IPointerUpHandler
{
    public GameManager gameManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameManager.MoveCurrentBlockRight();
        }
    }

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