using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvas = gameObject.GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; 
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        var slotTransform = rectTransform.parent;       //Перемещает ячейку в конец списка, что бы активный объект
        slotTransform.SetAsLastSibling();               //всегда отрисовывался поверх других

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.tag == gameObject.tag)
        {
            if (gameObject.CompareTag("Item2"))
                FindObjectOfType<Missions>().GetComponent<Missions>().Item2CountChange(-2);

            if (gameObject.CompareTag("Item3"))
                FindObjectOfType<Missions>().GetComponent<Missions>().Item3CountChange(-2);

            MergeItem();    //Если Теги объектов совпадают, созадем новый и меняем счетчики для Миссий.

            Destroy(gameObject);

            Destroy(eventData.pointerDrag);
        }

        if (eventData.pointerDrag.tag != gameObject.tag)
        {
            eventData.pointerDrag.transform.localPosition = Vector3.zero;
        }

    }
    public void MergeItem()
    {
        //Используем тот же скрипт что и в Крафтере, много одинакового, но как унифицировать не придумал(
        if (gameObject.CompareTag("Item1"))
        {
            FindObjectOfType<Crafter>().GetComponent<Crafter>().CraftItem(1, transform.parent);

            FindObjectOfType<Missions>().GetComponent<Missions>().Item2CountChange(1);
        }

        if (gameObject.CompareTag("Item2"))
        {
            FindObjectOfType<Crafter>().GetComponent<Crafter>().CraftItem(2, transform.parent);

            FindObjectOfType<Missions>().GetComponent<Missions>().Item3CountChange(1);
        }

        if (gameObject.CompareTag("Item3"))
            FindObjectOfType<Crafter>().GetComponent<Crafter>().CraftItem(3, transform.parent);
    }
}
