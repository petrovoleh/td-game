using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameManager : MonoBehaviour
{
    
    private TileScript myTile;

    private static SaveGameManager instance;

    public static SaveGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<SaveGameManager>();
            }
            return instance;
        }

    }

    public List<SaveableObject> SaveableObjects { get; private set; }

    void Awake()
    {
        SaveableObjects = new List<SaveableObject>();
    }
    [ContextMenu("Save")]
    public void Save()
    {
        PlayerPrefs.SetInt("ObjectCount", SaveableObjects.Count);
        PlayerPrefs.SetString("MapName", LevelManager.Instance.MapNumber);
        for (int i = 0; i < SaveableObjects.Count; i++)
        {
            SaveableObjects[i].Save(i);
        }
    }
    [ContextMenu("Load")]
    public void Load()
    {
        if (PlayerPrefs.HasKey("ObjectCount"))
        {
            foreach (SaveableObject obj in SaveableObjects)
            {
                if (obj != null)
                {
                    Destroy(obj.gameObject);
                }
            }

            SaveableObjects.Clear();

            int objectCount = PlayerPrefs.GetInt("ObjectCount");

            for (int i = 0; i < objectCount; i++)
            {
                string[] value = PlayerPrefs.GetString(i.ToString()).Split('_');
                GameObject tmp = null;
                switch (value[0])
                {
                    case "Grass":
                        tmp = Instantiate(Resources.Load("Grass(Clone)") as GameObject);
                        break;
                    case "Sand":
                        tmp = Instantiate(Resources.Load("Sand(Clone)") as GameObject);
                        break;
                    case "FireGrass":
                        tmp = Instantiate(Resources.Load("GrassEmp(Clone)") as GameObject);
                        myTile = tmp.transform.GetComponent<TileScript>();
                        myTile.SavePlaceTower(value[0]);
                        break;
                    case "ElectricGrass":
                        tmp = Instantiate(Resources.Load("GrassEmp(Clone)") as GameObject);
                        myTile = tmp.transform.GetComponent<TileScript>();
                        myTile.SavePlaceTower(value[0]);
                        break;
                    case "RocketGrass":
                        tmp = Instantiate(Resources.Load("GrassEmp(Clone)") as GameObject);
                        myTile = tmp.transform.GetComponent<TileScript>();
                        myTile.SavePlaceTower(value[0]);
                        break;
                    case "GooGrass":
                        tmp = Instantiate(Resources.Load("GrassEmp(Clone)") as GameObject);
                        myTile = tmp.transform.GetComponent<TileScript>();
                        myTile.SavePlaceTower(value[0]);
                        break;
                    case "IceGrass":
                        tmp = Instantiate(Resources.Load("GrassEmp(Clone)") as GameObject);
                        myTile = tmp.transform.GetComponent<TileScript>();
                        myTile.SavePlaceTower(value[0]);
                        break;

                }
                LevelManager.Instance.MapNumber = PlayerPrefs.GetString("MapName");
                if (tmp != null)
                {
                    tmp.GetComponent<SaveableObject>().Load(value);
                }

            }
        }
        else
        {
            Debug.Log("File Doesnt Exist Yet");
        }
            
    }

    public Vector3 StringToVector(string value)
    {
        //(1, 23, 3)
        value = value.Trim(new char[] { '(',')' });
        //1, 23, 3
        value = value.Replace(" ", "");
        //1,23,3
        string[] pos = value.Split(',');
        //[0]=1 [1]=23 [2]=3
        return new Vector3(float.Parse(pos[0]), float.Parse(pos[1]), float.Parse(pos[2]));
    }

    public Quaternion StringToQuaternion(string value)
    {
        return Quaternion.identity;
    }
    
    
}
