using System;
using System.Collections.Generic;
using System.Linq;

namespace Reminder.Storage.Memory
{
    public class ReminderStorage : IReminderStorage
    {
        private readonly Dictionary<Guid, ReminderItem> _map;


        public ReminderStorage(params ReminderItem[] items) 
        {
            _map = items.ToDictionary(item => item.Id);

        }

        public void Create(ReminderItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            
            if (_map.ContainsKey(item.Id))
            {
                throw new ArgumentException($"Element with id = {item.Id} already exists");
            }

            _map[item.Id] = item;
        }

        public List<ReminderItem> FindByDateTime(DateTimeOffset dateTime)
        {
            if (dateTime == default) {
                throw new ArgumentException("Incorrect value of date / time", nameof(dateTime));
            }

            var result = new List<ReminderItem>();

            foreach(var (_, value) in _map)
            {
                if (value.MessageDate < dateTime)
                {
                    result.Add(value);
                }
            }

            return result;
        }

        public ReminderItem FindById(Guid id)
        { 
            if (!_map.ContainsKey(id))
            {
                throw new ArgumentException($"Element with id = {id} is not found", nameof(id));
            }

            return _map[id];
        }

        public void Update(ReminderItem item)
        {
            _map[item.Id] = item;
        }
    }
}
