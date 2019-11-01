using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystemScript 
{
    public static void Saveplayer(SaveMaster SaveMaster)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        playerdatascript data = new playerdatascript(SaveMaster);

        formatter.Serialize(stream, data);
        stream.Close();

    }
    // Start is called before the first frame update
    public static playerdatascript LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            playerdatascript data = formatter.Deserialize(stream) as playerdatascript;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save File Not found In " + path);
            return null;
        }
    }
}
