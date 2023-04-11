using TMPro;
using UnityEngine;

public class GestionInstructions : MonoBehaviour
{
    [SerializeField] private GameObject _instructionPanel;

    [SerializeField] private TMP_Text _instructionText;

    string[] instructions = {
      "1. Bienvenu, vous devez trouver la sortie du donjon qui est une porte en bois.",
      "2. Utilisez W,A,S,D pour déplacer votre personnage dans le donjon.",
      "3. Vous devez éviter de toucher les éléments suivant: les murs avec des piques, les trappes au sol, les squelettes et les épées des squelettes dans les cages.",
      "4. Chaque obstacle blessant vous rajoute une pénalité sur votre temps d'une seconde.",
      "5. Il y a un coffre dans le niveau qui permet de faire disparaitre des obstacles pour atteindre la fin.",
      "6. Vous avez 3 niveaux à compléter." };

    private void Start()
    {
        foreach (var ligne in instructions)
        {
            _instructionText.text += ligne + "\r\n";
        }
    }

    public void AfficherPanel()
    {
        _instructionPanel.SetActive(true);
    }

    public void FermerPanel()
    {
        _instructionPanel.SetActive(!true);
    }

}
