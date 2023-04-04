using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionInstructions : MonoBehaviour
{
    [SerializeField] private GameObject _instructionPanel ;

  

    public void AfficherPanel()
    {
        _instructionPanel.SetActive(true);
    }

    public void FermerPanel()
    {
        _instructionPanel.SetActive(!true);
    }

}
