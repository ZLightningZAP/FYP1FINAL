using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VirtualKeyboard : MonoBehaviour {

    public InputField InputArea;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PressedQ()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "Q";
        }
    }
    public void PressedW()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "W";
        }
    }
    public void PressedE()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "E";
        }
    }
    public void PressedR()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "R";
        }
    }
    public void PressedT()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "T";
        }
    }
    public void PressedY()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "Y";
        }
    }
    public void PressedU()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "U";
        }
    }
    public void PressedI()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "I";
        }
    }
    public void PressedO()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "O";
        }
    }
    public void PressedP()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "P";
        }
    }
    public void PressedA()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "A";
        }
    }
    public void PressedS()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "S";
        }
    }
    public void PressedD()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "D";
        }
    }
    public void PressedF()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "F";
        }
    }
    public void PressedG()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "G";
        }
    }
    public void PressedH()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "H";
        }
    }
    public void PressedJ()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "J";
        }
    }
    public void PressedK()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "K";
        }
    }
    public void PressedL()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "L";
        }
    }
    public void PressedZ()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "Z";
        }
    }
    public void PressedX()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "X";
        }
    }
    public void PressedC()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "C";
        }
    }
    public void PressedV()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "V";
        }
    }
    public void PressedB()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "B";
        }
    }
    public void PressedN()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "N";
        }
    }
    public void PressedM()
    {
        if (InputArea.text.Length < 5)
        {
            InputArea.text += "M";
        }
    }

    public void PressedBack()
    {
        InputArea.text = "";
    }

}
