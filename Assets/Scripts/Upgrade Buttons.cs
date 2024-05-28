using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtons : MonoBehaviour
{
    public string whatWillBeUpgraded;
    public UpgradeData upgradeData;

    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnClickButton);
        }
    }

    private void OnClickButton()
    {
        switch (whatWillBeUpgraded)
        {
            case "Income":
                upgradeData.incomeMultiplier += 0.1f;
                break;
            case "Stamina":
                upgradeData.staminaMultiplier += 0.1f;
                break;
        }
    }
}
