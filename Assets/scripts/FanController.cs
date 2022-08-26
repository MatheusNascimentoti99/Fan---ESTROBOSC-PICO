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
    private Light lightComponent;
    // Start is called before the first frame update
    void Start()
    {
        lightComponent  = gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
        functionFrequency = convertInputTextToFloat(inputFunctionFrequency.text);
        nextActionFunctionTime += Time.deltaTime;
        if (nextActionFunctionTime >= 1/functionFrequency ) {
            Debug.Log(Time.time.ToString());
            nextActionFunctionTime = 0.0f;
            // execute block of code here
        }
        transform.Rotate(functionFrequency*transform.forward, 360 * Time.deltaTime * functionFrequency);
        
        sampleFrequency =   convertInputTextToFloat(inputSampleFrequency.text);
        nextSampleTime += Time.deltaTime;
        if (nextSampleTime >= 1/sampleFrequency ) {
            lightComponent.enabled = !lightComponent.enabled;
            nextSampleTime = 0.0f;
        }
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
