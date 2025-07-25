using EasyTransition;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public TransitionSettings transition;

    public void Comecar(string scene) {
        TransitionManager.Instance().Transition(scene, transition, 0);
    }
}
