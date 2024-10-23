using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurorialCheat : MonoBehaviour
{
   public Text textObject; 

    void Start()
    {
        string[] powers = new string[]
        {
            "2⁰ = 1 = 00000001",  
            "2¹ = 2 = 00000010",  
            "2² = 4 = 00000100", 
            "2³ = 8 = 00001000",  
            "2^4 = 16 = 00010000",
            "2^5 = 32 = 00100000", 
            "2^6 = 64 = 01000000", 
            "2^7 = 128 = 10000000" 
        };

        string result = string.Join("\n\n", powers);

        textObject.text = result;
    }
}
