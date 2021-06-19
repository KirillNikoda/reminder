using System;
using System.Collections.Generic;

namespace Reminder.Storage
{

    public interface IReminderStorage
    {
        void Create(ReminderItem item);

        void Update(ReminderItem item);

        ReminderItem FindById(Guid id);

        List<ReminderItem> FindByDateTime(DateTimeOffset dateTime);

        List<ReminderItem> FindBy(ReminderItemFilter filter);
    }

}
