using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "MapData", menuName = "Scriptable/MapData")]
public class MapData : ScriptableObject
{
    public Map[] maps;
}
