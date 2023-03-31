using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] protected float _vitesse = 700;
    [SerializeField] protected float _rotation = 2f;
    [SerializeField] protected Vector3 positionini;
   
    Rigidbody _rbPlayer;

    private void Start()
    {

        this.transform.position = positionini;
        _rbPlayer = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        MouvementsJoueur();

    }

    private void MouvementsJoueur()
    {
        float positionX = Input.GetAxis("Horizontal");
        float positionZ = Input.GetAxis("Vertical");
        float temps = Time.fixedDeltaTime;

        Vector3 direction = new Vector3(positionX, 0f, positionZ);


        _rbPlayer.velocity = direction * temps * _vitesse;

        //Joueur qui tourne vers la direction
        direction.Normalize();

        //Vérifier que la direction n'est pas 0
        if (direction != Vector3.zero)
        {
            //Enregistrer le vecteur en rotation
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotation * Time.deltaTime);
        }

    }

    public void FinDeJeu()
    {
        this.gameObject.SetActive(false);
    }

}
