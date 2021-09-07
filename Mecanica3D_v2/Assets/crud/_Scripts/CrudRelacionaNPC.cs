using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrudRelacionaNPC : MonoBehaviour
{
    public GameObject [] itemParent;
    public GameObject item, form;

    void Start(){
        consultarNpcs();        
    }

    public void consultarNpcs(){
        /** CONSULTA NPCs **/
        int count_npcs = PlayerPrefs.GetInt("contador");       
        int number_npcs = 0;
        for (int i = 0; i <= count_npcs; i++)
        {
            string npc_id = PlayerPrefs.GetString("id["+i+"]");
            string npc_nome = PlayerPrefs.GetString("nome["+i+"]");

            if(npc_nome != ""){
                number_npcs++;
                for(int n = 0; n < 2;n++){
                    GameObject tmp_item = Instantiate(item,itemParent[n].transform);
                    // tmp_item.name = i.ToString();
                    tmp_item.name = number_npcs.ToString();
                    tmp_item.transform.GetChild(1).GetComponent<Text>().text = npc_nome;
                }
                
            }
        }
    }

    /** CADASTRAR RELACIONAMENTO E EMOÇÕES DOS NPCS **/
    public void cadastrarRMNpcs(){

        /** form=ModalRelacionamento/child(2)=Relacionamento/child(1)=NPCaRelacionar/Viewport/Content **/
        Transform npcArelacionar = form.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(0);
        int countNPCaRelacionar = npcArelacionar.childCount;
        /** form=ModalRelacionamento/child(2)=Relacionamento/child(2)=NPCparaRelacionar/Viewport/Content **/
        Transform npcPARArelacionar = form.transform.GetChild(2).GetChild(2).GetChild(0).GetChild(0);
        int countNPCparaRelacionar = npcPARArelacionar.childCount;

        /** INSTANCIA QUE GUARDA AS EMOÇÕES **/
        Transform vEmocoes = form.transform.GetChild(3);

        // ClassEmocao vetorEmocao = new ClassEmocao();
        // /** ADICIONA OS VALORES NA CLASS **/
        // vetorEmocao.raiva = 10;
        // vetorEmocao.alegria = 10;
        // /** ESCREVE COMO STRING A CLASS JÁ EM JSON **/
        // string teste = vetorEmocao.SetJsonEmocoes();
        // // Debug.Log( teste );    
        // /** PARA DESCONVERTER É REESCRITO UMA NOVA VARIAVEL DA CLASS COM A STRING DO JSON **/
        // ClassEmocao tE = new ClassEmocao();  
        // JsonUtility.FromJsonOverwrite(teste, tE); 
        // // Debug.Log( tE.raiva );

        /** PERCORRER OS NPCS A RELACIONAR **/
        for (int i = 0; i < countNPCaRelacionar; i++)
        {
            /** VERIFICA SE O NPC DA VEZ ESTA MARCADO **/
            if(npcArelacionar.GetChild(i).GetComponent<Toggle>().isOn == true)
            {

                /** PEGA O NOME DO NPCaRELACIONAR **/
                Debug.Log(npcArelacionar.GetChild(i).name);

                for (int j = 0; j < countNPCparaRelacionar; j++)
                {

                    /** VERIFICA SE O NPC DA VEZ ESTA MARCADO **/
                    if(npcPARArelacionar.GetChild(j).GetComponent<Toggle>().isOn == true)
                    {

                        /** PEGA O NOME DO NPCparaRELACIONAR **/
                        Debug.Log(npcPARArelacionar.GetChild(j).name);
                        
                        // for(int k=0; k < 6; k++)
                        // {

                        //     vEmocoes.GetChild(0).GetChild(k)

                        // }

                    }

                }

            }          

        }












    }




    // public void delete(GameObject item){
    //     string id_perf = item.name;
    //     PlayerPrefs.DeleteKey ("id["+id_perf+"]");
    //     PlayerPrefs.DeleteKey ("nome["+id_perf+"]");
    //     int count = PlayerPrefs.GetInt("c_relacionamento_emocao");
    //     PlayerPrefs.SetInt("c_relacionamento_emocao", count -1 );
    //     // PlayerPrefs.DeleteKey("contador");

    //     // Destroy(GameObject.Find(item.name));
    //     // PlayerPrefs.DeleteKey ("vemocao["+id_perf+"]");
    //     read();
    // }

    // public void create(){
    //     int count = PlayerPrefs.GetInt("c_relacionamento_emocao");
    //     count++;

    //     /** GRAVA O NOME DO NPC **/
    //     string nome = form.transform.GetChild(2).GetChild(0).GetComponent<InputField>().text;
    //     form.transform.GetChild(2).GetChild(0).GetComponent<InputField>().text= "";
    //     PlayerPrefs.SetString("nome["+count+"]", nome);


    //     // // primeiro child é a emoção - segundo a input(padrão (1))
    //     // string vetorEmocional = g_VetorEmocional.transform.GetChild(0).GetChild(1).GetComponent<InputField>().text;
    //     // g_VetorEmocional.transform.GetChild(0).GetChild(1).GetComponent<InputField>().text= "";

    //     // for (int i = 1; i < 6; i++)
    //     // {
    //     //     vetorEmocional += ", "+ g_VetorEmocional.transform.GetChild(i).GetChild(1).GetComponent<InputField>().text;
    //     //     g_VetorEmocional.transform.GetChild(i).GetChild(1).GetComponent<InputField>().text= "";
    //     // }

    //     // PlayerPrefs.SetString("vemocao["+count+"]", vetorEmocional);

    //     PlayerPrefs.SetInt("c_relacionamento_emocao", count);
    //     read();
    // }

}