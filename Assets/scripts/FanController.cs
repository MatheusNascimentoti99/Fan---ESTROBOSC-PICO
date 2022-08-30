using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FanController : MonoBehaviour
{
    private float nextActionFunctionTime = 0.0f;
    private float nextSampleTime = 0.0f;
    private float sampleFrequency;
    private float functionFrequency;
    public TMP_InputField inputFunctionFrequency;
    public TMP_InputField inputSampleFrequency;
    public GameObject fan;
    public bool isOriginalFan=false;
    public GameObject originalFan;
    public int frameRate=60;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake() {
        Time.fixedDeltaTime = 1f / frameRate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        functionFrequency = convertInputTextToFloat(inputFunctionFrequency.text);
        if(isOriginalFan){
            nextActionFunctionTime += Time.fixedDeltaTime;
            if (nextActionFunctionTime >= 1/functionFrequency ) {
                Debug.Log(Time.time.ToString());
                nextActionFunctionTime = 0.0f;
                // execute block of code here
            }
                transform.Rotate(functionFrequency*transform.forward, -360 * Time.fixedDeltaTime * functionFrequency);
        }
        
        sampleFrequency = convertInputTextToFloat(inputSampleFrequency.text);
        if (nextSampleTime >= 1/sampleFrequency && isOriginalFan==false) {
            fan.transform.rotation = originalFan.transform.rotation;
            nextSampleTime = 0.0f;
        }
        nextSampleTime += Time.fixedDeltaTime;
    }

    private static float convertInputTextToFloat(string input){
        float output = 0.0f;
        try{
            output = float.Parse(input);
        }catch{
            output = 0.0f;
        }
        return output;
    }
}
