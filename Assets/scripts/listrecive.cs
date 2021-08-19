using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class listrecive : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject New_row;
    string URL ="http://localhost:8080/leaderboard/leaderboard.php";
    void Start()
    {
        Recive_data();
    }

    public void Recive_data(){
        
        StartCoroutine(connect());
    }
    IEnumerator connect(){
            WWWForm wf = new WWWForm();
            WWW w = new WWW(URL,wf);
            yield return w;
            string nhan = w.text;
            string[] list_cut_1= new string[]{};
            list_cut_1 = nhan.Split(',');

            for(int i=0;i<(list_cut_1.Length)-1;i++){
                string dong=list_cut_1[i];
                string[] list_cut_2 = new string[]{};
                list_cut_2 = dong.Split('-');

                GameObject go = (GameObject)Instantiate(New_row);
                go.transform.SetParent(this.transform);
                go.transform.Find("ID_USER").GetComponent<Text>().text =list_cut_2[0];
                go.transform.Find("USERNAME").GetComponent<Text>().text =list_cut_2[1];
                go.transform.Find("PASSWORD").GetComponent<Text>().text =list_cut_2[2];
                go.transform.Find("LEVEL").GetComponent<Text>().text =list_cut_2[3];
                go.transform.Find("POINT").GetComponent<Text>().text =list_cut_2[4];
            }
        }
}
