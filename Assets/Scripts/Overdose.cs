using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Overdose : MonoBehaviour
{
    [SerializeField] private Image _overdoseBarFill;
    [SerializeField] public float overdoseAmount {  get; private set; }
    private float _maxOverdoseAmount;
    [SerializeField] private float _decreaseInterval;
    public GameObject parentObject;
    public float percentage = 30f; // Desired percentage


    List<GameObject> GetPercentageOfActiveChildren(GameObject parent, float percentage)
    {
        // Ensure the percentage is between 0 and 100
        percentage = Mathf.Clamp(percentage, 0f, 100f);

        // Get all child objects
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in parent.transform)
        {
            if (child.gameObject.activeInHierarchy)
            {
                children.Add(child.gameObject);
            }
        }

        // Calculate the number of elements to take
        int totalCount = children.Count;
        int numberOfElements = Mathf.CeilToInt(totalCount * (percentage / 100f));

        // Take the specified number of elements
        return children.Take(numberOfElements).ToList();
    }

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
            if (overdoseAmount > 99)
            {
                OverdoseEffect();
            }
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

    public void OverdoseEffect()
    {
        List<GameObject> activeChildren = GetPercentageOfActiveChildren(parentObject, percentage);

        foreach (GameObject child in activeChildren)
        {
            child.GetComponent<Customer>().Escape();
        }
    }
}
