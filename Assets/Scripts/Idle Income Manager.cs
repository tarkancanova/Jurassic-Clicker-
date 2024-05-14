using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleIncomeManager : MonoBehaviour, IScriptableObjectReceiver
{
    private float IncomeInterval;
    [SerializeField] private PlayerData _playerData;
    public HabitatData habitatData;

    public void SetScriptableObject(HabitatData habitatD)
    {
        habitatData = habitatD;
    }

    private void Awake()
    {
        IncomeInterval = 5f;
    }

    private void Start()
    {
        StartCoroutine(IdleIncome());
    }


    IEnumerator IdleIncome()
    {
        while (true)
        {
            yield return new WaitForSeconds(IncomeInterval);
            _playerData.Money += habitatData.idleIncome;

        }
    }
}
