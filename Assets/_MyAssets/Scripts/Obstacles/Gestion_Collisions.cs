using UnityEngine;
using UnityEngine.ProBuilder;

public class Gestion_Collisions : MonoBehaviour
{
    GameManager _gameManager;
    bool _collision = false;
    Player _player;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _player = FindObjectOfType<Player>();

    }

    private void OnCollisionEnter(Collision collision)
    {

        if ((!_collision) && (collision.gameObject.tag == "Player"))
        {

            _player.GetComponent<ProBuilderMesh>().GetComponent<MeshRenderer>().material.color = Color.red;
            _gameManager.AugmenterAccrochage();
            _collision = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _player.GetComponent<ProBuilderMesh>().GetComponent<MeshRenderer>().material.color = Color.white;
        _collision = false;
    }

}
