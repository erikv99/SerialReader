using System.IO.Ports;

var serialPort = new SerialPort
{
    PortName = "COM1",
    ReadTimeout = 500,
    WriteTimeout = 500,
    BaudRate = 9600,
    Parity = Parity.None,
    DataBits = 8,
    StopBits = StopBits.One,
    Handshake = Handshake.None
};

try
{
    serialPort.Open();

    while (true)
    {
        try
        {
            var message = serialPort.ReadLine();
            Console.WriteLine(message);
        }
        catch (TimeoutException) { }
    }
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}
finally
{
    if (serialPort.IsOpen)
    {
        serialPort.Close();
    }
}
