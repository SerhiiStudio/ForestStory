using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Newtonsoft.Json;

public class TestSerializeData : MonoBehaviour
{
    private InputSistema input;

    private void Awake()
    {
        input = InputSistema.Instance;
    }

    private void OnEnable()
    {
        input.Input.Test.Test.performed += Serialize;
        input.Input.Test.Test.performed += Deserialize;
    }

    private void Deserialize(InputAction.CallbackContext ctx)
    {
        var obj = Serializator.LoadFromFolder<string>("From class");
        if(obj != null)
            Debug.Log(obj.ToString());
        else
            Debug.Log("Obj is null");
    }

    private void Serialize(InputAction.CallbackContext ctx)
    {
        Serializator.SaveToFolder(new MyTestClass().ToString(), "From class");
        Serializator.SaveToFolder(new MyTestStruct(){floatValue = 1}, "From struct");
        Debug.Log("Wrote serialized data");
    }


    private class MyTestClass
    {
        [JsonProperty] private int integrerValue {get; set;} = 1+1;

        public override string ToString() => "Great job";
    }
    private struct MyTestStruct
    {
        [field: SerializeField] public float floatValue;
    }
}
