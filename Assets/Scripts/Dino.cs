using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    [SerializeField] private Overdose _overdose;



    private void CalmDown()
    {
        _overdose.UpdateOverdose(-5f);
    }
}
