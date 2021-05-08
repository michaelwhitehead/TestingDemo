using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using TestingDemo.Demo_2;

namespace TestingDemo.NUnit.Tests.Demo_2_StandardSetup
{
    /// <summary>
    /// https://dev.to/cloudx/moq-vs-nsubstitute-who-is-the-winner-40gi
    /// </summary>
    public class CompareNSubstituteTests
    {
        private IRepository _mock;
        private IUserModel _mockUser;

        public void __mockCreation()
        {
            _mock = Substitute.For<IRepository>();
            _mockUser = Substitute.For<IUserModel>();
        }

        public void SetupProperties()
        {
            IList<IUserModel> userList = null;
            var street = string.Empty;

            // Simple Properties
            _mock.Users.Returns(userList);

            // Hierarchy Properties
            _mockUser.Address.Street.Returns(street);
        }

        public void SetupMethods()
        {
            IList<IUserModel> userList = null;
            IUserModel user = null;

            // Without parameters
            _mock.ActiveUsers().Returns(userList);

            // Matching by value
            _mock.SearchById(1).Returns(user);

            // Matching by any value of the parameter type
            _mock.SearchById(Arg.Any<int>()).Returns(user);

            // Matching by custom logic
            _mock.SearchById(Arg.Is<int>(i => i < 10)).Returns(user);
        }

        public void CaptureParameter()
        {
            _mock.Add(Arg.Any<IUserModel>()).Returns(x => { return ((IUserModel)x[0]).Username == "Andres"; });
        }

        public void MultipleMatching()
        {
            IList<IUserModel> userList = null;

            _mock.SearchById(Arg.Any<int>()).Returns(userList.Skip(1).Take(1).First());
            _mock.SearchById(2).Returns(userList.First());
        }

        public void MultiReturns()
        {
            IList<IUserModel> users1 = null;
            IList<IUserModel> users2 = null;
            IList<IUserModel> users3 = null;

            _mock.Search(Arg.Any<string>()).Returns(users1, users2, users3);
        }

        public void ThrowingExceptions()
        {
            _mock.ActiveUsers().Returns(x => { throw new Exception(); });
            _mock.When(x => x.Save())
                            .Do(x => { throw new Exception("msj"); });
        }

        public void Verify()
        {
            IList<IUserModel> userList = null;

            // Setter
            _mock.Users.Received();

            // Getter
            _mock.Received().Users = userList;

            // Methods with matchting
            _mock.Received().Search("aa");
            _mock.DidNotReceive().Search("aaa");
            _mock.Received(2).Search("bb");

            // Occurrences
            // Nop
        }

        public void GenericTypes()
        {
            // - Arg.Any<int>())
            // - Arg.Is<int>(i => i < 10))

            _mock.AddUser<IUserModel>(Arg.Any<IUserModel>()).Returns(true);
            _mock.AddUser<IUserModel>(Arg.Any<IUserModel>()).Returns(false);
        }
    }
}
