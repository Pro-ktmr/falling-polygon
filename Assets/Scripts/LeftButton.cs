using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButton : MonoBehaviour,
    IPointerClickHandler,
    IPointerDownHandler,
    IPointerUpHandler
{
    public GameManager gameManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameManager.MoveCurrentBlockLeft();
        }
    }

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