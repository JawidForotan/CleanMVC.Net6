using SimpleMVC.Interfaces;
namespace SimpleMVC.Services
{
    public class MessageService : IMessageService
    {
        private readonly ProductDbContext _context;
        public MessageService(ProductDbContext context)
        {
            _context = context;
        }

        public void Send(Message message)
        {
            _context.messages.Add(message);
            _context.SaveChanges();
        }
    }
}
