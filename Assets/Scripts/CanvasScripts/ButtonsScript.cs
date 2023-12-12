using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

//~~~~~~    Скрипт для разных кнопок    ~~~~~~//
public class ButtonsScript : MonoBehaviour
{
    public GameObject finish;
    public GameObject winMenu;

    //~~~~~~    Открывает сцену "Menu" (Кнопка "В меню")    ~~~~~~//
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    //~~~~~~    Снова запускает тот же уровень (кнопка "Новая игра" в меню проигрыша)    ~~~~~~//
    public void ReplayLevel()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //~~~~~~    Запускает следующий уровень (кнопка "Следующий уровень" в меню выигрыша)    ~~~~~~//
    public void NextLevel()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            int level = SavesData.CurrentLevel();
            int countLevels = SavesData.CountLevels();

            Debug.Log(level);
            Debug.Log(countLevels);

            if (level < countLevels && level != -1)
                SceneManager.LoadScene(Convert.ToInt32(level + 1));
            else if (level >= countLevels)
            {
                winMenu.SetActive(false);
                finish.SetActive(true);
            }
        }
    }
}
