using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Card : MonoBehaviour
{
    public void Hide() =>
        gameObject.GetComponent<CanvasGroup>().alpha = 0;

    public void Show() =>
        gameObject.GetComponent<CanvasGroup>().alpha = 1;
}
