using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{
    public int velocidade;
    private Vector2 direcao;
    private Vector2 ultimaDirecao;
    public Rigidbody2D rig;
    public Animator animador;
    private bool atacando = false;
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
        animador.SetFloat("ultimoX", ultimaDirecao.x);
        animador.SetFloat("ultimoY", ultimaDirecao.y);
        animador.SetBool("correndo", direcao != Vector2.zero);
        animador.SetBool("atacando", atacando);
        if(direcao != Vector2.zero)
        {
            ultimaDirecao = direcao;
        }
    }
    public void OnMove(InputAction.CallbackContext input)
    {
        direcao = input.ReadValue<Vector2>();
    }
    public void OnAtack(InputAction.CallbackContext input)
    {
        if (input.performed)
        {
            atacando = true;
        }
    }

    public void PararAtaque()
    {
        atacando = false;
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
        if(obj.gameObject.tag == "Inimigo" && atacando)
        {
            // Destroy(obj.gameObject);
            obj.gameObject.GetComponent<Esqueleto>().Dano();
        }
    }
}
