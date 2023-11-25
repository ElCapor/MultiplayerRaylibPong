using PongServer;
using Riptide.Utils;

RiptideLogger.Initialize(Console.WriteLine, true);
NetServer server = new();
server.Start(7777, 10);

while (true)
{
    server.Update();
}

server.Stop();