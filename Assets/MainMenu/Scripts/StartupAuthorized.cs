using UnityEngine;
using System.Collections;
using System.IO;

public class StartupAuthorized : MonoBehaviour
{
    private StreamReader FileReader = null;
    private FileInfo AuthorizationFile = null;
    private string AuthorizationText;

    // Use this for initialization
    void Start()
    {
        string[] TempArr = new string[1];
        TempArr[0] = "<HASH>1nh0su7gmv6oenvu4sbctew10</HASH>";
        AuthorizationFile = new FileInfo("Annihilation_Data/Resources/Authorize.txt");
        FileReader = AuthorizationFile.OpenText();
        AuthorizationText = FileReader.ReadLine();
        FileReader.Close();
        if (AuthorizationText == "Authorized = True")
        {
            File.WriteAllLines("Annihilation_Data/Resources/Authorize.txt", TempArr);
        }
        else
        {
            Application.Quit();
        }
    }
}