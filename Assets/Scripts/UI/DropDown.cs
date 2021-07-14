using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    public Dropdown FBDropdown;
    public Dropdown TDropdown;
    public Dropdown ModDropdown;
    public Dropdown MDDropdown;
    public Dropdown GDropdown;
    public Dropdown PMDropdown;

    public string service = "PP";
    public string type = "DIRECTIVA";

    //Frecuency Band
    public string FB = "";
    //Technology
    public string T = "";
    //Modulation
    public string Mod = "";
    //Propagation Model
    public string PM = "";
    //Modulation Dir
    public string MD = "";
    //Gain
    public string G = "";

    public int valFB, valT, valMod, valPM, valMD, valG;

    void Start()
    {
        assingListFB(valFB);
    }
    // SOLO ESTA FUNCION TIENE LOS 2 SERVICIOS INCLUIDOS
    public void assingListFB(int valFB)
    {
        if (service == "TV")
        {
            List<string> itemsFB = new List<string>() { " ", "470 - 614M" };
            FBDropdown.AddOptions(itemsFB);
            if (valFB == 1)
            {
                FB = "470 - 614M";
            }
        }
        else if (service == "PP")
        {
            List<string> itemsFB = new List<string>() { " ", "3G - 80G" };
            FBDropdown.AddOptions(itemsFB);
            if (valFB == 1)
            {
                FB = "3G - 80G";
            }
        }

        assingListT(valT);

    }

    public void assingListT(int valT)
    {
        //TV service
        if (FB == "470 - 614M")
        {
            List<string> itemsT = new List<string>() { " ", "ISDB-TB", "DVB-T2" };
            TDropdown.AddOptions(itemsT);

            if (valT == 1)
            {
                T = "ISDB-TB";
            }
            if (valT == 2)
            {
                T = "DVB-T2";
            }
        }
        //PP service
        if (FB == "3G - 80G")
        {
            List<string> itemsT = new List<string>() { " " };
            TDropdown.AddOptions(itemsT);

            if (valT == 0)
            {
                T = " ";
            }
        }
        assingListMod(valMod);
    }

    public void assingListMod(int valMod)
    {
        //TV service
        if (T == "ISDB-TB")
        {
            List<string> itemsMod = new List<string>() { " ", "QPSK", "16-QAM", "64-QAM", "DQPSK" };
            ModDropdown.AddOptions(itemsMod);

            if (valMod == 1)
            {
                Mod = "QPSK";
            }
            if (valMod == 2)
            {
                Mod = "16-QAM";
            }
            if (valMod == 3)
            {
                Mod = "64-QAM";
            }
            if (valMod == 4)
            {
                Mod = "DQPSK";
            }
        }
        if (T == "DVB-T2")
        {
            List<string> itemsMod = new List<string>() { " ", "QPSK", "16-QAM", "64-QAM", "256-QAM" };
            ModDropdown.AddOptions(itemsMod);
            if (valMod == 1)
            {
                Mod = "QPSK";
            }
            if (valMod == 2)
            {
                Mod = "16-QAM";
            }
            if (valMod == 3)
            {
                Mod = "64-QAM";
            }
            if (valMod == 4)
            {
                Mod = "256-QAM";
            }
        }
        //PP service
        if (T == " ")
        {
            List<string> itemsMod = new List<string>() { " ", "16-QAM", "32-QAM", "64-QAM", "256-QAM", "512-QAM", "1024-QAM", "APSK", "4FSK", "4QAP" };
            ModDropdown.AddOptions(itemsMod);
            if (valMod == 1)
            {
                Mod = "16-QAM";
            }
            if (valMod == 2)
            {
                Mod = "32-QAM";
            }
            if (valMod == 3)
            {
                Mod = "64-QAM";
            }
            if (valMod == 4)
            {
                Mod = "256-QAM";
            }
            if (valMod == 5)
            {
                Mod = "512-QAM";
            }
            if (valMod == 6)
            {
                Mod = "1024-QAM";
            }
            if (valMod == 7)
            {
                Mod = "APSK";
            }
            if (valMod == 8)
            {
                Mod = "4FSK";
            }
            if (valMod == 9)
            {
                Mod = "4QAP";
            }
        }
        assingListPM(valPM);
    }

    public void assingListPM(int valPM)
    {
        if (service == "TV")
        {
            List<string> itemsPM = new List<string>() { " ", "WALFISH IKEGAMI", "OKUMURA HATA", "XIA BERTONI" };
            PMDropdown.AddOptions(itemsPM);
            if (valPM == 1)
            {
                PM = "ALFISH IKEGAMI";
            }
            if (valPM == 2)
            {
                PM = "OKUMURA HATA";
            }
            if (valPM == 3)
            {
                PM = "XIA BERTONI";
            }
        }
        if (service == "PP")
        {
            List<string> itemsPM = new List<string>() { " " };
            PMDropdown.AddOptions(itemsPM);
            if (valPM == 1)
            {
                PM = " ";
            }
        }
            assingListMD(valMD);
    }

    public void assingListMD(int valMD)
    {
        if (service == "TV")
        {
            if (type == "DIRECTIVA")
            {
                List<string> itemsMD = new List<string>() { " ", "45", "60", "90" };
                MDDropdown.AddOptions(itemsMD);

                if (valMD == 1)
                {
                    MD = "45";
                }
                if (valMD == 2)
                {
                    MD = "60";
                }
                if (valMD == 3)
                {
                    MD = "90";
                }
            }
            else if (type == "OMNIDIRECCIONAL")
            {
                List<string> itemsMD = new List<string>() { " ", "360" };
                MDDropdown.AddOptions(itemsMD);
                if (valMD == 1)
                {
                    MD = "360";
                }
            }
        }
        if (service == "PP")
        {
            List<string> itemsMD = new List<string>() { " ", "0", "1", "2", "3", "5", "10" };
            MDDropdown.AddOptions(itemsMD);

            if (valMD == 1)
            {
                MD = "0";
            }
            if (valMD == 2)
            {
                MD = "1";
            }
            if (valMD == 3)
            {
                MD = "2";
            }  
            if (valMD == 4)
            {
                MD = "3";
            }
            if (valMD == 5)
            {
                MD = "5";
            }
            if (valMD == 6)
            {
                MD = "10";
            }
        }
            //assingListG(valG);
    }

    public void assingListG(int valG)
    {
        if (service == "TV")
        {
            Debug.Log("servicio es TV");
            List<string> itemsG = new List<string>() { " ", "3", "6", "9", "12" };
            GDropdown.AddOptions(itemsG);
            if (valG == 1)
            {
                G = "3";
            }
            if (valG == 2)
            {
                G = "6";
            }
            if (valG == 3)
            {
                G = "9";
            }
            if (valG == 4)
            {
                G = "12";
            }
        }
        if (service == "PP")
        {
            Debug.Log("servicio es PP");

            List<string> itemsG = new List<string>() { " ", "20", "30", "40", "50" };
            GDropdown.AddOptions(itemsG);
            if (valG == 1)
            {
                G = "20";
            }
            if (valG == 2)
            {
                G = "30";
            }
            if (valG == 3)
            {
                G = "40";
            }
            if (valG == 4)
            {
                G = "50";
            }
        }
    }
}

