using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instancia {private set; get;}
    public int orbesColetadas;
    public int meta = 3;
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
        if(orbesColetadas == meta)
        {
            SceneManager.LoadScene("Fase2");
            orbesColetadas = 0;
        }
    }
}
