using System.ComponentModel;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class çarpbitirbasla : MonoBehaviour
{
    solsağ ss;
    ucus uu;
    [SerializeField] ParticleSystem patla;
    [SerializeField] ParticleSystem başar;
    bool çarptin=true;
     void Start()
    {
        ss = GetComponent<solsağ>();
        uu = GetComponent<ucus>();

    }
    private void OnCollisionEnter(Collision other)
    {
    


        if (çarptin = !çarptin) { return; }
       

        switch (other.gameObject.tag)
        {

            case "baslamayeri":
                Debug.Log("basladınz");
                break;
            case "Finish":
                Debug.Log("bitirdiniz");

                Invoke("yenisahneyükle",2f);
;           başar.Play();

                break;
      

        }
        if (other.gameObject.tag == "çarpma")
        {
            uu.enabled = false;
            ss.enabled = false;
            patla.Play();

            Invoke("sahneyükle",2f);

        }//==>sahney sadece 1 defa tekrarlıyor.//tamam düzelltim.

    }
    private void Update()
    {
        yenibölümgec();
        oyunadevamet();
    }
    void sahneyükle() {
        int devam = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(devam);
    }
    void yenisahneyükle() {

        int devam = SceneManager.GetActiveScene().buildIndex;
        int i = devam + 1;
        if (i == SceneManager.sceneCountInBuildSettings) {

            i = 0;
        }
        SceneManager.LoadScene(i);

    }
    void yenibölümgec()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame) {
            
            yenisahneyükle();
        }
    }
    void oyunadevamet()
    {
        if (Keyboard.current.gKey.wasPressedThisFrame)
        {

            çarptin = !çarptin;
        }
    }

}