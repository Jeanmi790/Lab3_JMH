using UnityEngine;

public class GameManager : MonoBehaviour
{
    int _accrochage;
    float tempsNiv1;
    float tempsNiv2;
    float tempsNiv3;
    float tempsTotal;
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
        }
    }

    
    void Start()
    {
        Instructions();
        _accrochage = 0;

    }

    void Instructions()
    {
        Debug.Log("Bienvenu, vous devez trouver la sortie du donjon qui est une porte en bois.");
        Debug.Log("Vous devez éviter de toucher au mur avec des piques, les trappes au sol et les squelettes.");
        Debug.Log("Chaque obstacle vous rajoute une pénalité sur votre temps d'une seconde.");
        Debug.Log("Il y a un coffre dans le niveau qui permet de faire disparaitre des obstacles pour atteindre la fin.");
        Debug.Log("Vous avez 3 niveaux à compléter.");
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

    public void StatistiqueNiv1(int accrochages, float temps)
    {
        tempsNiv1 = temps + (1F * accrochages);
        nbAccrochageNiv1 = accrochages;


    }

    public void StatistiqueNiv2(int accrochages, float temps)
    {
        tempsNiv2 = temps + (1F * accrochages)-tempsNiv1;
        nbAccrochageNiv2 = accrochages;

    }

    public void StatistiqueNiv3(int accrochages, float temps)
    {   
        tempsNiv3 = temps + (1F * accrochages)-tempsNiv2;
       
        nbAccrochageNiv3 = accrochages;

    }
    public void StatistiqueTotal()
    {
        tempsTotal = tempsNiv1 + tempsNiv2 + tempsNiv3;
        nbAccrochageTotal = nbAccrochageNiv1 + nbAccrochageNiv2 + nbAccrochageNiv3;

    }

    public string VoirStatistiqueNiv1()
    {
        return "Temps Niv 1: " + tempsNiv1 + " Nombre d'accrochage Niv 1: " + nbAccrochageNiv1;
    }

    public string VoirStatistiqueNiv2()
    {
        return "Temps Niv 2: " + tempsNiv2 + " Nombre d'accrochage Niv 2: " + nbAccrochageNiv2;
    }

    public string VoirStatistiqueNiv3()
    {
        return "Temps Niv 3: " + tempsNiv3 + " Nombre d'accrochage Niv 3: " + nbAccrochageNiv3;
    }

    public string VoirStatistiqueTotal()
    {
        StatistiqueTotal();
        return "Temps Total: " + tempsTotal + " Nombre d'accrochage Total: " + nbAccrochageTotal;
    }


    public void FinJeu()
    {

        Debug.Log(VoirStatistiqueNiv1());
        Debug.Log(VoirStatistiqueNiv2());
        Debug.Log(VoirStatistiqueNiv3());
        Debug.Log(VoirStatistiqueTotal());


    }

}
