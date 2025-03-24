using CustomerService;
using CustomerService.DTO;
using CustomerService.Service;

namespace RegistrationMangerTests
{
    [TestFixture]
    public class Tests
    {
        IRegistrationManager manager;

        [SetUp]
        public void Setup()
        {
            manager = new RegistrationManager();
        }

        [Test]
        public void Register_ForCorrectDto_ReturnsSuccessResponse()
        {
            // arrange
            RegistrationRequestDto req = new();
            req.Name = "Vinod";
            req.Email = "vinod@vinod.co";
            req.Phone = "9731424784";
            req.City = "Bangalore";

            // act
            RegistrationResponseDto resp = manager.Register(req);

            // assert
            Assert.That(resp.Success, Is.True);
            Assert.That(resp.Id, Is.Not.Null);
            Assert.That(resp.Id, Is.Not.EqualTo(Guid.Empty));
            Assert.That(resp.ErrorMessage, Is.Null);

        }


        [Test]
        public void Register_WithDuplicateEmail_ReturnsFailureResponse()
        {
            // Arrange
            var request1 = new RegistrationRequestDto
            {
                Name = "Aditya",
                Email = "aditya@aditya.co",
                Phone = "9731424784",
                City = "Bangalore"
            };

            var request2 = new RegistrationRequestDto
            {
                Name = "Atishay",
                Email = "aditya@aditya.co",
                Phone = "9876543210",
                City = "Delhi"
            };

            var manager = new RegistrationManager();
            manager.Register(request1); // First registration

            // Act
            var result = manager.Register(request2); // Attempting to register with the same email

            // Assert
            Assert.That(result.Success, Is.False);
            Assert.That(result.ErrorMessage, Is.EqualTo("Email already exists."));
        }
        [Test]
        public void Register_WithInvalidEmailFormat_ReturnsFailureResponse()
        {
            // Arrange
            var request = new RegistrationRequestDto
            {
                Name = "Vinod",
                Email = "vinod-vinod.co", // Invalid email format
                Phone = "9731424784",
                City = "Bangalore"
            };

            var manager = new RegistrationManager();

            // Act
            var result = manager.Register(request);

            // Assert
            Assert.That(result.Success, Is.False);
            Assert.That(result.ErrorMessage, Is.EqualTo("Invalid email format."));
        }
        [Test]
        public void Register_WithMissingRequiredFields_ReturnsFailureResponse()
        {
            // Arrange
            var request = new RegistrationRequestDto
            {
                Name = "", // Missing name
                Email = "", // Missing email
                Phone = "9731424784",
                City = "Bangalore"
            };

            var manager = new RegistrationManager();

            // Act
            var result = manager.Register(request);

            // Assert
            Assert.That(result.Success, Is.False);
            Assert.That(result.ErrorMessage, Is.EqualTo("Name and Email are required."));
        }
        [Test]
        public void Register_WithInvalidPhoneNumber_ReturnsFailureResponse()
        {
            // Arrange
            var request = new RegistrationRequestDto
            {
                Name = "Aryan Rathore",
                Email = "aryanrajsinghrathore.it25@jecrc.ac.in",
                Phone = "820972", //invalid phone number
                City = "Jaipur"
            };

            var manager = new RegistrationManager();

            // Act
            var result = manager.Register(request);

            // Assert
            Assert.That(result.Success, Is.False);
            Assert.That(result.ErrorMessage, Is.EqualTo("Invalid phone number format."));
        }
        [Test]
        public void Register_WithEmptyFields_ReturnsFailureResponse()
        {
            // Arrange
            var request = new RegistrationRequestDto
            {
                Name = " ",
                Email = " ",
                Phone = " ",
                City = " "
            };

            var manager = new RegistrationManager();

            // Act
            var result = manager.Register(request);

            // Assert
            Assert.That(result.Success, Is.False);
            Assert.That(result.ErrorMessage, Is.EqualTo("All fields are required."));
        }



    }
}