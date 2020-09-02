using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Choice : MonoBehaviour
{
    public int Num;
    public string MyName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        UnityEngine.Debug.Log(gameObject);
        Cards.answered(Num);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
