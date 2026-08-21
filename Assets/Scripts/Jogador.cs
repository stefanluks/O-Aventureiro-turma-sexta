using UnityEngine;
using UnityEngine.InputSystem;

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
        rig.linearVelocity = new Vector2(direcao.x * velocidade, 0);
    }

    public void OnMove(InputAction.CallbackContext input)
    {
        direcao = input.ReadValue<Vector2>();
    }
}
