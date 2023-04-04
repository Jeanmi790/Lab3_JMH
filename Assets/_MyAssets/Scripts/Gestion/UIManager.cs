using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtAccrochages = default;
    [SerializeField] private TMP_Text _txtTemps = default;
    [SerializeField] private GameObject _menuPause = default;
    bool _enPause;
    int _tempsArrete = 0;
    int _tempsEcoule = 1;
    GameManager _gameManager;


    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _txtAccrochages.text = "Accrochages : " + _gameManager.retournerAccrochage();
        Time.timeScale = _tempsEcoule;
        _menuPause.SetActive(!true);
        _enPause = !true;
    }


    private void Update()
    {
        float temps = Time.time - _gameManager.retournerTempDebut();
        _txtTemps.text = "Temps : " + temps.ToString("f2");
        entrerEnPause();
    }

    private void entrerEnPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_enPause)
        {
            _menuPause.SetActive(true);
            Time.timeScale = _tempsArrete;
            _enPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _enPause)
        {
            retournerEnJeu();
        }
    }

    public void AffichageAccrochage(int accrochages)
    {
        _txtAccrochages.text = "Accrochages : " + accrochages.ToString();
    }

    public void retournerEnJeu()
    {
        _menuPause.SetActive(!true);
        Time.timeScale = _tempsEcoule;
        _enPause = !true;
    }
}
