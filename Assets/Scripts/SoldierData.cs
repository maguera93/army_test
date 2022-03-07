using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "DataSoldier")]
public class SoldierData : ScriptableObject
{
    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private Sprite _icon;
    
    public GameObject prefab
    {
        get
        {
            return _prefab;
        }
    }

    public Sprite icon
    {
        get
        {
            return _icon;
        }
    }

    public string key
    {
        get
        {
            string path = AssetDatabase.GetAssetPath(this);
            return AssetDatabase.AssetPathToGUID(path);
        }
    }
}
