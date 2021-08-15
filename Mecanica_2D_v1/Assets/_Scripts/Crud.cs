using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crud : MonoBehaviour
{
    public GameObject itemParent, item, g_VetorEmocional;

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
            string vetorEmocao = PlayerPrefs.GetString("vemocao["+i+"]");

            if(vetorEmocao != ""){
                number++;
                GameObject tmp_item = Instantiate(item,itemParent.transform);
                tmp_item.name = i.ToString();
                tmp_item.transform.GetChild(0).GetComponent<Text>().text = number.ToString();
                tmp_item.transform.GetChild(1).GetComponent<Text>().text = vetorEmocao;
            }

        }
    }

    public void delete(GameObject item){
        string id_perf = item.name;
        PlayerPrefs.DeleteKey ("id["+id_perf+"]");
        PlayerPrefs.DeleteKey ("vemocao["+id_perf+"]");
        read();
    }

    public void create(){
        int count = PlayerPrefs.GetInt("contador");
        count++;

        // primeiro child é a emoção - segundo a input(padrão (1))
        string vetorEmocional = g_VetorEmocional.transform.GetChild(0).GetChild(1).GetComponent<InputField>().text;
        g_VetorEmocional.transform.GetChild(0).GetChild(1).GetComponent<InputField>().text= "";

        for (int i = 1; i < 6; i++)
        {
            vetorEmocional += ", "+ g_VetorEmocional.transform.GetChild(i).GetChild(1).GetComponent<InputField>().text;
            g_VetorEmocional.transform.GetChild(i).GetChild(1).GetComponent<InputField>().text= "";
        }

        PlayerPrefs.SetString("vemocao["+count+"]", vetorEmocional);
        PlayerPrefs.SetInt("contador", count);
        read();
    }

}