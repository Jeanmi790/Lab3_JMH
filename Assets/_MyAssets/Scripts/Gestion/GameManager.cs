using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    [SerializeField] Player player;
    int _accrochage { get; set; }
    
    float _temps { get; set; }
    float _tempsAjuste { get; set; }
    float _tempsDebut { get; set; }
    float _tempsFinal { get; set; }

    Vector3 positionini;
    Vector3 positionBody;

    float tempsNiv1;
    float tempsNiv2;
    float tempsNiv3;
    int nbAccrochageNiv1;
    int nbAccrochageNiv2;
    int nbAccrochageNiv3;
    int nbAccrochageTotal;

    private void Awake()
    {
        int nbGM = FindObjectsOfType<GameManager>().Length;
        if (nbGM > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            ChargerPlayerInfo();
        }

    }

    void Start()
    {
        _accrochage = 0;
        _tempsFinal = 0;
        nbAccrochageTotal = 0;
        ChargerPlayerInfo();

    }

    public void ChargerPlayerInfo()
    {
        player = FindObjectOfType<Player>();
        positionini = player.RetournerPosition();
        positionBody = player.GetComponent<Transform>().position;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 4)
        {
            Destroy(gameObject);
        }
        else
        {
            ChargerPlayerInfo();
        }

    }

    public void AugmenterAccrochage()
    {
        _accrochage++;
    }

    public int retournerAccrochage()
    {
        return _accrochage;
    }

    public void ReinitialiserAccrochage()
    {
        _accrochage = 0;
    }

    public void calculerTempsFin(float temps, int accrochages)
    {

        _tempsFinal = temps - _tempsDebut + (1f * accrochages);
    }
    public float retournerTempsAjuste()
    {
        return _tempsAjuste;
    }

    public float retournerTempsFinal()
    {
        return _tempsFinal;
    }

    public float TempsDebuteQuandJoueurBouge()
    {

        if (positionBody.Equals(positionini))
        {
            _temps = Time.time - _tempsDebut - _tempsAjuste;
        }
        if (!positionBody.Equals(positionini))
        {
            _tempsAjuste = Time.time - (_tempsDebut + _temps);

        }
        return _tempsAjuste;
    }

    public void StatistiqueNiv1(int accrochages, float temps)
    {
        tempsNiv1 = temps + (1F * accrochages);
        nbAccrochageNiv1 = accrochages;


    }

    public void StatistiqueNiv2(int accrochages, float temps)
    {
        tempsNiv2 = temps + (1F * accrochages) - tempsNiv1;
        nbAccrochageNiv2 = accrochages;

    }

    public void StatistiqueNiv3(int accrochages, float temps)
    {
        tempsNiv3 = temps + (1F * accrochages) - tempsNiv2;

        nbAccrochageNiv3 = accrochages;

    }

    public void StatistiqueTotal()
    {
        _tempsFinal = retournerTempsFinal();
        nbAccrochageTotal = _accrochage;
    }


    public string[] VoirStatistiqueNiv1()
    {
        string[] statistiqueN1 =
        {
            tempsNiv1.ToString("f2"),
            nbAccrochageNiv1.ToString()
        };
        return statistiqueN1;
    }

    public string[] VoirStatistiqueNiv2()
    {
        string[] statistiqueN2 =
        {
            tempsNiv2.ToString("f2"),
            nbAccrochageNiv2.ToString()
        };
        return statistiqueN2;
    }

    public string[] VoirStatistiqueNiv3()
    {
        string[] statistiqueN3 =
        {
            tempsNiv3.ToString("f2"),
            nbAccrochageNiv3.ToString()
        };
        return statistiqueN3;
    }

    public string[] VoirStatistiqueTotal()
    {
        StatistiqueTotal();
        string[] stats = { _tempsFinal.ToString("f2"), nbAccrochageTotal.ToString() };

        return stats;
    }


}
