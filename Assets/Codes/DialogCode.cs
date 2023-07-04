using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCode : MonoBehaviour
{
    [SerializeField] GameObject npcDialogPanel1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("npc1"))
        {
            npcDialogPanel1.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("npc1"))
        {
            npcDialogPanel1.SetActive(false);
        }
    }
}
