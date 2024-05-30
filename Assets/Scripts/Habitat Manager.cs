using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class HabitatManager : MonoBehaviour
{
    //Temporary part
    [SerializeField] public ClickManager script1;
    [SerializeField] public IdleIncomeManager script2;
    [SerializeField] public Overdose script3;
    [SerializeField] public Customer[] customerScriptList;
    public int i = 0;
    [SerializeField] private List<HabitatData> _habitatList;
    private List<object> _scriptList;
    [SerializeField] private TMPro.TMP_Text _habitatText;

    private void Awake()
    {
        _scriptList = new List<object> { script1, script2, script3 };

        foreach (var item in customerScriptList)
        {
            _scriptList.Add(item);
        }

        foreach (var script in _scriptList)
        {
            if (script is IScriptableObjectReceiver receiver)
            {
                receiver.SetScriptableObject(_habitatList[i]);
            }
        }
    }

    private void Start()
    {
        //DisableDinos();
        //ActivateSelectedLevelDino();
    }

    private void Update()
    {
        HabitatTextUpdate();

    }

    public void NextScriptableObject()
    {
        if (i < _habitatList.Count - 1)
        {
            i++;
            foreach (var script in _scriptList)
            {
                if (script is IScriptableObjectReceiver receiver)
                {
                    receiver.SetScriptableObject(_habitatList[i]);
                }
            }
        }
        else
        {
            return;
        }
    }

    public void PreviousScriptableObject()
    {
        if (i > 0)
        {
            i--;
            foreach (var script in _scriptList)
            {
                if (script is IScriptableObjectReceiver receiver)
                {
                    receiver.SetScriptableObject(_habitatList[i]);
                }
            }
        }
        else
        {
            return;
        }
    }

    private void HabitatTextUpdate()
    {
        _habitatText.text = "Current level: " + _habitatList[i].level;
    }

    public void DisableDinos()
    {
        foreach(HabitatData data in _habitatList)
            data.dinosParentObject.SetActive(false);
    }

    public void ActivateSelectedLevelDino()
    {
        _habitatList[i].dinosParentObject.SetActive(true);
    }
}
