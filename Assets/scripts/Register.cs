using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Register : MonoBehaviour
{
    public InputField IDUSER;
    public InputField USERNAME;
    public InputField PASSWORD;
    public InputField LEVEL;
    public InputField POINT;

    string loginphp ="http://localhost:8080/PHP/login.php";
    public void register(){
        StartCoroutine(connect());
    }

    IEnumerator connect(){
        WWWForm wf =  new WWWForm();
        wf.AddField("id_chuyen",IDUSER.text);
        wf.AddField("user_chuyen",USERNAME.text);
        wf.AddField("pass_chuyen",PASSWORD.text);
        wf.AddField("level_chuyen",LEVEL.text);
        wf.AddField("point_chuyen",POINT.text);

        WWW w = new WWW(loginphp,wf);
        yield return w;
        string tam =w.text;
        string tam1=tam.TrimStart();
        string tam11 = tam.TrimEnd();
        if(tam11 == "thanh cong"){
            print("dang ky thanh cong");
            SceneManager.LoadScene (sceneName:"Login");
        }
        else{
            print("dang ky khong thanh cong");
        }
    }
}
