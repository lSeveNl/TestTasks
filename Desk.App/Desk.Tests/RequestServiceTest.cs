using System;
using Desk.Core.Services;
using Desk.Domain.Dto.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace Desk.Tests
{
    [TestClass]
    public class RequestServiceTest
    {
        private readonly Mock<IRequestService> _service;

        public RequestServiceTest()
        {
            _service = new Mock<IRequestService>();
        }

        [TestInitialize]
        [Fact]
        public async void AddAsync()
        {
            var dto = new RequestDto
            {
                Name = "lol",
                Description = "lol",
                RequestTypeId = 1,
                UserId = 2,
                Created = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            };

            var result = await this._service.Object.AddAsync(dto);

            Assert.True(result);
        }
    }
}
