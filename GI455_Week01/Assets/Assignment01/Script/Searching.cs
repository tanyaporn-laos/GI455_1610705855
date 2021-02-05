using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Searching : MonoBehaviour
{
    // Start is called before the first frame update
    List<string> sources = new List<string>();
    public InputField inputField;
    public Text ResultTxt;
    void Start()
    {
        sources.Add("Pizza");
        sources.Add("Rice");
        sources.Add("Noodle");
        sources.Add("Candy");
        sources.Add("Pie");

        ResultTxt.text = "";
    }

    public void Search()
    {
        foreach (string Subject in sources)
        {
            if (inputField.text.ToLower().Contains(Subject.ToLower()))
            {

                ResultTxt.text = inputField.text + " is found.";
                break;
            }
            else
            {

                ResultTxt.text = inputField.text + " is not found.";
            }
        }
    }
}
