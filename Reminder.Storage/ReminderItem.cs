using System;

namespace Reminder.Storage
{

    public enum ReminderItemStatus
    {
        Created,
        Ready,
        Sent,
        Failure
    }

    public class ReminderItem
    {
        public Guid Id { get; }
        public string Message { get; private set; }
        public ReminderItemStatus Status { get; private set; }
        public string ContactId { get; private set; }
        public DateTimeOffset MessageDate { get; private set; }
        public ReminderItem(Guid id, string message,
            string contactId,
            DateTimeOffset messageDate, ReminderItemStatus status = ReminderItemStatus.Created)
        {
            if (id == default)
            {
                throw new ArgumentException("Identifier is empty.", nameof(id));
            }

            if (string.IsNullOrWhiteSpace(contactId))
            {
                throw new ArgumentException("Identifier of contact is empty", nameof(contactId));
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Message is empty", nameof(message));
            }

            if (messageDate == default)
            {
                throw new ArgumentException("Message date is empty.", nameof(messageDate));
            }

            Id = id;
            Message = message;
            ContactId = contactId;
            MessageDate = messageDate;
            Status = status;
        }

    }
}