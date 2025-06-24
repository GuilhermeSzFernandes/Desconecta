using Microsoft.AspNetCore.SignalR;

namespace Desconecta.Application.WebSocket
{
    public class ConnectionHub : Hub
    {
        public async Task Bloquear(string codigoMaquina)
        {
            await Clients.Group(codigoMaquina).SendAsync("ReceberBloqueio", true);
        }

        public async Task Desbloquear(string codigoMaquina)
        {
            await Clients.Group(codigoMaquina).SendAsync("ReceberBloqueio", false);
        }

        public override Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var codigo = httpContext?.Request.Query["codigo"];

            if (!string.IsNullOrEmpty(codigo))
            {
                Groups.AddToGroupAsync(Context.ConnectionId, codigo);
            }

            return base.OnConnectedAsync();
        }
    }
}
