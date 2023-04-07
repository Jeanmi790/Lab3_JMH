using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{

    public void RetourMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ChargerProchaineScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quitter()
    {
        Application.Quit();
    }

}
