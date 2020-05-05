# NetLoader
Loads any C# binary in mem, patching AMSI and bypassing Windows Defender

The binaries are clean compiled from their respective GitHub repos, but feel free to compile / host your own.
Code is designed to get binaries from a GitHub, so should be straight forward.

1. Clone your own repo from this
2. Change the url on line 13 in Program.cs
3. Re-Compile / add your own binaries in /Binaries (Regex looks for .bin only!)
3. Build and enjoy!

As of 05.05.2020, it's FUD and bypasses Defender. 
(Going to try to update and keep it like this) 
![netload](https://github.com/Flangvik/NetLoader/raw/master/screenshot.JPG)

Credits to https://twitter.com/_RastaMouse for the AMSI bypass
-> https://github.com/rasta-mouse/AmsiScanBufferBypass/blob/master/ASBBypass/Program.cs
