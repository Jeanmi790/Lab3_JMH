using TMPro;
using UnityEngine;

public class AffichageFin : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtAccrochages = default;
    [SerializeField] private TMP_Text _txtTemps = default;
    GameManager _gameManager;


    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _txtTemps.text = _gameManager.VoirStatistiqueTotal()[0];
        _txtAccrochages.text = _gameManager.VoirStatistiqueTotal()[1];

    }

}
