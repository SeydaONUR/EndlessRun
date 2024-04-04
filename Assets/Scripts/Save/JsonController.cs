using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonController : MonoBehaviour
{
    public static JsonController jsonInstance;
    public Data data = new Data();
    public string json;
    public string read;
    // Start is called before the first frame update
    void Start()
    {
        jsonInstance = this;
        //SaveJson();
        LoadJson();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveJson() //Save json a fale
    {
        json = JsonUtility.ToJson(data,true);
        File.WriteAllText(Application.dataPath + "/Scripts/Save/save.json", json);
        LoadJson();
    }
    public void LoadJson() //Read json from file and use data variable for use variables
    {
        string path = Application.dataPath + "/Scripts/Save/save.json";
        if (File.Exists(path))
        {
          read=File.ReadAllText(path);
          data= JsonUtility.FromJson<Data>(read);
        }
         else
        {
            Debug.Log("No data found!");
        }
    }
}
