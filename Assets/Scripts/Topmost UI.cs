using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopmostUI : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private TMPro.TMP_Text _moneyText;

    private void Update()
    {
        _moneyText.text = "Money: " + playerData.Money;
    }

}
