using System.Collections.Generic;
using UnityEngine;

public class PassageSecret : MonoBehaviour
{
    [SerializeField] List<GameObject> passages = new List<GameObject>();

    bool collision = false;
    Player player;

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();

    }

    private void OnTriggerEnter(Collider other)
    {

        if ((!collision) && (other.gameObject.tag == "Player"))
        {

            collision = true;
            player.GetComponent<MeshRenderer>().material.color = Color.green;
            foreach (GameObject passage in passages)
            {
                passage.SetActive(false);
            }

            Debug.Log("Passage débloqué");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player.GetComponent<MeshRenderer>().material.color = Color.white;
    }


}
