//Create a new Dropdown GameObject by going to the Hierarchy and clicking Create>UI>Dropdown. Attach this script to the Dropdown GameObject.
//Set your own Text in the Inspector window

using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    //Attach this script to a Dropdown GameObject
    Dropdown m_Dropdown;
    //This is the string that stores the current selection m_Text of the Dropdown
    string m_Message;
    //This Text outputs the current selection to the screen
    public Text m_Text;
    //This is the index value of the Dropdown
    int m_DropdownValue;

    void Start()
    {
        m_Dropdown = GetComponent<Dropdown>();
    }

    void Update()
    {
        //Keep the current index of the Dropdown in a variable
        m_DropdownValue = m_Dropdown.value;
        //Change the message to say the name of the current Dropdown selection using the value
        m_Message = m_Dropdown.options[m_DropdownValue].text;
        MainManager.Instance.speed_mps = m_Dropdown.value;
        //Change the onscreen Text to reflect the current Dropdown selection
        m_Text.text = m_Message;
    }
}