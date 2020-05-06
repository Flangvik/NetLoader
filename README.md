# NetLoader
Loads any C# binary in mem, patching AMSI and bypassing Windows Defender

The binaries in this repo SHOULD be all clean and newly compiled from their respective GitHub repos, but feel free to compile / host your own.
(Don't consider running binaries from this repo good OPSEC) 
Code is designed to get binaries from a GitHub repo, so should be straight forward.

1. Clone your own repo from this
2. Change the url on line 13 in Program.cs
3. Re-Compile / add your own binaries in /Binaries (Regex looks for .bin only!)
3. Build and enjoy!

As of 05.05.2020, it's FUD and bypasses Defender. 
(Going to try to update and keep it like this) 
![netload](https://github.com/Flangvik/NetLoader/raw/master/netloader.jpg)

Credits to https://twitter.com/_RastaMouse for the AMSI bypass
-> https://github.com/rasta-mouse/AmsiScanBufferBypass/blob/master/ASBBypass/Program.cs

# Todo
- [ ]  Automate the build and release of many of the Sharp Tools so they automagically appear in /Binaries (CDI / Azure DevOps)
- [ ]  Add support for non-interactive use (input args(
- [X]  Add support to run custom modules from your own URL or SMB Share (Great for on-the-fly Implant deployment)
- [ ]  Add some missing stuff SharpSploit and SharpShell (Need to fix some deps)
- [ ]  Propely confirm and test every current bin
- [ ]  Add an working MSBuild XML payload for the LOLBins lovers (Myself included)
