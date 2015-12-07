using UnityEngine;
using System.Collections;

public class TimeCentral : MonoBehaviour
{

    private static TimeCentral instance;
    public static TimeCentral Instance { get { return instance == null ? instance = FindObjectOfType<TimeCentral>() : instance; } }

    public UnityEngine.UI.Text TimePrincipal;
    public UnityEngine.UI.Text Timealerta;

    int segundos;
    int minutos;
    bool minutoszero;
    bool segundoszero;
    float tempocorrido;
    public bool alerta;
    public float tcorrido;
    bool al;
    void Start()
    {

        //tempocorrido = LevelControl.Instance.tempoDia;
        //tempocorrido = tcorrido;

        alerta = false;
        tcorrido = 1;
        TimePrincipal.text = 2 + "|" + 00;
        segundoszero = false;
        minutoszero = false;
        minutos = 1;
        segundos = 59;
        StartCoroutine(Cronometro());
    }
    void Update()
    {
        tempocorrido = tcorrido;
       // Debug.Log(tcorrido);
        if (minutoszero)
        {
            if (segundoszero)
            {
                TimePrincipal.text = 0 + "|" + 00;
                Market.Instance.LevelCompleted = true;
            }
        }
        al = alerta;
        if (al)
        {
            TimePrincipal.text = " ";
            Timealerta.text = minutos + "|" + segundos;
        }
        else
        {
            Timealerta.text = " ";
        }
    }
    IEnumerator Cronometro()
    {

        yield return new WaitForSeconds(tempocorrido);
        TimePrincipal.text = minutos + "|" + segundos;

        segundos = segundos - 1;
        if (segundos == 0)
        {
            if (minutoszero)
            {
                StartCoroutine(zerarsegundos());
            }
            segundos = 59;
            minutos--;
        }
        if (minutos == 0)
        {
            StartCoroutine(zerarminutos());
        }
        StartCoroutine(CronometroSegundos());
    }
    IEnumerator CronometroSegundos()
    {

        yield return new WaitForSeconds(tempocorrido);
        TimePrincipal.text = minutos + "|" + segundos;

        segundos = segundos - 1;
        if (segundos == 0)
        {
            if (minutoszero)
            {
                StartCoroutine(zerarsegundos());
            }
            segundos = 59;
            minutos--;
        }
        if (minutos == 0)
        {
            StartCoroutine(zerarminutos());

        }
        StartCoroutine(Cronometro());
    }


    IEnumerator zerarminutos()
    {
        yield return new WaitForSeconds(3f);
        minutoszero = true;
    }
    IEnumerator zerarsegundos()
    {
        yield return null;
        segundoszero = true;
    }
}
