using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ClickManager : MonoBehaviour, IScriptableObjectReceiver
{
    [SerializeField] private PlayerData _playerData;
    public HabitatData habitatData;
    [SerializeField] private Overdose _overdose;
    [SerializeField] private GameObject _startPoint;


    private void Awake()
    {
    }

    public void OnClick()
    {
        if (_overdose.overdoseAmount < 100)
        {
            _playerData.Money += habitatData.clickIncome;
            _overdose.UpdateOverdose(5f);
            GameObject customer = ObjectPool.SharedInstance.GetPooledObject();
            if (customer != null)
            {
                customer.transform.position = _startPoint.transform.position;
                customer.SetActive(true);
            }
        }
        else return;
    }

    public void SetScriptableObject(HabitatData habitatD)
    {
        habitatData = habitatD;
    }
}
