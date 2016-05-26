using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VirtualKeyboard : MonoBehaviour
{
    public InputField InputArea;

    private bool pressed = false;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            pressed = false;
        }
    }

    public void PressedQ()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "Q";
            pressed = true;
        }
    }

    public void PressedW()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "W";
            pressed = true;
        }
    }

    public void PressedE()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "E";
            pressed = true;
        }
    }

    public void PressedR()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "R";
            pressed = true;
        }
    }

    public void PressedT()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "T";
            pressed = true;
        }
    }

    public void PressedY()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "Y";
            pressed = true;
        }
    }

    public void PressedU()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "U";
            pressed = true;
        }
    }

    public void PressedI()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "I";
            pressed = true;
        }
    }

    public void PressedO()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "O";
            pressed = true;
        }
    }

    public void PressedP()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "P";
            pressed = true;
        }
    }

    public void PressedA()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "A";
            pressed = true;
        }
    }

    public void PressedS()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "S";
            pressed = true;
        }
    }

    public void PressedD()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "D";
            pressed = true;
        }
    }

    public void PressedF()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "F";
            pressed = true;
        }
    }

    public void PressedG()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "G";
            pressed = true;
        }
    }

    public void PressedH()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "H";
            pressed = true;
        }
    }

    public void PressedJ()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "J";
            pressed = true;
        }
    }

    public void PressedK()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "K";
            pressed = true;
        }
    }

    public void PressedL()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "L";
            pressed = true;
        }
    }

    public void PressedZ()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "Z";
            pressed = true;
        }
    }

    public void PressedX()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "X";
            pressed = true;
        }
    }

    public void PressedC()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "C";
            pressed = true;
        }
    }

    public void PressedV()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "V";
            pressed = true;
        }
    }

    public void PressedB()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "B";
            pressed = true;
        }
    }

    public void PressedN()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "N";
            pressed = true;
        }
    }

    public void PressedM()
    {
        if (InputArea.text.Length < 5 && pressed == false)
        {
            InputArea.text += "M";
            pressed = true;
        }
    }

    public void PressedBack()
    {
        InputArea.text = "";
    }
}