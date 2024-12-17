using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.TextCore.Text;

public static class SavingSystem
{
    public static void SaveProgress(PuzzleProgress progress)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/progress.nvk";
        FileStream stream = new FileStream(path, FileMode.Create);

        PuzzleData data = new PuzzleData(progress);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PuzzleData LoadProgress()
    {
        string path = Application.persistentDataPath + "/progress.nvk";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PuzzleData data = formatter.Deserialize(stream) as PuzzleData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}