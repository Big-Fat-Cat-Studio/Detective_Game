using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Scripts
{
    public class SaveSystem
    {
        public static void SaveProgress(SaveData dataToSave)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string savePath = Application.persistentDataPath + "/kika_and_daigo.save";
            FileStream fileStream = new FileStream(savePath, FileMode.Create);
            formatter.Serialize(fileStream, dataToSave);
            fileStream.Close();
        }
        public static SaveData LoadProgress()
        {
            string savePath = Application.persistentDataPath + "/kika_and_daigo.save";
            if(File.Exists(savePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(savePath, FileMode.Open);
                SaveData savedData = formatter.Deserialize(fileStream) as SaveData;
                fileStream.Close();
                return savedData;
            }
            else
            {
                CreateDummySave();
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream secondFileStream = new FileStream(savePath, FileMode.Open);
                SaveData savedData = formatter.Deserialize(secondFileStream) as SaveData;
                secondFileStream.Close();
                return savedData;
            }
        }
        private static void CreateDummySave()
        {
            string savePath = Application.persistentDataPath + "/kika_and_daigo.save";
            SaveData dummySave = new SaveData(1, "Tutorial", true);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(savePath, FileMode.Create);
            formatter.Serialize(fileStream, dummySave);
            fileStream.Close();
        }
    }
}