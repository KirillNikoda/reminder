using System;
using Reminder.Storage;
using System.Threading;


namespace Reminder.Domain
{


    public class CreateReminderMode
    {
        public string ContactId { get; set; }
        public string Message { get; set; }
        public DateTimeOffset MessageDate { get; set; }
    }
    
    public class ReminderService
    {
        private readonly Timer _timer;
        private readonly IReminderStorage _storage;

        public ReminderService(IReminderStorage storage)
        {
            _storage = storage;
            _timer = new Timer(OnTimerTick, null, TimeSpan.MinValue, TimeSpan.FromSeconds(1));
        }

        private void OnTimerTick(object state)
        {
            var datetime = DateTimeOffset.Now;
            var items = _storage.FindByDateTime(datetime);

            foreach (var item in items)
            {
                item.ReadyToSend();
                _storage.Update(item);
            }

        }

        public void Create(CreateReminderMode model)
        {
            var item = new ReminderItem(
                Guid.NewGuid(),
                model.Message,
                model.ContactId,
                model.MessageDate);

            _storage.Create(item);
        }

        public void Start()
        {

        }
    }
}
