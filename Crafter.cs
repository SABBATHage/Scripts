using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Crafter : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject[] items = new GameObject[4];

    public void CraftItem(int index, Transform slotTransform)                       //Создаем новый предмет
    {                                                                               //К сожалению так и не придумал
        GameObject currentItem = Instantiate(items[index], transform.parent);       //как спавнить новые Объекты в ячейках поля(

        currentItem.transform.SetParent(slotTransform, false);

        currentItem.transform.localPosition = Vector3.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        int index;
        int r = Random.Range(0, 10);
        if (r <= 7)
            index = 0;
        else
        {
            index = 1;
            FindObjectOfType<Missions>().GetComponent<Missions>().Item2CountChange(1);
        }

        CraftItem(index, transform);
    }
}
