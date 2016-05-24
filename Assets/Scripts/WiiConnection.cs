using System.Runtime.InteropServices;
using UnityEngine;
using WiimoteApi;

public class WiiConnection : MonoBehaviour
{
    public Wiimote wiimote;    //Wii motes

    public Vector3 IRposition; //Wii IR position

    //Mouse Events
    private const int MOUSEEVENTF_LEFTDOWN = 0x02;

    private const int MOUSEEVENTF_LEFTUP = 0x04;

    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);

    [DllImport("user32.dll")]
    private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

    // Use this for initialization
    private void Start()
    {
        GameObject.DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        int ret;

        //If wiimote is assigned
        if (wiimote != null)
        {
            //Read Data
            do
            {
                ret = wiimote.ReadWiimoteData();
            } while (ret > 0);

            if (wiimote.Button.a)
            {
                DoMouseClick();
            }

            //Setting final position to IR's detected position
            float[] pointer = wiimote.Ir.GetPointingPosition();

            IRposition.Set(pointer[0] * Screen.width, pointer[1] * Screen.height, 0);
            //Mapping the position to screen

            SetCursorPos((int)IRposition.x + 300, (Screen.height - (int)IRposition.y) + 100);

            print("Mouse");
            print(Input.mousePosition);

            print("Wii");
            print(IRposition);
            if (Input.GetMouseButtonDown(1))
            {
                ConnectWii();
            }
        }
    }

    //Used to connect / disconnect wii
    public void ConnectWii()
    {
        //If Wiimote is detected
        if (wiimote != null)
        {
            //Disconnect wii
            WiimoteManager.Cleanup(wiimote);
            wiimote = null;
        }
        else
        {
            WiimoteManager.FindWiimotes();  //Find for connected Wii Mote

            //Check if Manager has wii mote connected
            if (WiimoteManager.HasWiimote())
            {
                //Assign our variable to the first
                wiimote = WiimoteManager.Wiimotes[0];

                if (wiimote != null)
                {
                    wiimote.SendPlayerLED(true, false, false, false);
                }

                //Setup IR Camera
                bool IRSetUp = wiimote.SetupIRCamera(IRDataType.BASIC);

                print(IRSetUp);
            }
        }
    }

    private void DoMouseClick()
    {
        //Call the imported function with the cursor's current position
        int X = (int)IRposition.x;
        int Y = (int)IRposition.y;
        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
    }
}