namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;

[TestClass]
public class StudentControllerTest
{
    [TestClass]
    public class UsuarioControllerTest
    {
        [TestInitialize]
        public void InitTest()
        {
        }

        [TestMethod]
        public void GetStudentsOK()
        {
            var logic = new Mock<IStudentLogic>(MockBehavior.Strict);
            StudentController controller = new StudentController(logic.Object);

            Student someStudent = new Student()
            {
                Name = "Test"
            };

            List<Student> students = new List<Student>() { someStudent };
            logic.Setup(l => l.GetStudents()).Returns(students);

            var result = controller.GetStudents();
            var okResult = result as OkObjectResult;
            var modelOut = okResult.Value as ICollection<Student>;

            Assert.IsNotNull(modelOut);
            Assert.AreEqual(200,okResult.StatusCode);
        }

        [TestMethod]
        public void GetStudentByIdOK()
        {
            var logic = new Mock<IStudentLogic>(MockBehavior.Strict);
            StudentController controller = new StudentController(logic.Object);

            Student someStudent = new Student()
            {
                Id = 1,
                Name = "Test"
            };

            logic.Setup(l => l.GetStudentById(It.IsAny<int>())).Returns(someStudent);

            var result = controller.GetStudentById(1);
            var okResult = result as OkObjectResult;
            var modelOut = okResult.Value as Student;

            Assert.IsNotNull(modelOut);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public void CreateStudentOK()
        {
            var logic = new Mock<IStudentLogic>(MockBehavior.Strict);
            StudentController controller = new StudentController(logic.Object);

            Student someStudent = new Student()
            {
                Name = "Test"
            };

            logic.Setup(l => l.InsertStudents((someStudent)));

            var result = controller.CreateStudent(someStudent);
            var okResult = result as OkResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
