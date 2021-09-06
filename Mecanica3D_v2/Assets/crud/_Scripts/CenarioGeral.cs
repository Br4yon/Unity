using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioGeral : MonoBehaviour
{
    private bool valida = false;
    public GameObject npcParent, botaoParametro;
    public GameObject[] npcs;

    void Start()
    {
        int count = PlayerPrefs.GetInt("contador");
        // botao = GameObject.FindGameObjectWithTag("ParametrizarNPCs");  
        for (int i = 0; i <= count; i++)
        {
            string nome = PlayerPrefs.GetString("nome["+i+"]");
            if(nome != ""){
                GameObject tmp_npc = Instantiate(npcs[Random.Range(0,13)], npcParent.transform);
                tmp_npc.name = i.ToString();
            }
        }
    }

    void FixedUpdate()
    {
        int count = PlayerPrefs.GetInt("contador");
        botaoParametro.SetActive( count > 1 ? true : false );
    }
}
