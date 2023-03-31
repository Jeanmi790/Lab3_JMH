using UnityEngine;

public class MouvementSquelettesXaxis : MonoBehaviour
{
    [SerializeField] Vector3 positionDebut;
    [SerializeField] Vector3 positionFinale;
    [SerializeField] float vitesse = 1;

    float temps;
    float rotationYFinale = 180;


    void Start()
    {
        this.transform.position = positionDebut;
        temps = Time.deltaTime;

    }

    void Update()
    {
        Mouvements();

    }

    private void Mouvements()
    {

        Vector3 direction = new Vector3(0f, 0f, 1f);

        //Vérifier si la position en X actuelle est plus grande que la position finale
        if (transform.position.x > positionFinale.x)
        {
            direction.z = 1f;
            transform.Rotate(0, rotationYFinale, 0);
        }
        //Vérifier si la position en X actuelle est égale à la position finale
        if (transform.position.x == positionFinale.x)
        {
            direction.z = -1f;
            transform.Rotate(0, -(rotationYFinale), 0);
        }
        //Vérifier si la position en X actuelle est plus petite que la position de début
        if (transform.position.x < positionDebut.x)
        {
            direction.z = 1f;
            transform.Rotate(0, rotationYFinale, 0);
        }

        transform.Translate(direction * temps * vitesse);
    }

}

