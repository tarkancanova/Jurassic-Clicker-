using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Overdose : MonoBehaviour
{
    [SerializeField] private Image _overdoseBarFill;
    [SerializeField] public float overdoseAmount {  get; private set; }
    private float _maxOverdoseAmount;
    [SerializeField] private float _decreaseInterval;

    private void Start()
    {
        StartCoroutine(DecraseOverTime());
        overdoseAmount = 0;
        _maxOverdoseAmount = 100;
        _decreaseInterval = 5;
    }


    private void Update()
    {
        UpdateOverdoseBar();
        
    }

    public void UpdateOverdose(float amount)
    {
        if (amount < 100) 
        { 
            overdoseAmount += amount;
        }
        else
        {
            return;
        }
    }


    public void UpdateOverdoseBar()
    {
        _overdoseBarFill.DOFillAmount(overdoseAmount/_maxOverdoseAmount, 0.5f);
    }

    private IEnumerator DecraseOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(_decreaseInterval);
            if (overdoseAmount > 0)
            {
                overdoseAmount -= 5;
            }
        }
    }
}
