using UnityEngine;

public class MouvementSquelettesZaxis : MonoBehaviour
{
    [SerializeField] Vector3 positionDebut;
    [SerializeField] Vector3 positionFinale;
    [SerializeField] float vitesse;

    float temps;
    float rotationYFinale = 180;


    void Start()
    {
        this.transform.position = positionDebut;
        temps = Time.deltaTime;

    }

    //Update is called once per frame
    void Update()
    {
       Mouvements();

    }

    private void Mouvements()
    {
        Vector3 direction = new Vector3(0f, 0f, 1f);

        //Vérifier si la position en Z actuelle est plus grande que la position finale
        if (transform.position.z > positionFinale.z)
        {
            direction.z = 1f;
            transform.Rotate(0, rotationYFinale, 0);
        }
        //Vérifier si la position en Z actuelle est égale à la position finale
        if (transform.position.z == positionFinale.z)
        {
            direction.z = -1f;
            transform.Rotate(0, -(rotationYFinale), 0);
        }
        //Vérifier si la position en Z actuelle est plus petite que la position de début
        if (transform.position.z < positionDebut.z)
        {
            direction.z = 1f;
            transform.Rotate(0, rotationYFinale, 0);
        }

        transform.Translate(direction * temps * vitesse);
    }

}
