using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    GameManager _gameManager;
    GestionScene _scene;
    bool _collision = false;
    Player _player;


    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _player = FindObjectOfType<Player>();
    }



    private void OnCollisionEnter(Collision collision)
    {
        int noScene = SceneManager.GetActiveScene().buildIndex;

        if ((!_collision) && (collision.gameObject.tag == "Player"))
        {

            switch (noScene)
            {
                case 1:
                    _gameManager.StatistiqueNiv1(_gameManager.retournerAccrochage(), Time.time);
                    _collision = true;
                    Debug.Log("Prochain niveau...");
                    _gameManager.ReinitialiserAccrochage();
                   _scene.ChargerProchaineScene();

                    break;

                case 2:
                    _gameManager.StatistiqueNiv2(_gameManager.retournerAccrochage(), Time.time);
                    _collision = true;
                    Debug.Log("Dernier niveau...");
                    _gameManager.ReinitialiserAccrochage();
                    _scene.ChargerProchaineScene();

                    break;

                case 3:
                    _gameManager.StatistiqueNiv3(_gameManager.retournerAccrochage(), Time.time);
                    _collision = true;
                    _gameManager.calculerTempsFin(Time.time);
                    _gameManager.FinJeu();
                    _player.FinDeJeu();

                    break;


            }

        }




    }
}

