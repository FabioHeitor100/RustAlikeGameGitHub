using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject woodText;
    public GameObject stoneText;

    void Start()
    {
        woodText.GetComponent<UnityEngine.UI.Text>().text = 0.ToString();
        stoneText.GetComponent<UnityEngine.UI.Text>().text = 0.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
