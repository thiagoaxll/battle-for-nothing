using System.Collections.Generic;
using UnityEngine;
using System;

namespace CustomSystem.MenuControllers
{
    public class MenuManager : MonoBehaviour
    {
        public static MenuManager instance;
        public List<MenuReference> menuReference;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            ChangeCurrentMenuRoutine(MenuCatalog.MainMenu);
        }

        public void ChangeCurrentMenuRoutine(MenuCatalog menu)
        {
            HideUnusedMenus(menuReference, menu);
        }
        
        private void HideUnusedMenus(List<MenuReference> menusList, MenuCatalog menuToEnable)
        {
            menusList.ForEach(x => { x.menu.SetActive(x.menuName == menuToEnable); });
        }
    }

    [Serializable] 
    public struct MenuReference
    {
        public MenuCatalog menuName;
        public GameObject menu;
    }
}