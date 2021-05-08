using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using TestingDemo.Demo_2;

namespace TestingDemo.XUnit.Tests.Demo_2_StandardSetup
{
    /// <summary>
    /// https://dev.to/cloudx/moq-vs-nsubstitute-who-is-the-winner-40gi.
    /// </summary>
    public class CompareMoqTests
    {
        private Mock<IRepository> _mock;
        private Mock<IUserModel> _mockUser;

        public void _mockCreation()
        {
            _mock = new Mock<IRepository>();
            _mockUser = new Mock<IUserModel>();
        }

        public void SetupProperties()
        {
            IList<IUserModel> userList = null;
            var street = string.Empty;

            // Simple Properties
            _mock.Setup(foo => foo.Users).Returns(userList);

            // Hierarchy Properties
            _mockUser.Setup(foo => foo.Address.Street).Returns(street);
        }

        public void SetupMethods()
        {
            IList<IUserModel> userList = null;
            IUserModel user = null;

            // Without parameters
            _mock.Setup(x => x.ActiveUsers()).Returns(userList);

            // Matching by value
            _mock.Setup(x => x.SearchById(1)).Returns(user);

            // Matching by any value of the parameter type
            _mock.Setup(x => x.SearchById(It.IsAny<int>())).Returns(user);

            // Matching by custom logic
            _mock.Setup(x => x.SearchById(It.Is<int>(i => i < 10))).Returns(user);
        }

        public void CaptureParameter()
        {
            _mock.Setup(x => x.Add(It.IsAny<IUserModel>())).Returns((IUserModel user) => user.Username == "Andres");
        }

        public void MultipleMatching()
        {
            IList<IUserModel> userList = null;

            _mock.Setup(x => x.SearchById(It.IsAny<int>())).Returns((int i) => userList.Skip(1).Take(1).First());
            _mock.Setup(x => x.SearchById(2)).Returns((int i) => userList.First());
        }

        public void MultiReturns()
        {
            IList<IUserModel> users1 = null;
            IList<IUserModel> users2 = null;
            IList<IUserModel> users3 = null;

            _mock.SetupSequence(x => x.Users)
                .Returns(users1)
                .Returns(users2)
                .Returns(users3);
        }

        public void ThrowingExceptions()
        {
            _mock.Setup(x => x.Save()).Throws<Exception>();
            _mock.Setup(x => x.Save()).Throws(new Exception("msj"));
        }

        public void Verify()
        {
            IList<IUserModel> userList = null;

            // Setter
            _mock.VerifySet(x => x.Users = userList);

            // Getter
            _mock.VerifyGet(x => x.Users);

            // Methods with matchting
            _mock.Verify(x => x.Search(It.IsAny<string>()));
            _mock.Verify(x => x.Search("aaa"), Times.Never());

            // Occurrences
            // - Times.Never
            // - Times.Once
            // - Times.AtLeastOnce
            // - Times.AtMost(2)
            // - Times.Exactly(2)
        }

        public void GenericTypes()
        {
            // - It.IsAny<int>())
            // - It.IsInRange(0, 10, Range.Inclusive) 
            // - It.IsIn(Enumerable.Range(1, 5))
            // - It.IsNotIn(Enumerable.Range(1, 5))
            // - It.IsNotNull<string>())
            // - It.IsRegex("abc"))
            // - It.Is<int>(i => i < 10))
            // - _mock.Setup(x => x.Search(IsLarge())) //< custom

            _mock.Setup(m => m.AddUser(It.IsAny<It.IsSubtype<IUserModel>>())).Returns(true);
            _mock.Setup(m => m.AddUser(It.IsAny<IUserModel>())).Returns(false);
        }
    }
}
