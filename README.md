# NetLoader
Loads any C# binary in mem, patching AMSI and bypassing Windows Defender

The binaries in this repo SHOULD be all clean and newly compiled from their respective GitHub repos, but feel free to compile / host your own.
(Don't consider running binaries from this repo good OPSEC) 
Code is designed to get binaries from a GitHub repo, so should be straight forward.

1. Clone your own repo from this
2. Change the url on line 13 in Program.cs
3. Re-Compile / add your own binaries in /Binaries (Regex looks for .bin only!)
3. Build and enjoy!

# Compile
Changed because Defender added some signatures related to VS ressources.
(Also just way simpler)

	c:\windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /t:exe /out:RandomName.exe Program.cs

![netload](https://github.com/Flangvik/NetLoader/raw/master/Screenshots/netloader.jpg)


As of 05.05.2020, pretty much clean as a whistle
(Going to try to update and keep it like this) 
![scanresults](https://scanmybin.net/img/5e67b051ac75e83a1771782d121178b50f67c3da84190084feca4ded2893a924)

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
- [ ]  Add support for non-interactive use (input args)
- [X]  Add support to run custom modules from your own URL or SMB Share (Great for on-the-fly Implant deployment)
- [ ]  Add some missing stuff SharpSploit and SharpShell (Need to fix some deps)
- [ ]  Propely confirm and test every current bin
- [X]  Add an working MSBuild XML payload for the LOLBins lovers (Myself included)
- [ ]  Update with credits and links to the github repos that /Binaries are compiled from
