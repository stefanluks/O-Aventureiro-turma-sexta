using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{
    public int velocidade;
    private Vector2 direcao;
    public Rigidbody2D rig;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello, World!");
    }

    // Update is called once per frame
    void Update()
    {
        rig.linearVelocity = direcao * velocidade;
    }

    public void OnMove(InputAction.CallbackContext input)
    {
        direcao = input.ReadValue<Vector2>();
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Finish")
        {
            Debug.Log("Fase concluída!");
            SceneManager.LoadScene("fase1");
        }
        if(obj.gameObject.tag == "orbe")
        {
            Destroy(obj.gameObject);
        }
    }
}
