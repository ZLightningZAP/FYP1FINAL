using UnityEngine;
using WiimoteApi;

public class WiiConnection : MonoBehaviour
{
    public Wiimote wiimote;    //Wii motes

    public Vector3 IRposition; //Wii IR position

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
                print("A down");
            }

            //Setting final position to IR's detected position
            float[] pointer = wiimote.Ir.GetPointingPosition();

            IRposition.Set(pointer[0] * Screen.width, pointer[1] * Screen.height, 0);
            //Mapping the position to screen
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
                print("Wiimote Found");

                //Assign our variable to the first
                wiimote = WiimoteManager.Wiimotes[0];

                if (wiimote != null)
                {
                    print("Wiimote Assigned");

                    wiimote.SendPlayerLED(true, false, false, false);
                }

                //Setup IR Camera
                wiimote.SetupIRCamera(IRDataType.BASIC);
            }
        }
    }
}