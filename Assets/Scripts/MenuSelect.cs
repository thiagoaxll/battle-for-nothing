using System;
using System.Collections;
using CustomSystem;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelect : LegacyInputImplementation
{
    public Button[] buttons;

    [SerializeField] private int currentButtonSelected;
    [SerializeField] private bool enableMenuSelect;
    [SerializeField] private bool changedMenu;

    public bool Enable
    {
        set => enableMenuSelect = value;
    }

    void Update()
    {
        if (!enableMenuSelect) return;
        if (changedMenu) return;
        if ((Math.Abs(ButtonDirection().x) < 0.5f)) return;
        if (ButtonDirection().x > 0.5f)
        {
            if (currentButtonSelected < buttons.Length - 1)
            {
                currentButtonSelected++;
            }
            else
            {
                currentButtonSelected = 0;
            }
        }
        else if (ButtonDirection().x < -0.5f)
        {
            if (currentButtonSelected > 0)
            {
                currentButtonSelected--;
            }
            else
            {
                currentButtonSelected = buttons.Length - 1;
            }
        }

        changedMenu = true;
        StartCoroutine(DelayToChangeMenu());
        SelectButton(currentButtonSelected);
    }

    private IEnumerator DelayToChangeMenu()
    {
        yield return new WaitForSeconds(0.3f);
        changedMenu = false;
    }


    public void SelectButton(int buttonToSelect)
    {
        buttons[currentButtonSelected].Select();
    }
}