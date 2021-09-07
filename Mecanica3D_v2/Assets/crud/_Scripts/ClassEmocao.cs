using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClassEmocao : MonoBehaviour
{

    public int raiva, medo, tristeza, alegria, nojo, confiancao;
    
    void Start()
    {

        if(raiva > 0 && raiva <= 100){
            raiva = raiva;
        }else
            raiva = 0;
        
        if(medo > 0 && medo <= 100){
            medo = medo;
        }else
            medo = 0;
        
        if(tristeza > 0 && tristeza <= 100){
            tristeza = tristeza;
        }else
            tristeza = 0;
        
        if(alegria > 0 && alegria <= 100){
            alegria = alegria;
        }else
            alegria = 0;
        
        if(nojo > 0 && nojo <= 100){
            nojo = nojo;
        }else
            nojo = 0;
        
        if(confiancao > 0 && confiancao <= 100){
            confiancao = confiancao;
        }else
            confiancao = 0;
        
    }

    public string SetJsonEmocoes()
    {
        return JsonUtility.ToJson(this);
    }

    // public static ClassEmocao CreateFromJSON(string jsonString)
    // {
    //     return JsonUtility.FromJson<ClassEmocao>(jsonString);
    // }

    void Update()
    {
        
    }
}
