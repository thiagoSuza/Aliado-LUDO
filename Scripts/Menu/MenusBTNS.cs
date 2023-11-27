using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusBTNS : MonoBehaviour
{
    public GameObject rulePanel,playPanel;
   

    public void ActiveRules()
    {
        rulePanel.SetActive(true);
    }

    public void DesactiveRules()
    {
        rulePanel.SetActive(false);
    }

    public void ActivePlayPanel()
    {
        playPanel.SetActive(true);
    }

    public void DesactivePlayPanel()
    {
        playPanel.SetActive(false);
    }
}
