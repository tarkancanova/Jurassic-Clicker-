using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class HabitatManager : MonoBehaviour
{
    [SerializeField] HabitatData _habitat1;
    [SerializeField] HabitatData _habitat2;
    [SerializeField] HabitatData _habitat3;
    //Temporary part
    [SerializeField] ClickManager _script1;
    [SerializeField] IdleIncomeManager _script2;
    public int i = 0;
    private List<HabitatData> _habitatList;
    private List<object> _scriptList;
    [SerializeField] private TMPro.TMP_Text _habitatText;

    private void Awake()
    {
        _habitatList = new List<HabitatData> { _habitat1, _habitat2, _habitat3 };
        _scriptList = new List<object> { _script1, _script2 };

        foreach (var script in _scriptList)
        {
            if (script is IScriptableObjectReceiver receiver)
            {
                receiver.SetScriptableObject(_habitatList[i]);
            }
        }
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
}
