using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

//~~~~~~    Класс для работы с сохранениями    ~~~~~~//
public class SavesData : MonoBehaviour
{
    private static int? level;

    //~~~~~~    Сохранение данных    ~~~~~~//
    public static void Save(int lvlToSave)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.level = lvlToSave;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    //~~~~~~    Возвращает последний открытый уровень    ~~~~~~//
    public static int LastOpenedLevel()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            level = data.level;
            Debug.Log("Game data loaded!");

            return Convert.ToInt32(level);
        }
        else
            return -1;
    }

    //~~~~~~    Удаляет файл с сохранениями    ~~~~~~//
    public static void DeleteSave()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath
              + "/MySaveData.dat");
            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }

    //~~~~~~    Возвращает открытый уровень    ~~~~~~//
    public static int CurrentLevel() => SceneManager.GetActiveScene().buildIndex;

    //~~~~~~    Возвращает общее количество уровней    ~~~~~~//
    public static int CountLevels() => SceneManager.sceneCountInBuildSettings - 1;
}

//~~~~~~    Класс для отправки данных в файл с сохранениями    ~~~~~~//
[Serializable]
class SaveData
{
    public int level;
}