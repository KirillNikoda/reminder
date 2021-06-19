using NUnit.Framework;
using System;

namespace Reminder.Storage.Memory.Tests
{
    public class Tests
    {
        [Test]
        public void WhenCreate_IfEmptyStorage_ShouldFindItemById()
        {
            var item = CreateReminderItem();

            var storage = new ReminderStorage();

            storage.Create(item);

            var result = storage.FindById(item.Id);

            Assert.AreEqual(item.Id, result.Id);

        }

        [Test]
        public void WhenCreate_IfNullSpecified_ShouldThrownException()
        {
            var storage = new ReminderStorage();

            Assert.Catch<ArgumentNullException>(() => storage.Create(null));
        }


        [Test]
        public void WhenCreate_IfExistsElementWithKey_ShouldThrowException()
        {
            var item = CreateReminderItem();

            var storage = new ReminderStorage(item);

            Assert.Catch<ArgumentException>(() => storage.Create(item));
        }

        private ReminderItem CreateReminderItem()
        {
            return new ReminderItem(
               Guid.NewGuid(),
               "123",
               "Some text",
               DateTimeOffset.Now);
        }

    }
}