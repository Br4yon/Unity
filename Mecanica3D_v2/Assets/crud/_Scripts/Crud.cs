using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crud : MonoBehaviour
{
    public GameObject itemParent, item, form, npcParent; //g_VetorEmocional
    public GameObject[] npcs;

    void Start(){
        read();        
    }

    public void read(){
        int count = PlayerPrefs.GetInt("contador");

        for (int i = 0; i < itemParent.transform.childCount; i++)
            Destroy(itemParent.transform.GetChild(i).gameObject);           

        int number = 0;
        for (int i = 0; i <= count; i++)
        {
            string id = PlayerPrefs.GetString("id["+i+"]");
            string nome = PlayerPrefs.GetString("nome["+i+"]");


            if(nome != ""){
                number++;
                GameObject tmp_item = Instantiate(item,itemParent.transform);
                tmp_item.name = i.ToString();
                // ESCREVE NO CAMPO ID PARA PEGAR NO vetorRelacionamento DEPOIS
                tmp_item.transform.GetChild(0).GetComponent<Text>().name = number.ToString();
                tmp_item.transform.GetChild(0).GetComponent<Text>().text = number.ToString();            
                tmp_item.transform.GetChild(1).GetComponent<Text>().text = nome;
            }
        }
    }

    public void delete(GameObject item){
        string id_perf = item.name;
        PlayerPrefs.DeleteKey ("id["+id_perf+"]");
        PlayerPrefs.DeleteKey ("nome["+id_perf+"]");
        int count = PlayerPrefs.GetInt("contador");
        PlayerPrefs.SetInt("contador", count -1 );
        // PlayerPrefs.DeleteKey("contador");

        Destroy(GameObject.Find(item.name));
        // PlayerPrefs.DeleteKey ("vemocao["+id_perf+"]");
        read();
    }

    public void create(){
        int count = PlayerPrefs.GetInt("contador");
        count++;

        /** GRAVA O NOME DO NPC **/
        string nome = form.transform.GetChild(2).GetChild(0).GetComponent<InputField>().text;
        form.transform.GetChild(2).GetChild(0).GetComponent<InputField>().text= "";
        PlayerPrefs.SetString("nome["+count+"]", nome);
        /** INSTANCIA OS NPCS **/
        GameObject tmp_npc = Instantiate(npcs[Random.Range(0,13)], npcParent.transform);
        tmp_npc.name = count.ToString();


        // // primeiro child é a emoção - segundo a input(padrão (1))
        // string vetorEmocional = g_VetorEmocional.transform.GetChild(0).GetChild(1).GetComponent<InputField>().text;
        // g_VetorEmocional.transform.GetChild(0).GetChild(1).GetComponent<InputField>().text= "";

        // for (int i = 1; i < 6; i++)
        // {
        //     vetorEmocional += ", "+ g_VetorEmocional.transform.GetChild(i).GetChild(1).GetComponent<InputField>().text;
        //     g_VetorEmocional.transform.GetChild(i).GetChild(1).GetComponent<InputField>().text= "";
        // }

        // PlayerPrefs.SetString("vemocao["+count+"]", vetorEmocional);

        PlayerPrefs.SetInt("contador", count);
        read();
    }

}