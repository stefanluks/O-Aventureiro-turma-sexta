using UnityEngine;

public class Esqueleto : MonoBehaviour
{
    private int modo = 0; //0 -> Aleatorio | 1 -> Seguir
    [SerializeField] private int velocidade;
    [SerializeField] private int distancia;
    private Vector2 destino;
    private Transform jogador;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(modo == 0)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                destino,
                velocidade * Time.deltaTime
            );

            if(Vector2.Distance(transform.position, destino) < 0.1f)
            {
                NovaPosicao();
            }
        }

        if(modo == 1 && jogador != null)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                jogador.position,
                velocidade * Time.deltaTime
            );
        }
    }

    void NovaPosicao()
    {
        float x = Random.Range(-distancia, distancia);
        float y = Random.Range(-distancia, distancia);
        destino = new Vector2(x, y);
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Player")
        {
            jogador = colisao.transform;
            modo = 1;
        }
    }
    void OnTriggerExit2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Player")
        {
            jogador = null;
            modo = 0;
        }
    }
}
