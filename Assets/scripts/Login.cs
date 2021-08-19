using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Login : MonoBehaviour
{

    
    public InputField USERNAME;
    public InputField PASSWORD;

    string loginphp ="http://localhost:8080/PHP/login1.php";
    public void Calllogin(){
        StartCoroutine(loginIn());
    }
    
    IEnumerator loginIn(){
        WWWForm wf =  new WWWForm();
        wf.AddField("user_chuyen",USERNAME.text);
        wf.AddField("pass_chuyen",PASSWORD.text);
        
        WWW w = new WWW(loginphp,wf);
         yield return w;
        string tam =w.text;
        string tam1=tam.TrimStart();
        string tam11 = tam.TrimEnd();
        
        if(tam11 == "thanh cong"){
            print("dang nhap thanh cong");
            SceneManager.LoadScene (sceneName:"begin");
        }
        else{
            print("dang nhap thanh cong");
            SceneManager.LoadScene (sceneName:"begin");
        }
    }

    // public void VerifyInputs(){
    //     submitButton.interactable = (USERNAME.text.Length >= 3 && PASSWORD.text.Length >=3);
    // }
}
