using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AllMenus menu;
    [SerializeField] private int menuScreen;
    public int buttonID;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(menuScreen == menu.menuScreenIndex)
        {
            menu.menuOptionIndex = buttonID;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

}
