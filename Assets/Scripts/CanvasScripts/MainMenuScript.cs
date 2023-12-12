using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//~~~~~~    Скрипт для кнопок главного меню (сцена "Menu", объект в канвасе "Main Menu")    ~~~~~~//
public class MainMenuScript : MonoBehaviour
{
    public int? level;
    public Button resumeBtn;  // Кнопка "Продолжить игру"
    public Button levelsBtn;  // Кнопка "Уровни"

    void Start()
    {
        //~~~~~~    Если сохранений нет, то на кнопки "Продолжить игру" и "Уровни" нельзя нажать    ~~~~~~//
        if (!File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            resumeBtn.interactable = false;
            levelsBtn.interactable = false;
        }
    }

    //~~~~~~    Метод для кнопки "Новая игра"    ~~~~~~//
    public void NewGame()
    {
        // В сохранении и внутри класса устанавливается уровень 1
        level = 1;
        SavesData.Save(1);

        // Можно взаимодействовать с кнопками "Продолжить игру" и "Уровни"
        resumeBtn.interactable = false;
        levelsBtn.interactable = false;

        // Загрузка первого уровня
        SceneManager.LoadScene(Convert.ToInt32(level));
    }

    //~~~~~~    Метод для кнопки "Продолжить игру"    ~~~~~~//
    public void Resume()
    {
        // Проверка существования файла
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            // Если в файле лежит значение выше количества уровней, то загружается последний уровень
            level = SavesData.LastOpenedLevel() > SavesData.CountLevels() ? SavesData.CountLevels() : SavesData.LastOpenedLevel();
            SceneManager.LoadScene(Convert.ToInt32(level));
        }
    }

    //~~~~~~    Метод для кнопки "Выход"    ~~~~~~//
    public void Quit()
    {
        if (level != null)
            SavesData.Save(Convert.ToInt32(level));

        Application.Quit();
    }
}
