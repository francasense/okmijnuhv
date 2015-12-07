using UnityEngine;
using System.Collections;

public class TimeMather : MonoBehaviour
{

    private static TimeMather instance;
    public static TimeMather Instance { get { return instance == null ? (instance = FindObjectOfType<TimeMather>()) : instance; } }
    public GameObject texttime;
    public GameObject timeAlert;
    public GameObject alerta_panel;
    public UnityEngine.UI.Text timeMather;
    public bool valendo;
    public GameObject carrinhodobebe;
    public Cart cart;
    public float timeCorreto;
    public float timeRapido;
    int segundos;

    void Start()
    {
        StartCoroutine(inserirValores());


        alerta_panel.SetActive(false);
        texttime.SetActive(false);
        timeAlert.SetActive(false);
        valendo = false;
    }

    public void testeTempo()
    {

        StartCoroutine(inserirValores());

    }

    IEnumerator inserirValores()
    {
        yield return new WaitForSeconds(2f);

        timeCorreto = LevelControl.Instance.tempoDia;
        Debug.Log("valor aqui" + timeCorreto);

        switch ((int)timeCorreto)
        {
            case 1:
                timeRapido = 0.5f / 2;
                break;
            case 2:
                timeRapido = 2 / 2;
                break;
            case 3:
                timeRapido = 3 / 2;
                break;
            case 4:
                timeRapido = 4 / 2;
                break;
            case 5:
                timeRapido = 5 / 2;
                break;
            case 6:
                timeRapido = 6 / 2;

                break;
            case 7:
                timeRapido = 7 / 2;

                break;
            case 8:
                timeRapido = 8 / 2;

                break;
            case 9:
                timeRapido = 9 / 2;

                break;
            case 10:
                timeRapido = 10 / 2;

                break;
        }

    }


    public void chamarRelogio()
    {
        alerta_panel.SetActive(true);
        valendo = true;
        segundos = 29;
        texttime.SetActive(true);
        timeAlert.SetActive(true);
        TimeCentral.Instance.tcorrido = timeRapido;
        TimeCentral.Instance.alerta = true;
        StartCoroutine(Cronometro());
        StartCoroutine(destroyObj());
    }
    void Update()
    {
        //Debug.Log("segundos"+segundos);

        //timeMather.text = " "+segundos;
    }
    IEnumerator Cronometro()
    {
        yield return new WaitForSeconds(timeCorreto);
        segundos--;

        if (valendo)
        {
            StartCoroutine(CronometroSegundos());
        }
    }
    IEnumerator CronometroSegundos()
    {
        yield return new WaitForSeconds(timeCorreto);
        segundos--;
        if (valendo)
        {
            StartCoroutine(Cronometro());
        }
    }

    public void valendofalso()
    {
        valendo = false;
        texttime.SetActive(false);
        timeAlert.SetActive(false);
        alerta_panel.SetActive(false);

    }
    IEnumerator destroyObj()
    {

        yield return new WaitForSeconds(29f);
        TimeDog.Instance.valendofalso();
        alerta_panel.SetActive(false);
        TimeCentral.Instance.tcorrido = timeCorreto;
        Destroy(GameObject.FindWithTag("Matherbaby"));
        cart.DetachFrom();
        carrinhodobebe.SetActive(false);
        TimeCentral.Instance.alerta = false;
        texttime.SetActive(false);
        timeAlert.SetActive(false);
        valendo = false;
    }
}