using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Habitat Data")]
public class HabitatData : ScriptableObject
{
    public int level;
    public int idleIncome;
    public int clickIncome;
    public float stamina;
    public int id;
    public GameObject dinosParentObject;

    public void AssignDinosParentObject(GameObject gameObject)
    {
        dinosParentObject = gameObject;
    }
}
