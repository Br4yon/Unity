using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeradorVetorRelacionamento : MonoBehaviour
{
    public GameObject itemcheck, itemDestino;

    public void GerarVetorRelacionamento(GameObject itemSelecionado){
      
        int countadorNPCs = PlayerPrefs.GetInt("contador");

        if(countadorNPCs > 1 ){ // print("Tem mais NPCs !!!");
            // item.name (PEGA O NOME DO NPC CLICADO !!!)
            string id = itemSelecionado.transform.parent.name;
            for (int j = 0; j < itemDestino.transform.childCount; j++)
                Destroy(itemDestino.transform.GetChild(j).gameObject); 

            int name = 1;
            for (int i = 0; i <= countadorNPCs; i++)
            {

                if(PlayerPrefs.GetString("vemocao["+i+"]") != ""){
                    if( int.Parse(id) != i ){
                        GameObject tmp_item = Instantiate(itemcheck, itemDestino.transform);
                        tmp_item.transform.GetChild(1).name = i.ToString();
                        tmp_item.transform.GetChild(1).GetComponent<Text>().text = name.ToString();
                    }   name++;
                }
                
            }
        }

    }
}
