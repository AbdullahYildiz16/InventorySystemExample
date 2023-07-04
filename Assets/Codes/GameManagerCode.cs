using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerCode : MonoBehaviour
{
    [SerializeField] GameObject menuCanvas, gameCanvas, inventoryPanel;

    bool isInventoryOpen = false;
    


    public void OnPlayBtnClicked()
    {
        menuCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }
    public void OnOptionsBtnClicked()
    {

    }
    public void OnCreditsBtnClicked()
    {

    }
    public void OnExitBtnClicked()
    {

    }
    public void OnNotesBtnClicked()
    {
        if (!isInventoryOpen)
        {
            inventoryPanel.SetActive(true);
            isInventoryOpen = true;
        }
        else
        {
            inventoryPanel.SetActive(false);
            isInventoryOpen = false;
        }
        
    }
    public void OnPhoneBtnClicked()
    {

    }
}
