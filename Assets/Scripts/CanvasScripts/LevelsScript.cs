using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

//~~~~~~    Скрипт для кнопок меню уровней (сцена "Menu", объект в канвасе "Levels Menu")    ~~~~~~//
public class LevelsScript : MonoBehaviour
{
    public GameObject levelsMenu;

    void Start()
    {
        //~~~~~~    Отключение кнопок, переводящих на уровни дальше последнего открытого    ~~~~~~//
        GameObject[] objects = GameObject.FindGameObjectsWithTag("levelButton");  // Массив объектов с тэгом "levelButton"
        int lastLevel = SavesData.LastOpenedLevel();

        foreach (GameObject btn in objects)
        {
            if (Convert.ToInt32(btn.name.Substring(5)) > lastLevel)  // Через имя кнопки узнаётся уровень, на который она переводит
            {
                btn.transform.GetComponent<UnityEngine.UI.Button>().interactable = false;
            }
        }
    }

    //~~~~~~    Нажатие на кнопку перехода на другой уровень    ~~~~~~//
    public void ButtonClick()
    {
        SceneManager.LoadScene(
            Convert.ToInt32(
                EventSystem.current.currentSelectedGameObject.name.Substring(5)));
    }
}
