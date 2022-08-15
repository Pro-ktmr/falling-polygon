using UnityEngine;
using UnityEngine.EventSystems;

public class DropButton : MonoBehaviour,
    IPointerClickHandler,
    IPointerDownHandler,
    IPointerUpHandler
{
    public GameManager gameManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameManager.DropCurrentBlock();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameManager.DropCurrentBlock();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }
}