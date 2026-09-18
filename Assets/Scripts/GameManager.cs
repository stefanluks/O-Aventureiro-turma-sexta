using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instancia {private set; get;}
    public int orbesColetadas;
    private int fase_atual = 0;
    [SerializeField] private List<Fase> fases;
    void Awake()
    {
        if(instancia != null && instancia != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ColetarOrbe()
    {
        orbesColetadas++;
    }

    public void TrocarDeFase()
    {
        if(orbesColetadas == fases[fase_atual].meta_orbes)
        {
            fase_atual++;
            SceneManager.LoadScene(fases[fase_atual].nome);
            orbesColetadas=0;
        }
    }
}
