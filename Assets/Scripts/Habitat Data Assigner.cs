using UnityEngine;

public class HabitatDataAssigner : MonoBehaviour
{
    public HabitatData[] habitatDataList;
    public GameObject[] dinosParentObjectList;

    //void Awake()
    //{
    //    for (int i = 0; i < habitatDataList.Length - 1; i++)
    //    {
    //        habitatDataList[i].AssignDinosParentObject(dinosParentObjectList[i]);
    //    }
    //}

    void Awake()
    {
        if (habitatDataList.Length != dinosParentObjectList.Length)
        {
            Debug.LogError("HabitatDataList and DinosParentObjectList must have the same length");
            return;
        }

        for (int i = 0; i < habitatDataList.Length; i++)
        {
            if (habitatDataList[i] != null && dinosParentObjectList[i] != null)
            {
                habitatDataList[i].AssignDinosParentObject(dinosParentObjectList[i]);
                Debug.Log($"Assigned {dinosParentObjectList[i].name} to {habitatDataList[i].name}");
            }
            else
            {
                Debug.LogError("HabitatData or DinosParentObject is null at index " + i);
            }
        }
    }
}
