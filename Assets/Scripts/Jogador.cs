using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{
    public int velocidade;
    private Vector2 direcao;
    public Rigidbody2D rig;
    public Animator animador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.linearVelocity = direcao * velocidade;
        animador.SetFloat("eixoX", direcao.x);
        animador.SetFloat("eixoY", direcao.y);
        animador.SetBool("correndo", direcao != Vector2.zero);
    }

    public void OnMove(InputAction.CallbackContext input)
    {
        direcao = input.ReadValue<Vector2>();
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Finish")
        {
            GameManager.instancia.TrocarDeFase();
        }
        if(obj.gameObject.tag == "orbe")
        {
            GameManager.instancia.ColetarOrbe();
            Destroy(obj.gameObject);
        }
    }
}
