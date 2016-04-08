using UnityEngine;
using System.Collections;
using WiimoteApi;
using UnityEngine.UI;

public class WiiConnection : MonoBehaviour {

    public Wiimote wiimote;    //Wii motes
    public Image Crosshair;    //Crosshair for IR

    private Vector3 IRposition; //Wii IR position

	// Use this for initialization
	void Start () {

        GameObject.DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
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
            Crosshair.transform.position = IRposition;
            print(Crosshair.transform.position);
        }
	}

    public void ConnectWii()
    {
        if (wiimote != null)
        {
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
