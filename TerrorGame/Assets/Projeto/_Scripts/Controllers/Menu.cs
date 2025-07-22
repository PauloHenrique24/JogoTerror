using EasyTransition;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public TransitionSettings transition;

    public void Jogar(string nome)
    {
        TransitionManager.Instance().Transition(nome, transition, 0);
    }

    public void Opcoes()
    {
        print("Opções");
    }

    public void Sair()
    {
        Application.Quit();
    }
}
