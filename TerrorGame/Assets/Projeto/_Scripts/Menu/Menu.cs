using System.Collections;
using System.Collections.Generic;
using EasyTransition;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public TransitionSettings transition;

    public List<AudioClip> sons;
    private bool sound;

    [Header("Camera Positions")]
    [SerializeField] private GameObject camera_;
    [SerializeField] private Transform menu_pos;
    [SerializeField] private Transform opcoes_pos;
    [SerializeField] private float speed;

    private bool move;
    private Vector3 pos;

    void Start()
    {
        VoltarOpc();
    }

    void LateUpdate()
    {
        if (!sound)
        {
            Sons();
            StartCoroutine(Sound());
        }

        if (move)
        {
            camera_.transform.position = Vector3.MoveTowards(camera_.transform.position, pos, speed * Time.deltaTime);
            if (Vector3.Distance(camera_.transform.position, pos) < 0.1f) move = false;
        }
    }

    IEnumerator Sound()
    {
        sound = true;
        yield return new WaitForSeconds(15f);
        sound = false;
    }

    public void Sons()
    {
        int indice = Random.Range(0, sons.Count);
        GetComponent<AudioSource>().clip = sons[indice];
        GetComponent<AudioSource>().Play();
    }

    public void Jogar(string nome)
    {
        TransitionManager.Instance().Transition(nome, transition, 0);
    }

    public void Opcoes()
    {
        move = true;
        pos = new Vector3(opcoes_pos.position.x,opcoes_pos.position.y,-10f);
    }

    public void VoltarOpc()
    {
        move = true;
        pos = new Vector3(menu_pos.position.x,menu_pos.position.y,-10f);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
