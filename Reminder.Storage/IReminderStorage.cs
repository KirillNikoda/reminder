using System;

using System.Text;

namespace Reminder.Storage
{

    public interface IReminderStorage
    {
        void Create(ReminderItem item);

        void Update(ReminderItem item);

        ReminderItem FindById(Guid id);

        System.Collections.Generic.List<ReminderItem> FindByDateTime(DateTimeOffset dateTime);
    }

}
