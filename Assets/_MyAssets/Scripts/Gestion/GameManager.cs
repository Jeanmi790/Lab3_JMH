using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    int _accrochage;
    float _tempsDebut;
    float _tempsFinal;

    float tempsNiv1;
    float tempsNiv2;
    float tempsNiv3;
    int nbAccrochageNiv1;
    int nbAccrochageNiv2;
    int nbAccrochageNiv3;
    int nbAccrochageTotal;
    Player _player;

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
        }
    }

    void Start()
    {
        _accrochage = 0;
        _tempsDebut = 0;
        _tempsFinal = 0;
        nbAccrochageTotal = 0;
        _tempsDebut = Time.time;

    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 4)
        {
            Destroy(gameObject);
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


    public float retournerTempDebut()
    {
        return _tempsDebut;
    }

    public void calculerTempsFin(float temps)
    {
        _tempsFinal = temps - _tempsDebut;
    }

    public float retournerTempsFinal()
    {
        return _tempsFinal;
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
        calculerTempsFin(Time.time);
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


    //public void FinJeu()
    //{

    //    Debug.Log(VoirStatistiqueNiv1()[0] + " " + VoirStatistiqueNiv1()[1]);
    //    Debug.Log(VoirStatistiqueNiv2());
    //    Debug.Log(VoirStatistiqueNiv3());
    //    Debug.Log(VoirStatistiqueTotal());


    //}

}
