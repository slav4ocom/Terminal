# Terminal
Very Simple Serial Terminal Console Program

This is the very first version. 
For siplicity COM port parameters are set manually inside Comunicator.cs class.

The project is compiled with .NET CORE 3.1
System.IO.Ports nuget package is required to build project with .NET CORE 3.1


This program is written especially for testing ESP8266 module. Therefore are added
2 special commands <b>+++</b> and <b>\0</b> . As you can see in the code, theese strings are
interpreted as special and send without <CR><LF> \r\n new line termination.

For convenience commands are not send until ENTER is pressed.

Another 2 special commands are <b>cls</b> for clear screen and <b>exit</b> to close
program. Theese don't send any data over serial port.
