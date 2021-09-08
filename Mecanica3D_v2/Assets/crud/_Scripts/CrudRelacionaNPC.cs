using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrudRelacionaNPC : MonoBehaviour
{
    public GameObject [] itemParent;
    public GameObject item, form;
    public string[] conjuntoRelacionalNPCs;

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
        
        string testeconsulta = "";

        /** form=ModalRelacionamento/child(2)=Relacionamento/child(1)=NPCaRelacionar/Viewport/Content **/
        Transform npcArelacionar = form.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(0);
        int countNPCaRelacionar = npcArelacionar.childCount;
        /** form=ModalRelacionamento/child(2)=Relacionamento/child(2)=NPCparaRelacionar/Viewport/Content **/
        Transform npcPARArelacionar = form.transform.GetChild(2).GetChild(2).GetChild(0).GetChild(0);
        int countNPCparaRelacionar = npcPARArelacionar.childCount;

        /** INSTANCIA QUE GUARDA AS EMOÇÕES **/
        Transform formVEmocoes = form.transform.GetChild(3);

        ClassEmocao vetorEmocao = new ClassEmocao();
        /** ADICIONA OS VALORES NA CLASS **/
        // vetorEmocao.raiva = 10;
        // vetorEmocao.alegria = 10;
        /** ESCREVE COMO STRING A CLASS JÁ EM JSON **/
        // string teste = vetorEmocao.SetJsonEmocoes();
        // Debug.Log( teste );    
        /** PARA DESCONVERTER É REESCRITO UMA NOVA VARIAVEL DA CLASS COM A STRING DO JSON **/
        // ClassEmocao tE = new ClassEmocao();  
        // JsonUtility.FromJsonOverwrite(teste, tE); 
        // Debug.Log( tE.raiva );

        /** PERCORRER OS NPCS A RELACIONAR **/
        for (int i = 0; i < countNPCaRelacionar; i++)
        {
            /** (DONO DA EMOÇÃO) NOME DO NPC QUE VAI RECEBER O JSON DE EMOÇÕES COM RELAÇÃO AO OUTRO NPC **/
            string nomeNPC = npcArelacionar.GetChild(i).name;

            /** VERIFICA SE O NPC DA VEZ ESTA MARCADO **/
            if(npcArelacionar.GetChild(i).GetComponent<Toggle>().isOn == true)
            {

                /** CONTA QUANTAS RELAÇÕES ESSE NPC TEM **/
                int ContRelacionaNPC = PlayerPrefs.GetInt(nomeNPC);
                ContRelacionaNPC++;

                for (int j = 0; j < countNPCparaRelacionar; j++)
                {
                    /** VERIFICA SE O NPC DA VEZ ESTA MARCADO **/
                    if(npcPARArelacionar.GetChild(j).GetComponent<Toggle>().isOn == true)
                    {
                        /** NOME DO NPC RELACIONADO **/
                        string nomeNPCrelacionado = npcPARArelacionar.GetChild(j).name;

                        /** ESCREVE NA VARIAVEL O NOME  DO NPC QUE TEM RELAÇÃO COM ELE **/
                        PlayerPrefs.SetString(nomeNPC+"["+ContRelacionaNPC+"]", nomeNPCrelacionado);

                        /** MONTA O JSON DAS EMOCOES **/
                        vetorEmocao.raiva     = int.Parse(formVEmocoes.GetChild(0).GetChild(0).GetChild(1).GetComponent<InputField>().text);
                        vetorEmocao.medo      = int.Parse(formVEmocoes.GetChild(1).GetChild(0).GetChild(1).GetComponent<InputField>().text);
                        vetorEmocao.tristeza  = int.Parse(formVEmocoes.GetChild(0).GetChild(1).GetChild(1).GetComponent<InputField>().text);
                        vetorEmocao.alegria   = int.Parse(formVEmocoes.GetChild(1).GetChild(1).GetChild(1).GetComponent<InputField>().text);
                        vetorEmocao.nojo      = int.Parse(formVEmocoes.GetChild(0).GetChild(2).GetChild(1).GetComponent<InputField>().text);
                        vetorEmocao.confianca = int.Parse(formVEmocoes.GetChild(1).GetChild(2).GetChild(1).GetComponent<InputField>().text);
                        /** FIM JSON DAS EMOCOES **/

                        string jSon = vetorEmocao.SetJsonEmocoes();

                        /** GUARDA O JSON DE EMOÇÕES **/
                        PlayerPrefs.SetString(nomeNPC+nomeNPCrelacionado+"["+ContRelacionaNPC+"]", jSon );
                        testeconsulta = nomeNPC+nomeNPCrelacionado+"["+ContRelacionaNPC+"]";

                    }

                }

                /** GUARDA QUANTAS RELAÇÕES O NPC TEM **/
                PlayerPrefs.SetInt(nomeNPC, ContRelacionaNPC);
            }          

        }

        Debug.Log("PlayerPrefs.GetString("+testeconsulta+")");
        Debug.Log(PlayerPrefs.GetString(testeconsulta));

        /** PARA DESCONVERTER É REESCRITO UMA NOVA VARIAVEL DA CLASS COM A STRING DO JSON **/
        // ClassEmocao tE = new ClassEmocao();  
        // JsonUtility.FromJsonOverwrite(teste, tE);

    }

}
